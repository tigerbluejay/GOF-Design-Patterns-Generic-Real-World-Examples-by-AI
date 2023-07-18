/*
Let's imagine a chat application where multiple users can communicate with each other. 
The Mediator pattern can be used to handle the communication between users without 
directly coupling them. Here's how it can be implemented:
*/

using System;
using System.Collections.Generic;

// Mediator interface
public interface IChatMediator
{
	void SendMessage(string message, IUser user);
	void AddUser(IUser user);
}

// Concrete Mediator
public class ChatMediator : IChatMediator
{
	private List<IUser> users;

	public ChatMediator()
	{
		users = new List<IUser>();
	}

	public void AddUser(IUser user)
	{
		users.Add(user);
	}

	public void SendMessage(string message, IUser sender)
	{
		foreach (var user in users)
		{
			if (user != sender)
			{
				user.ReceiveMessage(message);
			}
		}
	}
}

// User interface
public interface IUser
{
	void SendMessage(string message);
	void ReceiveMessage(string message);
}

// Concrete User
public class ChatUser : IUser
{
	private string name;
	private IChatMediator mediator;

	public ChatUser(string name, IChatMediator mediator)
	{
		this.name = name;
		this.mediator = mediator;
	}

	public void SendMessage(string message)
	{
		Console.WriteLine($"{name} sends message: {message}");
		mediator.SendMessage(message, this);
	}

	public void ReceiveMessage(string message)
	{
		Console.WriteLine($"{name} receives message: {message}");
	}
}

// Usage
public class Program
{
	public static void Main(string[] args)
	{
		// Create chat mediator
		var chatMediator = new ChatMediator();

		// Create chat users and register them with the mediator
		var user1 = new ChatUser("John", chatMediator);
		var user2 = new ChatUser("Alice", chatMediator);
		var user3 = new ChatUser("Bob", chatMediator);
		chatMediator.AddUser(user1);
		chatMediator.AddUser(user2);
		chatMediator.AddUser(user3);

		// Communication between users happens through the mediator
		user1.SendMessage("Hello, everyone!");
		user2.SendMessage("Hi, John!");
		user3.SendMessage("Hey, Alice!");

		// Output:
		// John sends message: Hello, everyone!
		// Alice receives message: Hello, everyone!
		// Bob receives message: Hello, everyone!
		// Alice sends message: Hi, John!
		// John receives message: Hi, John!
		// Bob receives message: Hi, John!
		// Bob sends message: Hey, Alice!
		// John receives message: Hey, Alice!
		// Alice receives message: Hey, Alice!
	}
}
/* 
In this example, we have a ChatMediator class that implements the IChatMediator interface. 
It maintains a list of users and provides methods to add users and send messages.

The ChatUser class represents a user in the chat application and implements the IUser interface.
Each user has a name and a reference to the mediator. The SendMessage method is used to send a 
message through the mediator, and the ReceiveMessage method is used to receive messages from 
other users.

In the Main method, we create a chat mediator and several chat users. We register the users with 
the mediator and demonstrate how they can communicate with each other through the mediator.

When you run the program, you'll see the output that shows the messages being sent and received 
by the users.
*/
