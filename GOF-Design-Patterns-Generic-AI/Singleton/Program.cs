/* SINGLETON */
/* 
 * In this example, the Singleton class has a private constructor, preventing the direct instantiation 
 * of the class from outside.The static property Instance provides the global point of access to the 
 * single instance of the class. It uses double-checked locking for thread safety to ensure that only 
 * one instance is created even in a multi-threaded environment.
 * 
 * In the Main method, we demonstrate the usage of the Singleton class by accessing the instance 
 * through Singleton.Instance. Both singleton1 and singleton2 refer to the same instance, as confirmed 
 * by the output of the DisplayMessage method.
 * 
 * Note that this example focuses on the implementation of the Singleton design pattern itself and is 
 * not specific to the .NET MVC 6 framework.
*/
using System;

public class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();
    
    private Singleton()
    {
        // Private constructor to prevent instantiation outside the class
    }

    public static Singleton Instance
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
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine($"Singleton says: {message}");
    }
}

public class Program
{
    public static void Main()
    {
        // Accessing the Singleton instance
        Singleton singleton1 = Singleton.Instance;
        singleton1.DisplayMessage("Hello from Singleton!");

        // Trying to create another instance will return the same instance
        Singleton singleton2 = Singleton.Instance;
        singleton2.DisplayMessage("This is still the same Singleton instance!");

        Console.ReadLine();
    }
}

/*
 * On subsequent calls to Singleton.Instance, the instance is no longer null, so the existing 
 * instance is returned instead of creating a new one.
 */

/*
 * The use of the lock statement ensures that only one thread can create an instance of the 
 * Singleton class at a time. Other threads that concurrently reach this code block will be 
 * blocked and wait until the lock is released by the first thread before proceeding.
 */

