using Newtonsoft.Json;
using PreSeeder.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PreSeeder.Seeders
{
    public abstract class PreSeedBase
    {
        internal readonly AppDbContext appDbContext;

        public PreSeedBase(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public List<TModel> TransformJsonToPoco<TModel>(string json) where TModel : class
        {
            try
            {
                if (appDbContext.Set<TModel>().Any())
                {
                    Console.WriteLine($"Your database contains instances of {typeof(TModel)}, Using Models from Db");
                    return appDbContext.Set<TModel>().ToList();
                }
                List<TModel> lists = JsonConvert.DeserializeObject<List<TModel>>(File.ReadAllText(Path.GetFullPath(@"../../../Data/" + json)));
                return lists;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Is Model Added to DBset in DbContext class?");
                return null;
            }
        }
    }
}