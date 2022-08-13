using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARMSBackend;
using ARMSBackend.Models;

namespace ARMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricTypesController : ControllerBase
    {
        private readonly AppContext _context;

        public MetricTypesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/MetricTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetricType>>> GetMetricsType()
        {
            return await _context.MetricsType.ToListAsync();
        }

        // GET: api/MetricTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetricType>> GetMetricType(int id)
        {
            var metricType = await _context.MetricsType.FindAsync(id);

            if (metricType == null)
            {
                return NotFound();
            }

            return metricType;
        }

        // PUT: api/MetricTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetricType(int id, MetricType metricType)
        {
            if (id != metricType.Id)
            {
                return BadRequest();
            }

            _context.Entry(metricType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricTypeExists(id))
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

        // POST: api/MetricTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetricType>> PostMetricType(MetricType metricType)
        {
            _context.MetricsType.Add(metricType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetricType", new { id = metricType.Id }, metricType);
        }

        // DELETE: api/MetricTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetricType(int id)
        {
            var metricType = await _context.MetricsType.FindAsync(id);
            if (metricType == null)
            {
                return NotFound();
            }

            _context.MetricsType.Remove(metricType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetricTypeExists(int id)
        {
            return _context.MetricsType.Any(e => e.Id == id);
        }
    }
}
