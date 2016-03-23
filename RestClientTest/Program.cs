using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.github.com");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("users/stetteh/events", Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // execute the request
            var response = client.Execute<List<Event>>(request);
            List<Event> events = response.Data; // raw content as string

            foreach (var e in events)
            {
                Console.WriteLine($"{e.created_at} {e.repo.name} {e.actor.login}" );
            }

            Console.ReadLine();

        }
    }

        public class Actor
        {
            public int id { get; set; }
            public string login { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string avatar_url { get; set; }
        }

        public class Repo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Author
        {
            public string email { get; set; }
            public string name { get; set; }
        }

        public class Commit
        {
            public string sha { get; set; }
            public Author author { get; set; }
            public string message { get; set; }
            public bool distinct { get; set; }
            public string url { get; set; }
        }

        public class Payload
        {
            public int push_id { get; set; }
            public int size { get; set; }
            public int distinct_size { get; set; }
            public string @ref { get; set; }
            public string head { get; set; }
            public string before { get; set; }
            public List<Commit> commits { get; set; }
        }

        public class Event
        {
            public string id { get; set; }
            public string type { get; set; }
            public Actor actor { get; set; }
            public Repo repo { get; set; }
            public Payload payload { get; set; }
            public bool @public { get; set; }
            public string created_at { get; set; }
        }
}
