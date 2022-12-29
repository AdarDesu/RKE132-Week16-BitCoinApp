using Newtonsoft.Json;
using System.Net;
using Week16;

BitCoinRate BitCoin = GetRates();
Console.WriteLine($"Current BitCoin rate is {BitCoin.bpi.EUR.rate_float} {BitCoin.bpi.EUR.code}. " +
    $"It was updated in {BitCoin.time.updated}.");


static BitCoinRate GetRates()
{
    string Url = "https://api.coindesk.com/v1/bpi/currentprice.json";

    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
    Request.Method = "GET";

    var WebResponse = Request.GetResponse();
    var WebStream = WebResponse.GetResponseStream();

    BitCoinRate BitcoinRate;

    using (var ResponseReader = new StreamReader(WebStream))
    {
        var Response = ResponseReader.ReadToEnd();

        BitcoinRate = JsonConvert.DeserializeObject<BitCoinRate>(Response);
    }

    return BitcoinRate;

}