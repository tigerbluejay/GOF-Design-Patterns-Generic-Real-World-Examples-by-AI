using System;
using System.Xml.Linq;

// Prototype interface
public interface ICloneableItem
{
	ICloneableItem Clone();
	void Display();
}

// Concrete prototype - Book
public class Book : ICloneableItem
{
	public string Title { get; set; }
	public string Author { get; set; }

	public Book(string title, string author)
	{
		Title = title;
		Author = author;
	}

	public ICloneableItem Clone()
	{
		return new Book(Title, Author);
	}

	public void Display()
	{
		Console.WriteLine("Book: " + Title + " by " + Author);
	}
}

// Concrete prototype - Movie
public class Movie : ICloneableItem
{
	public string Title { get; set; }
	public string Director { get; set; }

	public Movie(string title, string director)
	{
		Title = title;
		Director = director;
	}

	public ICloneableItem Clone()
	{
		return new Movie(Title, Director);
	}

	public void Display()
	{
		Console.WriteLine("Movie: " + Title + " directed by " + Director);
	}
}

// Client class
public class Client
{
	private ICloneableItem itemPrototype;

	public Client(ICloneableItem itemPrototype)
	{
		this.itemPrototype = itemPrototype;
	}

	public ICloneableItem MakeClone()
	{
		return itemPrototype.Clone();
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		// Create a prototype object
		Book originalBook = new Book("Design Patterns", "Erich Gamma");

		// Create a client and make a clone of the book
		Client client = new Client(originalBook);
		ICloneableItem clonedBook = client.MakeClone();

		// Display original and cloned objects
		originalBook.Display();
		clonedBook.Display();

		Console.WriteLine();

		// Create another prototype object
		Movie originalMovie = new Movie("Inception", "Christopher Nolan");

		// Create a client and make a clone of the movie
		client = new Client(originalMovie);
		ICloneableItem clonedMovie = client.MakeClone();

		// Display original and cloned objects
		originalMovie.Display();
		clonedMovie.Display();

		Console.ReadKey();
	}
}

/* 
In this example, we have an interface called ICloneableItem, which defines the Clone and Display 
methods. Two concrete prototype classes, Book and Movie, implement this interface. Each concrete 
prototype provides its own implementation of the Clone method, creating a new instance of itself.
The Display method is responsible for displaying the details of the specific prototype.

The Client class holds a reference to the prototype and can make a clone of it using the MakeClone 
method, which calls the Clone method on the prototype. In the Main method, we create an original 
Book object and clone it, displaying the details of both the original and cloned objects. 
Then, we create an original Movie object and clone it, displaying the details of both the 
original and cloned objects.

This example demonstrates how the Prototype design pattern can be used to create clones of 
different types of objects (Book and Movie) by utilizing a common interface (ICloneableItem). 
It allows us to create new objects by copying the state of existing objects without tightly 
coupling the client code to specific classes.
*/