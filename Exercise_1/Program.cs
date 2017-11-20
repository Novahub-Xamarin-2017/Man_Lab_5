using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static string CreateList(string dataCenter, string apiKey)
        {
            var sampleList = JsonConvert.SerializeObject(
                new
                {
                    name = "sample List",
                    contact = new
                    {
                        company = "Xamarin Org",
                        address1 = "Da Nang",
                        address2 = "Da Nang",
                        city = "DN",
                        state = "GA",
                        zip = "01203021",
                        country = "VI",
                        phone = ""
                    },
                    permission_reminder = "Remind something...",
                    campaign_defaults = new
                    {
                        from_name = "Man",
                        from_email = "vanman.lqd@gmail.com",
                        subject = "MailChimp Demo",
                        language = "en",
                    },
                    email_type_option = true
                }
            );
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/lists");

            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Accept", "application/json");
                    webClient.Headers.Add("Authorization", "apikey " + apiKey);

                    return webClient.UploadString(uri, "POST", sampleList);
                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static string GetLists(string dataCenter, string apiKey, string listId = "")
        {
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/lists/{listId}");
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Accept", "application/json");
                    webClient.Headers.Add("Authorization", $"apikey {apiKey}");
                    return webClient.DownloadString(uri);
                }

            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static string AddOrUpdateListMember(string dataCenter, string apiKey, string listId, string subscriberEmail)
        {
            var sampleListMember = JsonConvert.SerializeObject(
                new
                {
                    email_address = subscriberEmail,
                    merge_fields =
                    new
                    {
                        FNAME = "Foo",
                        LNAME = "Bar"
                    },
                    status_if_new = "subscribed"
                });

            var hashedEmailAddress = string.IsNullOrEmpty(subscriberEmail) ? "" : CalculateMd5Hash(subscriberEmail.ToLower());
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/lists/{listId}/members/{hashedEmailAddress}");
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Accept", "application/json");
                    webClient.Headers.Add("Authorization", "apikey " + apiKey);

                    return webClient.UploadString(uri, "PUT", sampleListMember);
                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        static string CreateCampaign(string dataCenter, string apiKey, string listId)
        {
            var campaign = JsonConvert.SerializeObject(new
            {
                recipients = new
                {
                    list_id = listId
                },
                type = "regular",
                settings = new
                {
                    subject_line = "Test send email",
                    reply_to = "vanman.lqd@gmail.com",
                    from_name = "Man"
                }
            });
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/campaigns");
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("content-type", "application/json");
                    webClient.Headers.Add("Authorization", "apikey " + apiKey);

                    return webClient.UploadString(uri, "POST", campaign);

                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static string SetContent(string dataCenter, string apiKey, string campaignId)
        {
            var content = JsonConvert.SerializeObject(new
            {
                html = "<p>Hello there.</p>"
            });
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/campaigns/{campaignId}/content");
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("content-type", "application/json");
                    webClient.Headers.Add("Authorization", $"apikey {apiKey}");

                    return webClient.UploadString(uri, "PUT", content);

                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static string SendEmail(string dataCenter, string apiKey, string campaignId)
        {
            var content = JsonConvert.SerializeObject(new
            {

            });
            var uri = string.Format($"https://{dataCenter}.api.mailchimp.com/3.0/campaigns/{campaignId}/actions/send");
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("content-type", "application/json");
                    webClient.Headers.Add("Authorization", "apikey " + apiKey);

                    return webClient.UploadString(uri, "POST", content);

                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        static string CalculateMd5Hash(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var @byte in hash)
            {
                sb.Append(@byte.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
