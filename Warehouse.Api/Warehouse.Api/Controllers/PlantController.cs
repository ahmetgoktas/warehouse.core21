using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Api;
using static Warehouse.Api.WarehouseContext;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        // GET api/Plant/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                Plant res = db.Plants.FirstOrDefault(x => x.PlantId == id);
                return Ok(res);
            }
        }

        // GET api/Plant/list
        [HttpGet]
        public IActionResult List(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.Plants.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<Plant> res = (from l in db.Plants.Skip((page - 1) * cnt).Take(take)
                                    join cu in db.Users on l.createdUserId equals cu.UserId into c1
                                    from cu in c1.DefaultIfEmpty()

                                    join lu in db.Users on l.createdUserId equals lu.UserId into c2
                                    from lu in c2.DefaultIfEmpty()

                                    join loc in db.Locations on l.locationId equals loc.LocationId into c3
                                    from loc in c3.DefaultIfEmpty()
                                    select new Plant
                                    {
                                        PlantId = l.PlantId,
                                        code = l.code,
                                        name = l.name,
                                        createdDate = l.createdDate,
                                        lastUpdatedDate = l.lastUpdatedDate,
                                        createdUserId = l.createdUserId,
                                        lastUpdatedUserId = l.lastUpdatedUserId,
                                        createdUser = cu,
                                        lastUpdatedUser = lu,
                                        location = loc,
                                        locationId = l.locationId,
                                        plantCoords = l.plantCoords
                                    }).ToList();

                return Ok(new GridData() { rows = res, total= res.Count });
            }
        }


        // GET api/Plant/Post
        [HttpPost]
        public IActionResult Post([FromForm]Plant entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.Plants.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Plant/Put
        [HttpPut]
        public IActionResult Put([FromForm]Plant entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Plants.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Plant/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]Plant entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Plants.Remove(entity);
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
