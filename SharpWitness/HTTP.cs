using System.Net;
using System.Text.RegularExpressions;

namespace SharpWitness
{
    public class HTTP
    {

    public static string MakeRequest(string url, string agent)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", agent);

            return client.DownloadString(url);
        }

        public static string GetTitle(string content)
        {
            return Regex.Match(content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
    }
}
