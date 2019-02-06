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

        public static string GetTitle(string title)
        {
            string html = @"
<b>Title:</b> TITLE <br />
";
            html = html.Replace("TITLE", title);
            return html;
        }

        public static string GetAddress(string url)
        {
            string html = @"
<b>Address:</b> URL <br />
";
            html = html.Replace("URL", url);
            return html;
        }

        public static string GetDefaultCreds(string creds)
        {
            string html = @"
<b>Default Creds:</b> CREDZ <br />
";
            html = html.Replace("CREDZ", creds);
            return html;
        }

        public static string GetImg(string b64img)
        {
            string html = @"
<br /> <img src='data: image / png; base64,B64IMG' /> <br /><br />
";            
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
