/*
Let's consider a real-world example of the Chain of Responsibility pattern in the context of a 
.NET application for handling different types of authentication methods. We'll create a chain of 
authentication handlers, each capable of handling a specific type of authentication. If one handler 
cannot handle the authentication, it will pass the request to the next handler in the chain until 
the authentication is successful or the end of the chain is reached.

Assuming we have three authentication methods: API key, username/password, and social login 
(e.g., Google, Facebook). The goal is to find a valid user based on the provided credentials.

Here's how the Chain of Responsibility pattern can be implemented for the authentication system in C#:
*/

using System;

// Request class representing the authentication credentials
class AuthRequest
{
	public string Method { get; }
	public string Credentials { get; }

	public AuthRequest(string method, string credentials)
	{
		Method = method;
		Credentials = credentials;
	}
}

// Abstract authentication handler class
abstract class AuthHandler
{
	protected AuthHandler _nextHandler;

	public void SetNextHandler(AuthHandler nextHandler)
	{
		_nextHandler = nextHandler;
	}

	public virtual bool Authenticate(AuthRequest request)
	{
		if (CanHandle(request))
		{
			return HandleAuthentication(request);
		}

		// Pass the request to the next handler in the chain
		if (_nextHandler != null)
		{
			return _nextHandler.Authenticate(request);
		}

		// If the end of the chain is reached, return false (authentication failed)
		return false;
	}

	protected abstract bool CanHandle(AuthRequest request);
	protected abstract bool HandleAuthentication(AuthRequest request);
}

// Concrete API key authentication handler
class ApiKeyAuthHandler : AuthHandler
{
	private readonly string _validApiKey = "myApiKey";

	protected override bool CanHandle(AuthRequest request)
	{
		return request.Method == "API_KEY";
	}

	protected override bool HandleAuthentication(AuthRequest request)
	{
		if (request.Credentials == _validApiKey)
		{
			Console.WriteLine("API Key authentication successful.");
			return true;
		}

		Console.WriteLine("API Key authentication failed.");
		return false;
	}
}

// Concrete username/password authentication handler
class UsernamePasswordAuthHandler : AuthHandler
{
	private readonly string _validUsername = "john";
	private readonly string _validPassword = "password123";

	protected override bool CanHandle(AuthRequest request)
	{
		return request.Method == "USERNAME_PASSWORD";
	}

	protected override bool HandleAuthentication(AuthRequest request)
	{
		var credentials = request.Credentials.Split(':');
		if (credentials.Length == 2 && credentials[0] == _validUsername && credentials[1] == _validPassword)
		{
			Console.WriteLine("Username/Password authentication successful.");
			return true;
		}

		Console.WriteLine("Username/Password authentication failed.");
		return false;
	}
}

// Concrete social login authentication handler
class SocialLoginAuthHandler : AuthHandler
{
	private readonly string _validSocialToken = "googleToken";

	protected override bool CanHandle(AuthRequest request)
	{
		return request.Method == "SOCIAL_LOGIN";
	}

	protected override bool HandleAuthentication(AuthRequest request)
	{
		if (request.Credentials == _validSocialToken)
		{
			Console.WriteLine("Social login authentication successful.");
			return true;
		}

		Console.WriteLine("Social login authentication failed.");
		return false;
	}
}

// Client class
class Program
{
	static void Main(string[] args)
	{
		// Create the authentication handlers
		AuthHandler apiKeyHandler = new ApiKeyAuthHandler();
		AuthHandler usernamePasswordHandler = new UsernamePasswordAuthHandler();
		AuthHandler socialLoginHandler = new SocialLoginAuthHandler();

		// Set up the chain of responsibility
		apiKeyHandler.SetNextHandler(usernamePasswordHandler);
		usernamePasswordHandler.SetNextHandler(socialLoginHandler);

		// Simulate authentication requests
		AuthRequest request1 = new AuthRequest("API_KEY", "invalidApiKey");
		bool isAuthenticated1 = apiKeyHandler.Authenticate(request1);
		Console.WriteLine("Authentication Result: " + isAuthenticated1);

		AuthRequest request2 = new AuthRequest("USERNAME_PASSWORD", "john:password123");
		bool isAuthenticated2 = apiKeyHandler.Authenticate(request2);
		Console.WriteLine("Authentication Result: " + isAuthenticated2);

		AuthRequest request3 = new AuthRequest("SOCIAL_LOGIN", "invalidSocialToken");
		bool isAuthenticated3 = apiKeyHandler.Authenticate(request3);
		Console.WriteLine("Authentication Result: " + isAuthenticated3);

		AuthRequest request4 = new AuthRequest("SOCIAL_LOGIN", "googleToken");
		bool isAuthenticated4 = apiKeyHandler.Authenticate(request4);
		Console.WriteLine("Authentication Result: " + isAuthenticated4);
	}
}

/*
In this example, we have three concrete authentication handlers: ApiKeyAuthHandler, UsernamePasswordAuthHandler,
and SocialLoginAuthHandler. Each handler can handle a specific authentication method and has its own logic to 
check the validity of the credentials. The client creates the authentication handlers and sets up the chain 
of responsibility by linking them together using the SetNextHandler method. When an authentication request is 
passed to the first handler in the chain using Authenticate, it will either handle the request or pass it to 
the next handler in the chain based on the authentication method. As a result, the system can successfully 
authenticate users using different methods, and the authentication process is flexible and easily extendable 
with new handlers for other authentication methods.
*/