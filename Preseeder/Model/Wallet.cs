using System.ComponentModel.DataAnnotations.Schema;

namespace PreSeeder
{
    public class Wallet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int Balance { get; set; }
        public string Currency { get; set; }

        public string StudentId { get; set; }
        public Student Owner { get; set; }
    }
}