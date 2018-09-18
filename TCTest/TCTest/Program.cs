using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using TCTest.Mongo;

namespace TCTest
{
    class Program
    {
        public static List<RawTournament> Tournaments = new List<RawTournament>();

        static void Main(string[] args)
        {
            //StartCrawlerAsync();

            MongoTest.Run();

            Console.ReadLine();
        }

        private static async Task StartCrawlerAsync()
        {
            var url = "https://tennislink.usta.com/tournaments/Draws/PlayerTournamentHistory.aspx?MID=1180177184182182181177178177179";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            string name = htmlDocument.DocumentNode.Descendants("strong").First().InnerText;

            var tournaments = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("CommonBox")).ToList();

            foreach (var t in tournaments)
            {
                var title = t.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("event_title")).First().InnerText;
                var date = t.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("event_date")).First().InnerText;

                RawTournament rawTournament = new RawTournament()
                {
                    Name = title,
                    Date = date,
                    Divisions = new List<RawDivision>(),
                };

                Tournaments.Add(rawTournament);

                var body = t.ChildNodes[0].ChildNodes[1];
                if (body.Name == "tbody")
                {
                    RawDivision currentDivision = null;

                    foreach (var tr in body.ChildNodes)
                    {
                        if (tr.ChildNodes.Count == 0)
                        {
                            continue;
                        }

                        if (tr.ChildNodes.Count == 1)
                        {
                            var td = tr.ChildNodes[0];
                            var text = td.InnerText;
                            RawDivision rawDivision = new RawDivision()
                            {
                                Name = text,
                                Matches = new List<RawMatch>(),
                            };
                            rawTournament.Divisions.Add(rawDivision);

                            currentDivision = rawDivision;
                        }

                        if (tr.ChildNodes.Count == 3)
                        {
                            RawMatch rawMatch = new RawMatch()
                            {
                                Round = tr.ChildNodes[0].InnerText,
                                Result = tr.ChildNodes[1].InnerText,
                                Score = tr.ChildNodes[2].InnerText
                            };

                            if (currentDivision != null)
                            {
                                currentDivision.Matches.Add(rawMatch);
                            }
                        }
                    }
                }

                Console.WriteLine(rawTournament);
            }
        }
    }
}
