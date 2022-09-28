using CreditSuisseTest.Job;
using CreditSuisseTest.Services;
using System;
using System.Collections.Generic;

namespace CreditSuisseTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Process!");
            TradeService service = new TradeService();

            DateTime date = new DateTime(2020,12,11);
         
            List<string> contents = new List<string>();
            contents.Add("2000000 Private 12/29/2025");
            contents.Add("400000 Public 07/01/2020");
            contents.Add("5000000 Public 01/02/2024");
            contents.Add("3000000 Public 10/26/2023");

            TradeJob job = new TradeJob(service, date, 4, contents);
            var ret = job.TraderProcess();

            if(ret != null || ret?.Count > 0)
            {
                foreach (var item in ret)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("End Process!");
        }
    }
}
