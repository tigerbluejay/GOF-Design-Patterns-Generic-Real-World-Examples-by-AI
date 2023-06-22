
/*
 * In this example, the IWebServiceClient interface represents the expected interface by the 
 * client for interacting with a web service. The HttpClient class is a powerful class provided 
 * by the .NET ecosystem for making HTTP requests, but its interface doesn't match the 
 * IWebServiceClient interface. The HttpClientAdapter class implements the IWebServiceClient 
 * interface and internally uses an instance of HttpClient to adapt the interface. 
 * The Get method in the HttpClientAdapter class adapts the call to the GetAsync method of HttpClient 
 * and returns the response content.
 * 
 * The client code creates an instance of the HttpClientAdapter, which internally uses the 
 * HttpClient, and then uses the IWebServiceClient interface to make a GET request to a URL. 
 * The HttpClientAdapter adapts the Get call to the GetAsync method of HttpClient, allowing the 
 * client to work with the HttpClient class through the common IWebServiceClient interface.
 * 
 * By using the Adapter pattern, you can integrate existing classes or components into your 
 * .NET application that have incompatible interfaces, providing a unified interface that matches 
 * your application's requirements.
*/

// Target interface that the client expects
interface IWebServiceClient
{
	Task<string> Get(string url);
}

// Adaptee class with incompatible interface
class HttpClientAdapter : IWebServiceClient
{
	private HttpClient httpClient;

	public HttpClientAdapter()
	{
		httpClient = new HttpClient();
	}

	public async Task<string> Get(string url)
	{
		HttpResponseMessage response = await httpClient.GetAsync(url);
		return await response.Content.ReadAsStringAsync();
	}
}

// Client code
class Program
{
	static async Task Main(string[] args)
	{
		// Create an instance of the HttpClientAdapter
		IWebServiceClient webServiceClient = new HttpClientAdapter();

		// Use the web service client to make a request
		string response = await webServiceClient.Get("https://example.com/api/data");

		Console.WriteLine(response);
	}
}