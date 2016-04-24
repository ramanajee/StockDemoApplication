using StockDemo.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StockDemo
{
    public class StockBLL
    {
        #region Private Methods
        private IList<StockInfo> list;
        private BaseRepository<StockInfo> repo = null;
        private IList<StockInfo> GetALl()
        {
            var fileName = @"c:\users\ram\documents\visual studio 2015\Projects\StockDemo\companylist.csv";

            var list = (from line in File.ReadAllLines(fileName)
                               let columns = line.Split(',')
                               select new StockInfo
                               {
                                   Symbol = columns[0].Clean(),
                                   Name = columns[1].Clean(),
                                   LastSale = columns[2].Clean(),
                                   MarketCap = columns[3].Clean(),
                                   IPOyear = columns[4].Clean(),
                                   Sector = columns[5].Clean(),
                                   Industry = columns[6].Clean(),
                                   SummaryQuote = columns[7].Clean()
                               }).ToList();
            var repo = new BaseRepository<StockInfo>(list);

            return repo.GetAll();
        }
        #endregion Private Methods
        public StockBLL()
        {
            list = GetALl();
            repo = new BaseRepository<StockInfo>(list);
        }
        public IList<StockInfo> Get()
        {
            return list;
        }
        public IList<StockInfo> Get(string symbol)
        {
            var data = repo.Get(_ => _.Symbol.ToLower() == symbol.ToLower()).ToList();
            return data;
        }

        public void PrintTop10()
        {
            foreach (var company in list.Take(20))
            {
                Console.WriteLine("\n"+company.Symbol + " " + company.Name + " " + company.Sector + " " + company.SummaryQuote);
            }
        }
        public void LiveStock(string symbol)
        {
            var data = Get(symbol);
            if (data.Count==0)
            {
                Console.WriteLine("Current Sybmol not found in our list");
                Environment.Exit(0);
            }

            HttpClient client = new HttpClient();
            var s = client.GetStringAsync(ConfigurationManager.AppSettings["Stock.API"] + symbol).Result;
            Console.WriteLine(s);
            JavaScriptSerializer javascript = new JavaScriptSerializer();
            var final = javascript.Deserialize<dynamic>(s);

        }
    }
}
