using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace SR16_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Commodity[] commodities = new Commodity[n];
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("Введите код");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену");
                double price = Convert.ToDouble(Console.ReadLine());

                commodities[i] = new Commodity() { Code = code, Name = name, Price = price };
            }
            
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(commodities, options);

            using (StreamWriter sw = new StreamWriter("../../../Commodities.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
