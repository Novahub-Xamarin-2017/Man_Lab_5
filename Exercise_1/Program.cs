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
            Console.Write("Enter the email to: ");
            var emailTo = Console.ReadLine();
            
            Console.Write("Enter the email content: ");
            var emailContent = Console.ReadLine();

            Send(emailTo, emailContent);
            Console.ReadKey();
        }
       
        static void AddEmailToList(string dataCenter, string apiKey, string listId, string subscribedEmail, string firstName, string lastName)
        {
            var listServices = CreateService<IList>(apiKey, dataCenter);
            var emailObject =
                new
                {
                    email_address = subscribedEmail,
                    merge_fields =
                    new
                    {
                        FNAME = firstName,
                        LNAME = lastName
                    },
                    status_if_new = "subscribed"
                };
            var listResponse = listServices.AddEmailToList(listId, CalculateMd5Hash(subscribedEmail), emailObject);
            Console.WriteLine(listResponse.ResponseStatus);
        }


        static string CreateCampaign(string dataCenter, string apiKey, string listId)
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
            var id = JsonConvert.DeserializeObject<CampaignId>(campaignResponse.Content).Id;
            Console.WriteLine(campaignResponse.ResponseStatus);
            return id;
        }

        static void SetContent(string dataCenter, string apiKey, string campaignId, string content)
        {
            var campaignServices = CreateService<ICampaign>(apiKey, dataCenter);
            var contentObject = new
            {
                html = $"<p>{content}</p>"
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

        static void Send(string emailTo, string content)
        {
            var dataCenter = "us17";
            var apiKey = "147a8c5d7fa281cd9a833e63b7f9eb7d-us17";
            var listId = "5008e2e46c";
            var campaignId = CreateCampaign(dataCenter, apiKey, listId);
            AddEmailToList(dataCenter, apiKey, listId, emailTo, "Man", "Nguyen");
            SetContent(dataCenter, apiKey, campaignId, content);
            SendEmail(dataCenter, apiKey, campaignId);
        }
    }
}
