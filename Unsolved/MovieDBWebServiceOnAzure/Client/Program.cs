using System;
using System.Collections.Generic;
using MovieDBWebService;
// ReSharper disable UnusedParameter.Local

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Web API calls...");
            Console.WriteLine("(App can be closed by pressing any key.)");
            Console.WriteLine();

            Run();

            Console.ReadKey();
        }

        static async void Run()
        {
            Console.WriteLine("Starting Web API test...");
            Console.WriteLine();

            // Replace the URL below with the URL for your own Web Service
            const string serverURL = "http://moviedbwebserviceperl.azurewebsites.net";

            const string movieURI = "Movies";
            const string studioURI = "Studios";
            const string apiPrefix = "api";

            WebAPI<Movie> movieWebApi = new WebAPI<Movie>(serverURL, apiPrefix, movieURI);
            WebAPI<Studio> studioWebApi = new WebAPI<Studio>(serverURL, apiPrefix, studioURI);

            List<Movie> movies = await movieWebApi.Load();
            List<Studio> studios = await studioWebApi.Load();

            Console.WriteLine();
            Console.WriteLine("Movies retrieved from Web Service");
            foreach (Movie m in movies)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();
            Console.WriteLine("Studios retrieved from Web Service");
            foreach (Studio s in studios)
            {
                Console.WriteLine(s);
            }
        }
    }
}
