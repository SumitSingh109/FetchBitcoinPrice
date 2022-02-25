using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace FetchBitcoinPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //send http request to fetch the value
            HttpWebRequest request = WebRequest.Create("https://api.coindesk.com/v1/bpi/currentprice.json") as HttpWebRequest;

            // store the respose
            string jsonValue = ""; 

            //recieve the response from the API
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)  
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            //Initialize class to store the response
            BitcoinPrice result = JsonConvert.DeserializeObject<BitcoinPrice>(jsonValue);
            
            //Print the current rate of the bitcoin
            Console.Write("The current price of Bitcoin in Europe is:" + result.bpi.EUR.rate);
            Console.ReadKey();
         
        }
    }
}
    