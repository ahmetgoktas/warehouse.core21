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
    public class DetailController : ControllerBase
    {
        #region Stoks
        // GET api/detail/stock/id
        [HttpGet]
        public IActionResult Stock(int id)
        {
            using (var db = new WarehouseContext())
            {
                Stock res = db.Stocks.FirstOrDefault(x => x.StockId == id);
                return Ok(res);
            }
        }

        // GET api/detail/StockInsert
        [HttpPost]
        public IActionResult StockInsert([FromForm]Stock entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.Stocks.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/StockUpdate
        [HttpPut]
        public IActionResult StockUpdate([FromForm]Stock entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/StockDelete
        [HttpDelete]
        public IActionResult StockDelete([FromForm]Stock entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region Product
        // GET api/detail/product/id
        [HttpGet]
        public IActionResult Product(int id)
        {
            using (var db = new WarehouseContext())
            {
                Product res = db.Products.FirstOrDefault(x => x.ProductId == id);
                return Ok(res);
            }
        }

        // GET api/detail/ProductInsert
        [HttpPost]
        public IActionResult ProductInsert([FromForm]Product entity)
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
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/ProductUpdate
        [HttpPut]
        public IActionResult ProductUpdate([FromForm]Product entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/ProductDelete
        [HttpDelete]
        public IActionResult ProductDelete([FromForm]Product entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region Location
        // GET api/detail/Location/id
        [HttpGet]
        public IActionResult Location(int id)
        {
            using (var db = new WarehouseContext())
            {
                Location res = db.Locations.FirstOrDefault(x => x.LocationId == id);
                return Ok(res);
            }
        }

        // GET api/detail/LocationInsert
        [HttpPost]
        public IActionResult LocationInsert([FromForm]Location entity)
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
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/LocationUpdate
        [HttpPut]
        public IActionResult LocationUpdate([FromForm]Location entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/LocationDelete
        [HttpDelete]
        public IActionResult LocationDelete([FromForm]Location entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region User
        // GET api/detail/User/id
        [HttpGet]
        public IActionResult User(int id)
        {
            using (var db = new WarehouseContext())
            {
                User res = db.Users.FirstOrDefault(x => x.UserId == id);
                return Ok(res);
            }
        }

        // GET api/detail/UserInsert
        [HttpPost]
        public IActionResult UserInsert([FromForm]User entity)
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
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/UserUpdate
        [HttpPut]
        public IActionResult UserUpdate([FromForm]User entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/UserDelete
        [HttpDelete]
        public IActionResult UserDelete([FromForm]User entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region Plant
        // GET api/detail/Plant/id
        [HttpGet]
        public IActionResult Plant(int id)
        {
            using (var db = new WarehouseContext())
            {
                Plant res = db.Plants.FirstOrDefault(x => x.PlantId == id);
                return Ok(res);
            }
        }

        // GET api/detail/PlantInsert
        [HttpPost]
        public IActionResult PlantInsert([FromForm]Plant entity)
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
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/PlantUpdate
        [HttpPut]
        public IActionResult PlantUpdate([FromForm]Plant entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/PlantDelete
        [HttpDelete]
        public IActionResult PlantDelete([FromForm]Plant entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region MovementType
        // GET api/detail/MovementType/id
        [HttpGet]
        public IActionResult MovementType(int id)
        {
            using (var db = new WarehouseContext())
            {
                MovementType res = db.MovementTypes.FirstOrDefault(x => x.MovementTypeId == id);
                return Ok(res);
            }
        }

        // GET api/detail/MovementTypeInsert
        [HttpPost]
        public IActionResult MovementTypeInsert([FromForm]MovementType entity)
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
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        
        // GET api/detail/MovementTypeUpdate
        [HttpPut]
        public IActionResult MovementTypeUpdate([FromForm]MovementType entity)
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
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/MovementTypeDelete
        [HttpDelete]
        public IActionResult MovementTypeDelete([FromForm]MovementType entity)
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
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion

        #region LocationType
        // GET api/detail/LocationType/id
        [HttpGet]
        public IActionResult LocationType(int id)
        {
            using (var db = new WarehouseContext())
            {
                LocationType res = db.LocationTypes.FirstOrDefault(x => x.LocationTypeId == id);
                return Ok(res);
            }
        }

        // GET api/detail/LocationTypeInsert
        [HttpPost]
        public IActionResult LocationTypeInsert([FromForm]LocationType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    Helper.Instance.SetAudit(entity);
                    db.LocationTypes.Add(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hareket tipi girişinde hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/LocationTypeUpdate
        [HttpPut]
        public IActionResult LocationTypeUpdate([FromForm]LocationType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.LocationTypes.Update(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hareket tipi güncellemede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }

        // GET api/detail/LocationTypeDelete
        [HttpDelete]
        public IActionResult LocationTypeDelete([FromForm]LocationType entity)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.LocationTypes.Remove(entity);
                    int count = db.SaveChanges();
                    return Ok(count > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hareket tipi silmede hata oluştu.Hata : {ex.GetaAllMessages()}");
            }
        }
        #endregion
    }
}
