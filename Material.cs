using System.IO;
using System.Linq;

namespace ConsoleApp5
{
    class Material
    {
        public static Material[] ReadFromCsvFile(string fileName)
        {
            return
            File
            .ReadLines(fileName)
            .Select(x =>
            {
                var array = x.Split(',');
                return new Material
                {
                    Name = array[0],
                    Density = double.Parse(array[1])
                };
            }).ToArray();
        }

        public string Name;
        public double Density;
    }
}
