using System;
using System.Net;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace SharpWitness
{
    public class HTTP
    {
        public static string GetContent(string url)
        {
            WebClient client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            return client.DownloadString(url);
        }

        public static string GetTitle(string content)
        {
            return Regex.Match(content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
    }
}
