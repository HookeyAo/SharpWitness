using System;
using CommandLine;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;

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

                    string htmlHeader = HTML.GetHeader();
                    File.Write(o.Outfile, htmlHeader);

                    Hashtable hashtable = DefaultCreds.GetHashTable();

                foreach (string url in urls)
                {
                        string htmlContent = HTTP.GetContent(url);
                        string htmlTitle = HTTP.GetTitle(htmlContent);

                        string html;

                        Image image = Screenshot.Capture(url);
                        string b64 = Convert.ToBase64String(ImageConverter.ToByteArray(image));

                        string title = HTML.GetTitle(htmlTitle);
                        string address = HTML.GetAddress(url);

                        html = title + address;

                        foreach (DictionaryEntry item in hashtable)
                        {
                            if (htmlTitle.ToLower().Contains(item.Key.ToString()))
                            {
                                string creds = HTML.GetDefaultCreds(hashtable[item.Key].ToString());
                                html += creds;
                            }
                        }

                        string b64image = HTML.GetImg(b64);
                        html += b64image;

                        File.Write(o.Outfile, html);
                }

                    string htmlFooter = HTML.GetFooter();
                    File.Write(o.Outfile, htmlFooter);

                });
        }
    }
}
