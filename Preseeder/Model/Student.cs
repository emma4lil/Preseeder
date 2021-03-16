using System.ComponentModel.DataAnnotations.Schema;

namespace PreSeeder
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Wallet Wallet { get; set; }

    }
}