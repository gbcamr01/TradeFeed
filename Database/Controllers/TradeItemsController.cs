using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedBurnTradeFeed.DBContext;
using RedBurnTradeFeed.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedBurnTradeFeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class TradeItemsController : ControllerBase
    {
        /// <summary>
        /// The Trade Items Database context
        /// </summary>
        private readonly TradeItemDBContext _tradeItemsDbContext;

        public TradeItemsController(TradeItemDBContext tradeItemsDbContext)
        {
            _tradeItemsDbContext = tradeItemsDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeItem>>> GetItem()
        {
            return Ok(await _tradeItemsDbContext.TradeItems.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<TradeItem>> Create([FromBody] TradeItem item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tradeItemsDbContext.TradeItems.AddAsync(item);
            await _tradeItemsDbContext.SaveChangesAsync();

            return Ok(item);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TradeItem>> Update(int id, [FromBody] TradeItem tradeItemFromJson)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _tradeItemsDbContext.TradeItems.FindAsync(id);

            if (item == null) return NotFound();
            
            GetData(ref item, tradeItemFromJson);

            await _tradeItemsDbContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TradeItem>> Delete(int id)
        {
            var item = await _tradeItemsDbContext.TradeItems.FindAsync(id);

            if (item == null) return NotFound();
            
            _tradeItemsDbContext.Remove(item);

            await _tradeItemsDbContext.SaveChangesAsync();

            return Ok(item);
        }

        private void GetData(ref TradeItem item, TradeItem tradeItemFromJson)
        {
            if (item == null || tradeItemFromJson == null) return;

            item.Id = tradeItemFromJson.Id;
            item.LastPrice = tradeItemFromJson.LastPrice;
            item.Side = tradeItemFromJson.Side;
            item.Status = tradeItemFromJson.Status;
            item.Ticker = tradeItemFromJson.Ticker;
        }
    }
}