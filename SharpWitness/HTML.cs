using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpWitness
{
    public class HTML
    {
        public static string Generate(string url, string b64img)
        {
            string html = @"
<html>
<body>
<h1>URL</h1>
<img src='data: image / png; base64,B64IMG' />
</body>
</html>
";

            html = html.Replace("URL", url);
            html = html.Replace("B64IMG", b64img);

            return html;

        }
    }
}
