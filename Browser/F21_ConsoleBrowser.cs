// source: http://zetcode.com/csharp/readwebpage/
// author: Jan Bodnar
// filename: F21_ConsoleBrowser.cs
// capture date: 09 Dec 2019
// student: Darren Tuggey
// summary: Two simple examples of a way to read in a webpage to the console.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Final_Project.Browser
{
    class F21_ConsoleBrowser
    {
        //static async Task Main(string[] args)
        //{
        //    WebClientBrowser();
        //    await HttpClientBrowser();
        //}

        // Uses HttpClient and asynchronously reads the webpage. The await will stall the method until the GetStringAsync completes.
        static async Task HttpClientBrowser()
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync("http://webcode.me");
            Console.WriteLine(content);
        }
        
        // Uses WebClient to download the content of the webpage. Because it is not async the program will block/freeze until the
        // content is finished downloading.
        static void WebClientBrowser()
        {
            using var client = new WebClient();
            string url = "http://webcode.me";
            string content = client.DownloadString(url);
            Console.WriteLine(content);
        }
    }
}
/*
<!DOCTYPE html>
<html lang = "en" >
< head >
< meta charset="UTF-8">
<meta name = "viewport" content="width=device-width, initial-scale=1.0">
<title>My html page</title>
</head>
<body>

<p>
Today is a beautiful day.We go swimming and fishing.
</p>

<p>
Hello there.How are you?
</p>

</body>
</html>


<!DOCTYPE html>
<html lang = "en" >
< head >
< meta charset= "UTF-8" >
< meta name= "viewport" content= "width=device-width, initial-scale=1.0" >
< title > My html page</title>
</head>
<body>

<p>
Today is a beautiful day.We go swimming and fishing.
</p>

<p>
Hello there. How are you?
</p>

</body>
</html>
*/