using PreSeeder.Data;
using PreSeeder.Model;
using PreSeeder.Seeders;

namespace PreSeeder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Seeder seeder = new Seeder(new AppDbContext());

            seeder.HasMany<User, Order>("Users.json", "Orders.json", (user, order) => user.Orders = order);
            seeder.HasMany<Order, Product>("Orders.json", "Products.json", (order, product) => order.Products = product);
            seeder.HasOne<Student, Wallet>("Students.json", "Wallets.json", (u, v) => u.Wallet = v);
        }
    }
}