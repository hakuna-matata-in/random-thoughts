using RestSharp;
var flag = true;
while (flag)
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Enter excel file url :");
    string url = Console.ReadLine() ?? "";
    DownloadFile(url);
    Console.WriteLine("Press 0 to exit the application or other keys to continue.");
    string input = Console.ReadLine() ?? "";
    if (input == "0")
        flag = false;
}

static void DownloadFile(string url)
{
    var request = new RestRequest(url);
    var client = new RestClient();
    request.AddHeader("accept", "application/vnd.ms-excel");
    try
    {
        var response = client.DownloadData(request);
        if (response != null)
        {
            File.WriteAllBytes($"C:\\Users\\Public\\Documents\\{DateTime.Now.Ticks}.xls", response);
            Console.WriteLine("Successfully downloaded");
        }
        else
        {
            Console.WriteLine($"Download failed");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Download failed.Exception {e.Message}");
    }
}