using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JSONDemo
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/typicode/demo/posts";

            //an Http client to send the GET request
            HttpClient httpClient = new HttpClient();

            try
            {
           
                var httpResponseMessage = await httpClient.GetAsync(url);
                //read the string from the response content
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //Print the JsonResponse
                Console.WriteLine(jsonResponse);

                //Deserialize the json response in c# array of type Post[]
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                foreach (var post in myPosts)
                {
                    Console.WriteLine($"{post.id}{post.Title}");

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                httpClient.Dispose();   
            }
        }
    }
}
