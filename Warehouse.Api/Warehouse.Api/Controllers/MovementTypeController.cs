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
    public class MovementTypeController : ControllerBase
    {
        // GET api/MovementType/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                MovementType res = db.MovementTypes.FirstOrDefault(x => x.MovementTypeId == id);
                return Ok(res);
            }
        }

        // GET api/MovementType/list
        [HttpGet]
        public IActionResult List(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.MovementTypes.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<MovementType> res = (from l in db.MovementTypes.Skip((page - 1) * cnt).Take(take)
                                           join cu in db.Users on l.createdUserId equals cu.UserId into c1
                                           from cu in c1.DefaultIfEmpty()

                                           join lu in db.Users on l.createdUserId equals lu.UserId into c2
                                           from lu in c2.DefaultIfEmpty()
                                           select new MovementType
                                           {
                                               MovementTypeId = l.MovementTypeId,
                                               code = l.code,
                                               name = l.name,
                                               createdDate = l.createdDate,
                                               lastUpdatedDate = l.lastUpdatedDate,
                                               createdUserId = l.createdUserId,
                                               lastUpdatedUserId = l.lastUpdatedUserId,
                                               createdUser = cu,
                                               lastUpdatedUser = lu
                                           }).ToList();
                
                return Ok(new GridData() { rows = res, total= res.Count });
            }
        }


        // GET api/MovementType/Post
        [HttpPost]
        public IActionResult Post([FromForm]MovementType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.MovementTypes.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/MovementType/Put
        [HttpPut]
        public IActionResult Put([FromForm]MovementType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.MovementTypes.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/MovementType/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]MovementType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.MovementTypes.Remove(entity);
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
