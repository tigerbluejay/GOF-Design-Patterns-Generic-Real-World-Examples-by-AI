using System;

// Abstract base class defining the template method and the abstract steps
abstract class RequestPipeline
{
	public void Execute(HttpContext context)
	{
		PreProcess(context);
		ProcessRequest(context);
		PostProcess(context);
	}

	protected virtual void PreProcess(HttpContext context)
	{
		Console.WriteLine("Performing pre-processing tasks...");
	}

	protected abstract void ProcessRequest(HttpContext context);

	protected virtual void PostProcess(HttpContext context)
	{
		Console.WriteLine("Performing post-processing tasks...");
	}
}

// Concrete implementation of the RequestPipeline
class MyRequestPipeline : RequestPipeline
{
	protected override void ProcessRequest(HttpContext context)
	{
		Console.WriteLine("Executing custom request processing logic...");
		// Perform additional request processing tasks specific to the application
	}
}

// HttpContext class (simplified for illustration purposes)
class HttpContext
{
	public string RequestUrl { get; set; }
	public string Response { get; set; }
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		// Simulating an incoming HTTP request
		HttpContext context = new HttpContext
		{
			RequestUrl = "/home"
		};

		// Instantiate the custom request pipeline and execute the request
		RequestPipeline pipeline = new MyRequestPipeline();
		pipeline.Execute(context);
	}
}

/*
 * In this example, the RequestPipeline class represents the abstract base class that defines the 
 * template method for handling incoming HTTP requests. The template method, Execute, follows a 
 * common sequence of steps, including pre-processing, processing the request, and post-processing.
 * 
 * The PreProcess and PostProcess methods provide default implementations, which can be overridden 
 * by derived classes if necessary. The ProcessRequest method is an abstract method, which forces
 * derived classes to provide their own implementation of the request processing logic.
 * 
 * The MyRequestPipeline class is a concrete implementation of the RequestPipeline class, which 
 * specializes in executing custom request processing logic. It overrides the ProcessRequest method 
 * to provide the application-specific processing tasks.
 * 
 * The HttpContext class represents the context of an incoming HTTP request and response. 
 * It holds properties such as RequestUrl and Response, which can be utilized within the request 
 * pipeline.
 * 
 * In the client code, we simulate an incoming HTTP request by creating an instance of HttpContext
 * and setting its properties. Then, we instantiate the custom request pipeline (MyRequestPipeline) 
 * and execute the request using the Execute method.
 * 
 * This example demonstrates how the Template Method pattern can be applied in the context of 
 * developing a web application framework, specifically the request pipeline. It allows for the 
 * common steps to be defined in the base class, with specific steps and custom logic implemented in 
 * derived classes.
*/