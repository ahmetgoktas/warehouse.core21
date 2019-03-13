namespace Warehouse.Api
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class WarehouseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<MovementType> MovementTypes { get; set; }

        public DbSet<LocationType> LocationTypes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Sequence> Sequences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wms.db");
        }
        

        public class User
        {
            public int UserId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
        }

        public class MovementType
        {
            public int MovementTypeId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }

            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class Location
        {
            public int LocationId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string outline { get; set; }
            public string coords { get; set; }

            public int? parentLocationId { get; set; }
            public Location parentLocation { get; set; }

            public int locationTypeId { get; set; }
            public LocationType locationType { get; set; }

            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }

            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class Plant
        {
            public int PlantId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public int locationId { get; set; }
            public Location location { get; set; }
            public string plantCoords { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string articlecode { get; set; }
            public string gtin { get; set; }

            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class Stock
        {
            public int StockId { get; set; }
            public int productId { get; set; }
            public Product product { get; set; }
            public int plantId { get; set; }
            public Plant plant { get; set; }
            public int movementTypeId { get; set; }
            public MovementType movementType { get; set; }
            public string barcode { get; set; }
            public int? parentStockId { get; set; }
            public Stock parentStock { get; set; }
            public int quantity { get; set; }

            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class LocationType
        {
            public int LocationTypeId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public int? createdUserId { get; set; }
            public User createdUser { get; set; }

            public int? lastUpdatedUserId { get; set; }
            public User lastUpdatedUser { get; set; }
        }

        public class Sequence
        {
            public int SequenceId { get; set; }
            public string entityname { get; set; }
            public int seq { get; set; }
        }
    }
}
