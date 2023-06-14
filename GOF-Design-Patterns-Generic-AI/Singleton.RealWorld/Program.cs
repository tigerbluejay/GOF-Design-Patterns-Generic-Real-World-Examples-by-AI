using System;

public class Logger
{
	private static Logger instance;
	private static readonly object lockObject = new object();

	private Logger()
	{
		// Private constructor to prevent instantiation outside the class
	}

	public static Logger Instance
	{
		get
		{
			// Double-checked locking for thread safety
			if (instance == null)
			{
				lock (lockObject)
				{
					if (instance == null)
					{
						instance = new Logger();
					}
				}
			}
			return instance;
		}
	}

	public void Log(string message)
	{
		Console.WriteLine($"Logging: {message}");
	}
}

public class Program
{
	public static void Main()
	{
		// Accessing the Singleton Logger instance
		Logger logger1 = Logger.Instance;
		logger1.Log("This is a log message from Logger!");

		// Trying to create another Logger instance will return the same instance
		Logger logger2 = Logger.Instance;
		logger2.Log("This is another log message from Logger!");

		Console.ReadLine();
	}
}