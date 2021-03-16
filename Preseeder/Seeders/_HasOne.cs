using PreSeeder.Data;
using System;
using System.Collections.Generic;

namespace PreSeeder.Seeders
{
    public partial class Seeder
    {
        private class _HasOne<T, T1> : PreSeedBase where T : class where T1 : class
        {
            public List<T> FromOne { get; set; }
            public List<T1> ToOne { get; set; }
            public AppDbContext AppDbContext { get; }

            public _HasOne(string fromOne, string toOne, AppDbContext appDbContext) : base(appDbContext)
            {
                AppDbContext = appDbContext;
                FromOne = TransformJsonToPoco<T>(fromOne);
                ToOne = TransformJsonToPoco<T1>(toOne);
            }

            public void SetFK(Action<dynamic, dynamic> setRelation)
            {
                var models = new List<T>();
                for (int i = 0; i < FromOne.Count; i++)
                {
                    var from = FromOne[i];
                    var toOne = ToOne[i];
                    setRelation(from, toOne);
                    models.Add(from);
                }
                appDbContext.Set<T>().UpdateRange(models);
                try
                {
                    var res = appDbContext.SaveChangesAsync().Result;
                    Console.WriteLine($"HasOne:{res} rows created .");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Can`t create Records for {typeof(T)} and {typeof(T1)}, Consider droping existing database.");
                }
            }
        }
    }
}