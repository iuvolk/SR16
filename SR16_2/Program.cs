using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SR16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Commodities.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Commodity[] commodities = JsonSerializer.Deserialize<Commodity[]>(jsonString);

            Commodity maxCommodity = commodities[0];
            foreach (Commodity c in commodities)
            {
                if (c.Price > maxCommodity.Price)
                {
                    maxCommodity = c;
                }
            }
            Console.WriteLine($"{maxCommodity.Name}");
            Console.ReadKey();
        }
    }
}
