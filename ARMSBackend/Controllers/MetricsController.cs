using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARMSBackend;
using ARMSBackend.Models;
using ARMSBackend.DTOs;
using System.Net.Http;
using System.IO;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace ARMSBackend.Controllers
{
    public class ForecasetResponeData {
        public double[] data { get; set; }
        public string[] dates { get; set; }
    }

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly AppContext _context;

        public MetricsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Metrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metric>>> GetMetrics(int? asset, int? metricType)
        {
            var q = _context.Metrics.Where(m=>m.Id==m.Id);

            if (asset != null)
            {
                q = q.Where(m => m.AssetId == asset);
            }

            if (metricType != null)
            {
                q = q.Where(m => m.MetricTypeId == metricType);
            }

            return await q.ToListAsync();
        }

        // GET: api/Metrics
        [HttpGet]
        [Route("chart/{assetId}/{metricTypeId}")]
        public List<PlotlyChart<DateTime, double>> GetChart(int assetId, int metricTypeId)
        {
            var q = _context.Metrics
                            .Where(m => m.AssetId == assetId)
                            .Where(m => m.MetricTypeId == metricTypeId)
                            .OrderBy(m => m.DateTime);


            var data = q.ToList();

            var chart = new List<PlotlyChart<DateTime, double>>();

            

            var plot1 = new PlotlyChart<DateTime, double>("lines", "Current");

            foreach (var item in data)
            {
                plot1.addToX(item.DateTime);
                plot1.addToY(item.Value);
            }

            chart.Add(plot1);
  
            return chart;
        }

        static HttpClient httpClient = new HttpClient();

        // GET: api/Metrics
        [HttpGet]
        [Route("chart/forecast/{assetId}/{metricTypeId}")]
        public async Task<List<PlotlyChart<DateTime, double>>> GetForecastedChart(int assetId, int metricTypeId)
        {

            string getData;
            ForecasetResponeData result = new ForecasetResponeData();

            var BASE_URL = AppData.Configuration.GetSection("APIs").GetSection("PythonForecast").Value;

            HttpResponseMessage response = await httpClient.GetAsync($"{BASE_URL}/predict-metrics?assetId={assetId}&metricType={metricTypeId}");

            if (response.IsSuccessStatusCode)
            {
                getData = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ForecasetResponeData>(getData);
            }

            var chart = new List<PlotlyChart<DateTime, double>>();


            var plot1 = new PlotlyChart<DateTime, double>("lines","Forecasted", result.dates.Select(d => DateTime.Parse(d)).ToList(), result.data.ToList());


            chart.Add(plot1);

            return chart;

        }



        // GET: api/Metrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metric>> GetMetric(int id)
        {
            var metric = await _context.Metrics.FindAsync(id);

            if (metric == null)
            {
                return NotFound();
            }

            return metric;
        }

        // PUT: api/Metrics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetric(int id, Metric metric)
        {
            if (id != metric.Id)
            {
                return BadRequest();
            }

            _context.Entry(metric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Metrics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Metric>> PostMetric(Metric metric)
        {
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetric", new { id = metric.Id }, metric);
        }

        // DELETE: api/Metrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetric(int id)
        {
            var metric = await _context.Metrics.FindAsync(id);
            if (metric == null)
            {
                return NotFound();
            }

            _context.Metrics.Remove(metric);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetricExists(int id)
        {
            return _context.Metrics.Any(e => e.Id == id);
        }
    }
}
