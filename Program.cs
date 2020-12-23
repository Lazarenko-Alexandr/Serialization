using System;
using System.Threading.Tasks;

namespace conversions
{
    class Program
    {
        static async Task Main()
        {
            var samples = new IRun[]
            {
                new Xml(),
                new Json(),
                new Yaml(),
                new Toml(),

                //new JsonSimple(),
                //new JsonNet(),
                //new Csv()
            };

            var friend = new Friend
            {
                Id = 1,
                Age = 23,
                Name = "Lazarenko Alexandr"
            };

            foreach (var sample in samples)
            {
                Console.WriteLine($"{sample.Name}:");
                await sample.RunAsync(friend);
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
    }
    
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime Met { get; set; }
        public decimal Age { get; set; }
    }
}
