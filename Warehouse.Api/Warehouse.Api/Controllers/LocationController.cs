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
    public class LocationController : ControllerBase
    {
        // GET api/Location/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                Location res = db.Locations.FirstOrDefault(x => x.LocationId == id);
                return Ok(res);
            }
        }

        // GET api/Location/list
        [HttpGet]
        public IActionResult List(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.Locations.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<Location> res = (from l in db.Locations.Skip((page - 1) * cnt).Take(take)
                                            join cu in db.Users on l.createdUserId equals cu.UserId into c1
                                            from cu in c1.DefaultIfEmpty()

                                            join lu in db.Users on l.createdUserId equals lu.UserId into c2
                                            from lu in c2.DefaultIfEmpty()

                                            join lt in db.LocationTypes on l.locationTypeId equals lt.LocationTypeId into c3
                                            from lt in c3.DefaultIfEmpty()

                                            join locP in db.Locations on l.parentLocationId equals locP.LocationId into c4
                                            from locP in c4.DefaultIfEmpty()
                                            select new Location
                                            {
                                                LocationId = l.LocationId,
                                                code = l.code,
                                                name = l.name,
                                                createdDate = l.createdDate,
                                                lastUpdatedDate = l.lastUpdatedDate,
                                                createdUserId = l.createdUserId,
                                                lastUpdatedUserId = l.lastUpdatedUserId,
                                                createdUser = cu,
                                                lastUpdatedUser = lu,
                                                locationType = lt,
                                                parentLocation = locP,
                                                coords = l.coords,
                                                outline = l.outline,
                                                locationTypeId = l.locationTypeId,
                                                parentLocationId = l.parentLocationId
                                            }).ToList();

                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }


        // GET api/Location/Post
        [HttpPost]
        public IActionResult Post([FromForm]Location entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.Locations.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Location/Put
        [HttpPut]
        public IActionResult Put([FromForm]Location entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Locations.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/Location/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]Location entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Locations.Remove(entity);
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
