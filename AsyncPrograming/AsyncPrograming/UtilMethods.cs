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

        public List<string> GetWebsiteContentLengthSync(IProgress<ProgressBarModel> progress)
        {
            var websites = GetWebsites();

            List<string> websiteContents = new List<string>();

            ProgressBarModel progressModel = new ProgressBarModel();

            foreach (var site in websites)
            {
                var content = DownloadDataSync(site);
                websiteContents.Add(content);
                progressModel.ProgressPercentage = websiteContents.Count / websites.Count;
                progressModel.ProgressMesssage = $"Processing Files {site}";
            }
            return websiteContents;
        }

        public List<string> GetWebsiteContentLengthParallelSync()
        {
            var websites = GetWebsites();
            List<string> websiteContents = new List<string>();

            Parallel.ForEach<string>(websites, (site) =>
            {
                var content = DownloadDataSync(site);
                websiteContents.Add(content);
            });

            return websiteContents;
        }

        public async Task<List<string>> GetWebsiteContentLengthAsync()
        {
            var websites = GetWebsites();

            List<string> websiteContents = new List<string>();

            foreach (var site in websites)
            {
                var content = await DownloadDataAsync(site);
                websiteContents.Add(content);

            }
            return websiteContents;
        }

        public async Task<List<string>> GetWebsiteContentLengthParallelAsync()
        {
            var websites = GetWebsites();
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var site in websites)
            {
                var content = DownloadDataAsync(site);
                tasks.Add(content);
            }

            var websiteContents = await Task.WhenAll(tasks);

            return new List<string>(websiteContents);
        }

        public async Task<List<string>> GetWebsiteContentLengthParallelAsync_V2()
        {
            var websites = GetWebsites();
            List<string> websiteContents = new List<string>();

            await Task.Run(() =>
            {
                Parallel.ForEach<string>(websites, (site) =>
                {
                    var content = DownloadDataSync(site);
                    websiteContents.Add(content);
                });
            });           

            return websiteContents;
        }

        public string DownloadDataSync(string website)
        {
            string websitecontent = "";
            WebClient client = new WebClient();

            var content = client.DownloadString(website);

            websitecontent = ($"The String Count for website {website} is {content.Length}");

            return websitecontent;

        }

        public async Task<string> DownloadDataAsync(string website)
        {
            string websitecontent = "";
            WebClient client = new WebClient();

            var content = await client.DownloadStringTaskAsync(website);

            websitecontent = ($"The String Count for website {website} is {content.Length}");

            return websitecontent;

        }
    }
}
