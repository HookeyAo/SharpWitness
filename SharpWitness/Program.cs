using System;
using CommandLine;
using System.Drawing;

namespace SharpWitness
{
    class Program
    {

        public class Options
        {
            [Option('t', "targets", Required = true, HelpText = "Text file containing targets to scan, e.g: urls.txt")]
            public string Targets { get; set; }

            [Option('o', "outfile", Required = true, HelpText = "Outfile, e.g: report.html")]
            public string Outfile { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                string[] urls = File.Read(o.Targets);

                foreach (string url in urls)
                {
                        Image image = Screenshot.Capture(url);
                        string b64 = Convert.ToBase64String(ImageConverter.ToByteArray(image));
                        string html = HTML.Generate(url, b64);
                        File.Write(o.Outfile, html);
                }

                });
        }
    }
}
