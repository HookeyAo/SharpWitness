using System;
using CommandLine;
using System.Drawing;
using System.Collections;
using LukeSkywalker.IPNetwork;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SharpWitness
{
    class Program
    {

        public class Options
        {
            [Option('c', "cidr", Required = true, HelpText = "CIDR of targets to scan, e.g: 10.10.100.0/24")]
            public string Cidr { get; set; }

            [Option('o', "outfile", Required = true, HelpText = "Outfile, e.g: report.html")]
            public string Outfile { get; set; }

            [Option('p', "port", Required = false, HelpText = "Port to scan", Default = 80)]
            public int Port { get; set; }

            [Option('s', "ssl", Required = false, HelpText = "Force SSL", Default = false)]
            public bool SSL { get; set; }

            [Option('u', "useragent", Required = false, HelpText = "UserAgent string", Default = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36")]
            public string UserAgent { get; set; }

        }

        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    string cidr = o.Cidr;
                    string outfile = o.Outfile;
                    int port = o.Port;
                    bool ssl = o.SSL;
                    string useragent = o.UserAgent;
                    string proto;

                    if (ssl == true)
                    {
                        proto = "https";
                    }
                    else
                    {
                        proto = "http";
                    }

                    IPNetwork ipn = IPNetwork.Parse(cidr);
                    IPAddressCollection ips = IPNetwork.ListIPAddress(ipn);

                    Console.WriteLine("Scanning {0} IPs", ips.Count);

                    Hashtable table = DefaultCreds.GetHashTable();

                    string html = null;
                    html += HTML.GetHeader();

                    Parallel.ForEach(ips, ip =>
                    {
                        string url = proto + "://" + ip + ":" + port;
                        string resp = HTTP.MakeRequest(url, useragent);
                        string title = HTTP.GetTitle(resp);
                        Image screenshot = Screenshot.Capture(url);

                        html += HTML.GetTitle(title);
                        html += HTML.GetAddress(url);

                        foreach (DictionaryEntry item in table)
                        {
                            if (title.ToLower().Contains(item.Key.ToString()))
                            {
                                string creds = HTML.GetDefaultCreds(table[item.Key].ToString());
                                html += creds;
                            }
                        }

                        html += HTML.GetImg(Convert.ToBase64String(ImageConverter.ToByteArray(screenshot)));

                    });

                    html += HTML.GetFooter();

                    File.Write(outfile, html);

                });
        }
    }
}
