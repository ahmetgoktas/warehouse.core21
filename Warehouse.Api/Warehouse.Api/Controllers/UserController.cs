using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using static Warehouse.Api.WarehouseContext;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/User/Get/id
        [HttpGet]
        public IActionResult Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                User res = db.Users.FirstOrDefault(x => x.UserId == id);
                return Ok(res);
            }
        }

        // GET api/User/list
        [HttpGet]
        public IActionResult List(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                int cnt = (pageSize == 0 ? db.Users.Count() : pageSize);
                take = take == 0 ? cnt : take;

                IList<User> res = db.Users.Skip((page - 1) * cnt).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }


        // GET api/User/Post
        [HttpPost]
        public IActionResult Post([FromForm]User entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.Users.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/User/Put
        [HttpPut]
        public IActionResult Put([FromForm]User entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Users.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed. Error : {ex.GetaAllMessages()}");
            }
        }

        // GET api/User/Delete
        [HttpDelete]
        public IActionResult Delete([FromForm]User entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Users.Remove(entity);
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
