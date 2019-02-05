using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpWitness
{
    public class File
    {
        public static string[] Read(string file)
        {
            string[] lines;

            var list = new List<string>();
            var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();
            return lines;
        }

        public static void Write(string file, string data)
        {
            var fileStream = new FileStream(file, FileMode.Append, FileAccess.Write);
            using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamWriter.Write(data);
            }
        }
    }
}
