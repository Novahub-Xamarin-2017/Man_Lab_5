using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using RestSharp;
using Retrofit.Net;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataCenter = "us17";
            var apiKey = "147a8c5d7fa281cd9a833e63b7f9eb7d-us17";
            var listId = "5008e2e46c";
            //AddEmailToList(dataCenter, apiKey, listId, "vanman3.lqd@gmail.com", "Man", "Nguyen");
            //CreateCampaign(dataCenter, apiKey, listId);
            var campaignId = "4b723e0720";
            //SetContent(dataCenter, apiKey, campaignId);
            SendEmail(dataCenter, apiKey, campaignId);
            Console.ReadKey();

        }

        static void CreateList(string dataCenter, string apiKey)
        {
            var listServices = CreateService<IList>(apiKey, dataCenter);
            var listObject = new
            {
                name = "List",
                contact = new
                {
                    company = "Novahub Studio",
                    address1 = "271",
                    address2 = "Nguyen Van Linh",
                    city = "DN",
                    state = "GA",
                    zip = "01221",
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
            };

            var listRespone = listServices.CreateList(listObject);
            Console.WriteLine(listRespone.ResponseStatus);
        }

        static void AddEmailToList(string dataCenter, string apiKey, string listId, string subscribedEmail, string firstName, string lastName)
        {
            var listServices = CreateService<IList>(apiKey, dataCenter);
            var emailObject = CreateEmailObject(subscribedEmail, firstName, lastName);
            var listResponse = listServices.AddEmailToList(listId, CalculateMd5Hash(subscribedEmail), emailObject);
            Console.WriteLine(listResponse.ResponseStatus);
        }

        static object CreateEmailObject(string email, string firstName, string lastName)
        {
            return new
            {
                email_address = email,
                merge_fields =
                new
                {
                    FNAME = firstName,
                    LNAME = lastName
                },
                status_if_new = "subscribed"
            };
        }

        static void CreateCampaign(string dataCenter, string apiKey, string listId)
        {
            var campaignServices = CreateService<ICampaign>(apiKey, dataCenter);
            var campaignObject = new
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
            };
            var campaignResponse = campaignServices.CreateCampaign(campaignObject);
            Console.WriteLine(campaignResponse.ResponseStatus);
        }

        static void SetContent(string dataCenter, string apiKey, string campaignId)
        {
            var campaignServices = CreateService<ICampaign>(apiKey, dataCenter);
            var contentObject = new
            {
                html = "<p>Hello there.</p>"
            };
            var campaignResponse = campaignServices.SetCampaignContent(campaignId, contentObject);
            Console.WriteLine(campaignResponse.ResponseStatus);
        }

        static void SendEmail(string dataCenter, string apiKey, string campaignId)
        {
            var campaignServices = CreateService<ICampaign>(apiKey, dataCenter);
            var campaignResponse = campaignServices.SendEmail(campaignId);
            Console.WriteLine(campaignResponse.ResponseStatus);
        }

        static string CalculateMd5Hash(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var @byte in hash)
            {
                sb.Append(@byte.ToString("X2"));
            }
            return sb.ToString();
        }

        static T CreateService<T>(string apiKey, string dataCenter) where T : class
        {
            var url = $"https://{dataCenter}.api.mailchimp.com/3.0/";
            var restClient = new RestClient(url);
            restClient.Authenticator = new HttpBasicAuthenticator("username", apiKey);
            var restAdapter = new RestAdapter(restClient);
            return restAdapter.Create<T>();
        }
    }
}
