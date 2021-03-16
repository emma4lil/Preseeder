using PreSeeder.Data;
using System;

namespace PreSeeder.Seeders
{
    public partial class Seeder : PreSeedBase, ISeeder
    {
        public Seeder(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public ISeeder HasMany<T, T1>(string one, string many, Action<dynamic, dynamic> relation) where T : class where T1 : class
        {
            new _HasMany<T, T1>(one, many, appDbContext).SetFK(relation);
            return this;
        }

        public ISeeder HasOne<T, T1>(string FromOne, string ToOne, Action<dynamic, dynamic> relation) where T : class where T1 : class
        {
            new _HasOne<T, T1>(FromOne, ToOne, appDbContext).SetFK(relation);
            return this;
        }
    }
}