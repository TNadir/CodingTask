namespace CodingSolution.Data.Migrations
{
    using CodingSolution.Data.Domen;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingSolution.Data.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodingSolution.Data.Models.ApplicationDbContext context)
        {

           // var d = DateTime.Now;

           //var packagingId = context.Sectors.FirstOrDefault(x => x.Name == "Plastic and Rubber").Id;
           // context.Sectors.Add(new Sectors { Name = "Packaging", ParentId = packagingId, CreateDate =d });
           // context.Sectors.Add(new Sectors { Name = "Plastic goods", ParentId = packagingId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Plastic processing technology", ParentId = packagingId, CreateDate = d });

           // context.SaveChanges();
           // var plasticId = context.Sectors.FirstOrDefault(x => x.Name == "Plastic processing technology").Id;
           // context.Sectors.Add(new Sectors { Name = "Blowing", ParentId = plasticId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Moulding", ParentId = plasticId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Plastics welding and processing", ParentId = plasticId, CreateDate = d });
           // context.SaveChanges();

           // var MetalworkingId = context.Sectors.FirstOrDefault(x => x.Name == "Metalworking").Id;
           // context.Sectors.Add(new Sectors { Name = "Construction of metal structures", ParentId = MetalworkingId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Houses and buildings", ParentId = MetalworkingId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Metal products", ParentId = MetalworkingId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Metal works", ParentId = MetalworkingId, CreateDate = d });
           // context.SaveChanges();

           // var MetalworksId = context.Sectors.FirstOrDefault(x => x.Name == "Metal works").Id;
           // context.Sectors.Add(new Sectors { Name = "CNC-machining", ParentId = MetalworksId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Forgings, Fasteners", ParentId = MetalworksId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Gas, Plasma, Laser cutting", ParentId = MetalworksId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "MIG, TIG, Aluminum welding", ParentId = MetalworksId, CreateDate = d });

           // context.SaveChanges();

           // var MachineryId = context.Sectors.FirstOrDefault(x => x.Name == "Machinery").Id;
           // context.Sectors.Add(new Sectors { Name = "Machinery components", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Machinery equipment/tools", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Manufacture of machinery", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Maritime", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Metal structures", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Other", ParentId = MachineryId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Repair and maintenance service", ParentId = MachineryId, CreateDate = d });
           // context.SaveChanges();
           // var MaritimeId = context.Sectors.FirstOrDefault(x => x.Name == "Maritime").Id;
           // context.Sectors.Add(new Sectors { Name = "Aluminium and steel workboats", ParentId = MaritimeId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Boat/Yacht building", ParentId = MaritimeId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Ship repair and conversion", ParentId = MaritimeId, CreateDate = d });
           // context.SaveChanges();
           // var FurnitureId = context.Sectors.FirstOrDefault(x => x.Name == "Furniture").Id;
           // context.Sectors.Add(new Sectors { Name = "Bathroom/sauna", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Bedroom", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Children’s room", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Kitchen", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Living room", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Office", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Other (Furniture)", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Outdoor", ParentId = FurnitureId, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Project furniture", ParentId = FurnitureId, CreateDate = d });
           // context.SaveChanges();


           // context.Sectors.Add(new Sectors { Name = "Bakery & confectionery products", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Beverages", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Fish & fish products ", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Meat & meat products", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Milk & dairy products", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Other", ParentId = 25, CreateDate = d });
           // context.Sectors.Add(new Sectors { Name = "Sweets & snack food", ParentId = 25, CreateDate = d });

           // context.SaveChanges();

        }
    }
}
