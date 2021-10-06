using GitGrabber.Models;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubRepo {
        //TODO: Add Exception Handler
        public GithubRepo GrabObject(string target) {
            try {
                string result = string.Empty;
                string url = target;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                // [Added Headers to enable api usage]
                request.Headers.Add("Accept", "application/vnd.github.v3+json"); 
                request.Headers.Add("User-Agent", "request");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<GithubRepo>(result);
            }
            catch(Exception e){
                return new GithubRepo() {
                    name = e + ""
                };
            }
        }
    }
}