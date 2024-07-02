
using Northwind.Access.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace M009_OData
{
    public static class ODataConfiguration
    {
        public static void AddOData(this IMvcBuilder builder)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Category>(nameof(Category) + "s");
            modelBuilder.EntitySet<Customer>(nameof(Customer) + "s");
            modelBuilder.EntitySet<CustomerDemographic>(nameof(CustomerDemographic) + "s");
            modelBuilder.EntitySet<Employee>(nameof(Employee) + "s");

            modelBuilder.EntitySet<Order>(nameof(Order) + "s");
            modelBuilder.EntityType<Order>().HasRequired(o => o.Customer);
            modelBuilder.EntityType<Order>().HasRequired(o => o.Employee);

            modelBuilder.EntitySet<OrderDetail>(nameof(OrderDetail) + "s");
            modelBuilder.EntitySet<Product>(nameof(Product) + "s");
            modelBuilder.EntitySet<Region>(nameof(Region) + "s");
            modelBuilder.EntitySet<Shipper>(nameof(Shipper) + "s");
            modelBuilder.EntitySet<Supplier>(nameof(Supplier) + "s");
            modelBuilder.EntitySet<Territory>(nameof(Territory) + "s");


            builder.AddOData(opt => opt
                    .Select()
                    .Filter()
                    .OrderBy()
                    .Expand()
                    .Count()
                    .SetMaxTop(20)
                    .AddRouteComponents("odata", modelBuilder.GetEdmModel())
                );
        }
    }
}
