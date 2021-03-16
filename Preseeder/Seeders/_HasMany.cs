using PreSeeder.Data;
using System;
using System.Collections.Generic;

namespace PreSeeder.Seeders
{
    public partial class Seeder
    {
        private class _HasMany<T, T1> : PreSeedBase where T : class where T1 : class
        {
            private readonly AppDbContext _appDbContext;
            public List<T> Source { get; set; }
            public List<T1> Relation { get; set; }

            public _HasMany(string one, string many, AppDbContext appDbContext) : base(appDbContext)
            {
                _appDbContext = appDbContext;
                Source = TransformJsonToPoco<T>(one);
                Relation = TransformJsonToPoco<T1>(many);
            }

            public void SetFK(Action<dynamic, dynamic> SetRelation)
            {
                if (Source is null || Relation is null) return;
                int skip = Source.Count / Relation.Count;
                int cursor = 0;
                var models = new List<T>();
                for (var index = 0; index < Source.Count / skip; index++)
                {
                    var entry = Source[index];
                    var temp = new List<T1>();
                    int pos = 0;
                    while (pos < skip)
                    {
                        var foo = Relation[cursor + pos];
                        temp.Add(foo);
                        pos++;
                    }
                    SetRelation(entry, temp);
                    models.Add(entry);
                    cursor += skip;
                }
                _appDbContext.UpdateRange(models);
                var r = _appDbContext.SaveChangesAsync().Result;
                Console.WriteLine($"{r} rows created");
            }
        }
    }
}