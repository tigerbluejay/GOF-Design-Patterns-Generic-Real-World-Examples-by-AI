/*
Let's consider a real-world example of the Chain of Responsibility pattern in a logging system. 
The logging system will consist of different loggers (e.g., console logger, file logger, email logger), 
and each logger will have a different threshold level for the messages it can handle. If a message's severity 
level is below the logger's threshold, it will handle the message; otherwise, it will pass the message to 
the next logger in the chain.

Here's how the Chain of Responsibility pattern can be implemented for the logging system in C#:
*/

using System;

// Request class representing the log message
class LogMessage
{
	public string Message { get; }
	public LogLevel Level { get; }

	public LogMessage(string message, LogLevel level)
	{
		Message = message;
		Level = level;
	}
}

// Enum representing log levels
enum LogLevel
{
	Info,
	Warning,
	Error
}

// Abstract logger class
abstract class Logger
{
	protected LogLevel _threshold;
	protected Logger _nextLogger;

	public void SetNextLogger(Logger nextLogger)
	{
		_nextLogger = nextLogger;
	}

	public void Log(LogMessage message)
	{
		if (message.Level >= _threshold)
		{
			WriteMessage(message);
		}

		// Pass the message to the next logger in the chain
		if (_nextLogger != null)
		{
			_nextLogger.Log(message);
		}
	}

	protected abstract void WriteMessage(LogMessage message);
}

// Concrete console logger
class ConsoleLogger : Logger
{
	public ConsoleLogger(LogLevel threshold)
	{
		_threshold = threshold;
	}

	protected override void WriteMessage(LogMessage message)
	{
		Console.WriteLine($"Console Logger [{message.Level}]: {message.Message}");
	}
}

// Concrete file logger
class FileLogger : Logger
{
	private string _filePath;

	public FileLogger(LogLevel threshold, string filePath)
	{
		_threshold = threshold;
		_filePath = filePath;
	}

	protected override void WriteMessage(LogMessage message)
	{
		// Write the message to the specified file
		// For brevity, the file writing logic is omitted in this example.
		// You can use File.WriteAllText or other file-writing mechanisms here.
		Console.WriteLine($"File Logger [{message.Level}]: {_filePath} - {message.Message}");
	}
}

// Concrete email logger
class EmailLogger : Logger
{
	private string _recipient;

	public EmailLogger(LogLevel threshold, string recipient)
	{
		_threshold = threshold;
		_recipient = recipient;
	}

	protected override void WriteMessage(LogMessage message)
	{
		// Send an email to the specified recipient with the log message
		// For brevity, the email sending logic is omitted in this example.
		// You can use SMTP, third-party email libraries, or any other mechanism here.
		Console.WriteLine($"Email Logger [{message.Level}]: {_recipient} - {message.Message}");
	}
}

// Client class
class Client
{
	public static void Main(string[] args)
	{
		// Create the loggers with different thresholds
		Logger consoleLogger = new ConsoleLogger(LogLevel.Info);
		Logger fileLogger = new FileLogger(LogLevel.Warning, "log.txt");
		Logger emailLogger = new EmailLogger(LogLevel.Error, "admin@example.com");

		// Set up the chain of responsibility
		consoleLogger.SetNextLogger(fileLogger);
		fileLogger.SetNextLogger(emailLogger);

		// Simulate logging messages
		LogMessage message1 = new LogMessage("This is an informational message.", LogLevel.Info);
		consoleLogger.Log(message1);

		LogMessage message2 = new LogMessage("This is a warning message.", LogLevel.Warning);
		consoleLogger.Log(message2);

		LogMessage message3 = new LogMessage("This is an error message.", LogLevel.Error);
		consoleLogger.Log(message3);
	}
}

/*
In this example, we have three concrete loggers: ConsoleLogger, FileLogger, and EmailLogger. Each logger has its 
own threshold level, indicating the severity level of messages it can handle. The client creates the loggers 
and sets up the chain of responsibility by linking them together using the SetNextLogger method. When a log message 
is passed to the first logger in the chain using Log, it will either handle the message or pass it to the next 
logger in the chain based on the severity level. As a result, log messages are processed and output accordingly 
to the console, file, and email, depending on their severity levels.
*/