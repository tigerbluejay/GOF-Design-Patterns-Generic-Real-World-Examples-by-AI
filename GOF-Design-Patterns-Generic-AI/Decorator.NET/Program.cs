using System;

// The base logger interface
public interface ILogger
{
	void Log(string message);
}

// The concrete logger implementation
public class Logger : ILogger
{
	public void Log(string message)
	{
		Console.WriteLine("Logging to console: " + message);
	}
}

// Base decorator class
public abstract class LoggerDecorator : ILogger
{
	protected ILogger logger;

	public LoggerDecorator(ILogger logger)
	{
		this.logger = logger;
	}

	public virtual void Log(string message)
	{
		logger.Log(message);
	}
}

// Concrete decorator for logging to a file
public class FileLoggerDecorator : LoggerDecorator
{
	public FileLoggerDecorator(ILogger logger) : base(logger)
	{
	}

	public override void Log(string message)
	{
		base.Log(message);
		LogToFile(message);
	}

	private void LogToFile(string message)
	{
		// Code to log the message to a file
		Console.WriteLine("Logging to file: " + message);
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Create the base logger
		ILogger logger = new Logger();

		// Decorate the logger with additional functionality
		logger = new FileLoggerDecorator(logger);

		// Log messages
		logger.Log("Message 1");
		logger.Log("Message 2");
	}
}