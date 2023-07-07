using System;
using System.IO;

// Abstraction
abstract class Document
{
	protected IFormatter formatter;

	public Document(IFormatter formatter)
	{
		this.formatter = formatter;
	}

	public abstract void Print();
}

// Refined Abstraction
class Resume : Document
{
	public Resume(IFormatter formatter) : base(formatter)
	{
	}

	public override void Print()
	{
		string formattedContent = formatter.Format("John Doe", "Software Engineer");
		Console.WriteLine($"Printing Resume:\n{formattedContent}");
	}
}

// Implementor
interface IFormatter
{
	string Format(string name, string title);
}

// Concrete Implementor
class PlainTextFormatter : IFormatter
{
	public string Format(string name, string title)
	{
		return $"Name: {name}\nTitle: {title}";
	}
}

// Concrete Implementor
class HtmlFormatter : IFormatter
{
	public string Format(string name, string title)
	{
		return $"<h1>{name}</h1><p>{title}</p>";
	}
}

// Client
class Program
{
	static void Main(string[] args)
	{
		Document resume = new Resume(new PlainTextFormatter());
		resume.Print();

		Console.WriteLine();

		Document resumeHtml = new Resume(new HtmlFormatter());
		resumeHtml.Print();
	}
}
/* In this example, the Document class represents the abstraction, which is an abstract class 
 * defining the common interface for different types of documents.The Resume class is a refined 
 * abstraction that inherits from Document and implements the Print() method.

The IFormatter interface serves as the implementor, defining the contract for formatting the document.
The PlainTextFormatter and HtmlFormatter classes are concrete implementations that provide different 
formatting implementations.

In the client code, we create instances of Resume with different formatters and call the Print() 
method on each document. The appropriate formatter implementation is invoked based on the formatter 
associated with each document.

The example demonstrates how the Bridge pattern allows the document and formatter to vary 
independently. !!!! Different types of documents can be created by extending the Document class, and 
different formatting behavior can be achieved by implementing the IFormatter interface. !!!!

In this case, we leverage the TextWriter class provided by.NET, which follows the Bridge pattern. 
The TextWriter is the abstraction, and the StreamWriter and StringWriter are concrete implementors, 
allowing us to write text to different destinations (such as files or strings) without changing the
client code.
*/

/*
In the last example, the bridge concept is implemented conceptually by multiple classes working 
together. Let's break it down:

The abstraction is represented by the Document class, which defines the common interface for different 
types of documents.

The refined abstraction is the Resume class, which inherits from Document and provides the specific 
implementation for printing a resume.

The implementor is the IFormatter interface, which defines the contract for formatting the document. 
It is implemented by the PlainTextFormatter and HtmlFormatter classes, which provide different 
formatting implementations.

The bridge itself is formed by the collaboration between the abstraction (Document) and the 
implementor (IFormatter). The abstraction has a reference to the implementor and delegates some of 
its functionality to the implementor. In this case, the Document class uses the IFormatter interface 
to format the content before printing.

So, in the last example, there isn't a specific class named "Bridge". Instead, the bridge pattern is 
implemented conceptually through the collaboration between the Document abstraction and the 
IFormatter implementor, with the Resume class serving as the refined abstraction that ties them 
together.
*/