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
    public class ListController : ControllerBase
    {
        // GET api/list/empty
        [HttpGet]
        public ActionResult<string> Empty()
        {
            return "";
        }

        // GET api/list/stocklist
        [HttpGet]
        public IActionResult StockList(int plantId, int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<Stock> res = db.Stocks.Where(x => x.Plant.PlantId == plantId).Skip((page-1)*pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total= res.Count });
            }
        }

        // GET api/list/productlist
        [HttpGet]
        public IActionResult ProductList(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<Product> res = db.Products.Skip((page - 1) * pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        // GET api/list/plantlist
        [HttpGet]
        public IActionResult PlantList(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<Plant> res = db.Plants.Skip((page - 1) * pageSize).Take(take == 0 ? db.Plants.Count() : take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        // GET api/list/Locationlist
        [HttpGet]
        public IActionResult LocationList(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<Location> res = db.Locations.Skip((page - 1) * pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        // GET api/list/MovementTypelist
        [HttpGet]
        public IActionResult MovementTypeList(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<MovementType> res = db.MovementTypes.Skip((page - 1) * pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        // GET api/list/UserList
        [HttpGet]
        public IActionResult UserList(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<User> res = db.Users.Skip((page - 1) * pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        // GET api/list/LocationTypelist
        [HttpGet]
        public IActionResult LocationTypelist(int page = 1, int take = 0, int skip = 0, int pageSize = 0, string filter = "")
        {
            using (var db = new WarehouseContext())
            {
                IList<LocationType> res = db.LocationTypes.Skip((page - 1) * pageSize).Take(take).ToList();
                return Ok(new GridData() { rows = res, total = res.Count });
            }
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
