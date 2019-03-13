using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using static Warehouse.Api.WarehouseContext;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET api/stock/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                Stock res = db.Stocks.FirstOrDefault(x => x.StockId == id);
                return Ok(res);
            }
        }

        // GET api/stock/list
        [HttpGet]
        public IActionResult List(int plantId, int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.Stocks.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<Stock> res = (from l in db.Stocks.Where(x => x.plant.PlantId == plantId).Skip((page - 1) * cnt).Take(take)
                                    join cu in db.Users on l.createdUserId equals cu.UserId into c1
                                    from cu in c1.DefaultIfEmpty()

                                    join lu in db.Users on l.createdUserId equals lu.UserId into c2
                                    from lu in c2.DefaultIfEmpty()

                                    join mu in db.MovementTypes on l.movementTypeId equals mu.MovementTypeId into c3
                                    from mu in c3.DefaultIfEmpty()

                                    join parent in db.Stocks on l.parentStockId equals parent.StockId into c4
                                    from parent in c4.DefaultIfEmpty()

                                    join pla in db.Plants on l.plantId equals pla.PlantId into c5
                                    from pla in c5.DefaultIfEmpty()

                                    join prod in db.Products on l.productId equals prod.ProductId into c6
                                    from prod in c6.DefaultIfEmpty()

                                    select new Stock
                                    {
                                        StockId = l.StockId,
                                        createdDate = l.createdDate,
                                        lastUpdatedDate = l.lastUpdatedDate,
                                        createdUserId = l.createdUserId,
                                        lastUpdatedUserId = l.lastUpdatedUserId,
                                        createdUser = cu,
                                        lastUpdatedUser = lu,
                                        barcode = l.barcode,
                                        movementTypeId = l.movementTypeId,
                                        parentStockId = l.parentStockId,
                                        plantId = l.plantId,
                                        productId = l.productId,
                                        quantity = l.quantity,
                                        movementType = mu,
                                        parentStock = parent,
                                        plant = pla,
                                        product = prod
                                    }).ToList();

                return Ok(new GridData() { rows = res, total= res.Count });
            }
        }


        // GET api/Post
        [HttpPost]
        public IActionResult Post([FromForm]Stock entity)
        {
            string errMsg = "Insert failed.";
            int count = 0;
            try
            {
                using (var db = new WarehouseContext())
                {
                    if(db.Stocks.Count(x=>x.barcode.ToLower() == entity.barcode.ToLower()) > 0)
                    {
                        errMsg = "Same barcode";
                        throw null;
                    }
                    Helper.Instance.SetAudit(entity);
                    db.Stocks.Add(entity);
                    count = db.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                string fullErr = ex.GetaAllMessages();

                throw new Exception(errMsg + " Error: " + fullErr);
            }

            return Ok(count > 0);
        }

        // GET api/Put
        [HttpPut]
        public IActionResult Put([FromForm]Stock entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Stocks.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]Stock entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Stocks.Remove(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete failed. Error : {ex.GetaAllMessages()}");
            }
        }
    }
}
