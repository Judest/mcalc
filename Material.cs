using System.IO;
using System.Linq;

namespace ConsoleApp5
{
    class Material
    {
        public static Material[] GetList()
        {
            var fileName = "materials";

            // if file does not exists, return default list
            if (!File.Exists(fileName))
            {
                return new[]
                {
                    new Material{ Name = "Алюминий", Density = 2.7 },
                    new Material{ Name = "Медь", Density = 8.9 },
                };
            }

            return File
            .ReadLines(fileName)
            .Select(x =>
            {
                var array = x.Split(' ');
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
