namespace SharpWitness
{
    public class HTML
    {
        public static string GetHeader()
        {
            return @"
<html>
<body>
<h1>SharpWitness</h2>
<br /><br />
";
        }

        public static string Generate(string url, string title, string b64img)
        {
            string html = @"
<b>Title:</b> TITLE <br />
<b>Address:</b> URL <br />
<img src='data: image / png; base64,B64IMG' />
<br /><br />
";

            html = html.Replace("URL", url);
            html = html.Replace("TITLE", title);
            html = html.Replace("B64IMG", b64img);

            return html;

        }

        public static string GetFooter()
        {
            return @"
</body>
</html>
";
        }
    }
}
