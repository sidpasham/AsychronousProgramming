using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPrograming
{
    public class UtilMethods
    {

        public static List<string> GetWebsites()
        {
            List<string> websites = new List<string>();

            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.google.com/");
            websites.Add("https://www.twitter.com/");
            websites.Add("https://www.microsoft.com/");
            websites.Add("https://www.yahoo.com/");
            websites.Add("https://www.gmail.com/");
            websites.Add("https://www.amazon.com/");
            websites.Add("https://www.citrix.com/");

            return websites;
        }

        public List<string> GetWebsiteContentLengthSync()
        {
            var websites = GetWebsites();

            var websitecontents = DownloadDataSync(websites);

            return websitecontents;

        }

        public List<string> DownloadDataSync(List<string> websites)
        {
            List<string> lstwebsiteContent = new List<string>();
            WebClient client = new WebClient();

            foreach (var site in websites)
            {
                var content = client.DownloadString(site);
                lstwebsiteContent.Add($"The String Count for website {site} is {content.Length}");
            }

            return lstwebsiteContent;

        }

        public Task<List<string>> DownloadDataAsync(List<string> websites)
        {
            List<string> lstwebsiteContent = new List<string>();
            WebClient client = new WebClient();

            var tasks = new List<Task<string>>();

            foreach (var site in websites)
            {
                tasks.Add(client.DownloadStringAsync(site);
                var content = client.DownloadString(site);
                lstwebsiteContent.Add($"The String Count for website {site} is {content.Length}");
            }

            return lstwebsiteContent;

        }
    }
}
