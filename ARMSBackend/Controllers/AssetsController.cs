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

namespace ARMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AppContext _context;

        public AssetsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetReadDto>>> GetAssets()
        {
            return await _context.Assets.Include(a => a.AssetType).Include(a => a.Model).Select(a => new AssetReadDto(a)).ToListAsync();
        }

        // GET: api/Assets
        [HttpGet]
        [Route("onmodel")]
        public async Task<ActionResult<IEnumerable<AssetModelItem>>> GetAssetsOnModel()
        {
            return await _context.AssetModelItems.Include(a => a.Asset).Include(a => a.Model).ToListAsync();
        }

        // GET: api/Assets
        [HttpGet]
        [Route("latestmetrics/{id}")]
        public ActionResult<IEnumerable<object>> GetAssetsLatestMetrics(int id)
        {
            var assetMetricTypes = _context.Metrics.Where(a => a.AssetId == id).Select(a => a.MetricTypeId).Distinct().ToList();

            List<object> metrics =  new List<object>();

            foreach (var metricType in assetMetricTypes)
            {
                var metric = _context.Metrics
                    .Where(a => a.AssetId == id)
                    .Where(a => a.MetricTypeId == metricType)
                    .OrderByDescending(x=>x.DateTime)
                    .Include(a=>a.MetricType)
                    .First();
                metrics.Add(metric);
            }

            return metrics;
        }



        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetReadDto>> GetAsset(int id)
        {
            var asset = await _context.Assets.Include(a => a.AssetType).Include(a => a.Model).FirstOrDefaultAsync(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return new AssetReadDto(asset);
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/Assets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssetExists(int id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
    }
}
