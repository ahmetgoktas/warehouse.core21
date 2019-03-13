using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using static Warehouse.Api.WarehouseContext;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/Product/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                Product res = db.Products.FirstOrDefault(x => x.ProductId == id);
                return Ok(res);
            }
        }

        // GET api/Product/list
        [HttpGet]
        public IActionResult List(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.Products.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<Product> res = (from l in db.Products.Skip((page - 1) * cnt).Take(take)
                                            join cu in db.Users on l.createdUserId equals cu.UserId into c1
                                            from cu in c1.DefaultIfEmpty()

                                            join lu in db.Users on l.createdUserId equals lu.UserId into c2
                                            from lu in c2.DefaultIfEmpty()

                                            select new Product
                                            {
                                                ProductId = l.ProductId,
                                                code = l.code,
                                                name = l.name,
                                                createdDate = l.createdDate,
                                                lastUpdatedDate = l.lastUpdatedDate,
                                                createdUserId = l.createdUserId,
                                                lastUpdatedUserId = l.lastUpdatedUserId,
                                                createdUser = cu,
                                                lastUpdatedUser = lu,
                                                articlecode = l.articlecode,
                                                gtin = l.gtin
                                            }).ToList();
                 
                return Ok(new GridData() { rows = res, total= res.Count });
            }
        }


        // GET api/Product/Post
        [HttpPost]
        public IActionResult Post([FromForm]Product entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.Products.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Product/Put
        [HttpPut]
        public IActionResult Put([FromForm]Product entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Products.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Product/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]Product entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Products.Remove(entity);
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
