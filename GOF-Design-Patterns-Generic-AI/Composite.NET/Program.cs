using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml.Linq;

// Component interface
interface IFileSystemComponent
{
	void PrintDetails();
}

// Leaf class representing a file
class File : IFileSystemComponent
{
	private string name;

	public File(string name)
	{
		this.name = name;
	}

	public void PrintDetails()
	{
		Console.WriteLine($"File: {name}");
	}
}

// Composite class representing a directory
class Directory : IFileSystemComponent
{
	private string name;
	private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

	public Directory(string name)
	{
		this.name = name;
	}

	public void AddComponent(IFileSystemComponent component)
	{
		components.Add(component);
	}

	public void RemoveComponent(IFileSystemComponent component)
	{
		components.Remove(component);
	}

	public void PrintDetails()
	{
		Console.WriteLine($"Directory: {name}");
		foreach (IFileSystemComponent component in components)
		{
			component.PrintDetails();
		}
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Creating file objects
		File file1 = new File("file1.txt");
		File file2 = new File("file2.txt");
		File file3 = new File("file3.txt");

		// Creating directory objects
		Directory rootDirectory = new Directory("Root");
		Directory subDirectory1 = new Directory("Subdirectory 1");
		Directory subDirectory2 = new Directory("Subdirectory 2");

		// Adding files to the root directory
		rootDirectory.AddComponent(file1);

		// Adding files to subdirectory 1
		subDirectory1.AddComponent(file2);
		subDirectory1.AddComponent(file3);

		// Adding subdirectories to the root directory
		rootDirectory.AddComponent(subDirectory1);
		rootDirectory.AddComponent(subDirectory2);

		// Printing the file system structure
		rootDirectory.PrintDetails();

		Console.ReadKey();
	}
}

/* 
 * In this example, we have two types of objects: File and Directory.
 * File represents individual files, while Directory represents directories in a file system.
 * Both classes implement the IFileSystemComponent interface, which defines the PrintDetails method.
 * 
 * The Main method demonstrates the usage of the Composite pattern in a .NET application. 
 * We create instances of file objects (file1, file2, file3) and directory objects (rootDirectory, 
 * subDirectory1, subDirectory2). We add files to the root directory and files to subdirectory 1, and 
 * then we add these subdirectories to the root directory, forming a hierarchical structure.

By calling the PrintDetails method on the root directory, the directory's name is printed, and then 
the method is recursively called on each component (files or subdirectories). This results in the 
file system structure being printed in a hierarchical manner.

This demonstrates that the composite object (rootDirectory) prints its name, and then delegates 
the printing operation to its child components (file1, subDirectory1, subDirectory2), which further 
delegate it to their child components (file2, file3). The result is the file system structure being
printed in a hierarchical manner.



The essence of the Composite pattern is to create a hierarchical structure of objects, where 
individual objects and groups of objects are treated uniformly. The key idea behind the pattern 
is to represent the relationship between objects as a tree-like structure, allowing clients to work 
with individual objects or collections of objects in a consistent manner.

The Composite pattern provides two fundamental abstractions:

Component: This is the common interface or abstract class that represents both the leaf objects and 
composite objects. It defines the common operations that can be performed on both types of objects.

Composite: This represents the container object that can hold leaf objects and other composite 
objects. It implements the operations defined in the component interface and provides additional 
operations for managing its child components.

The key benefits of using the Composite pattern include:

Uniformity: The pattern allows you to treat individual objects and groups of objects uniformly 
through a common interface. Clients can work with objects regardless of whether they are leaf objects 
or composite objects, simplifying the client code.

Flexibility: The pattern allows you to create complex structures by composing objects recursively. 
You can add or remove objects dynamically at runtime without affecting the client code.

Simplicity: The pattern provides a simple and intuitive way to represent part-whole hierarchies. 
It promotes a clear separation between the client code and the object structure, making the code 
easier to understand and maintain.

Consistency: The pattern enforces consistency in the way operations are performed on objects 
within the hierarchy. Whether you operate on an individual object or a group of objects, the behavior 
is consistent and follows the same interface.

Overall, the Composite pattern is useful when you need to represent a hierarchical structure of objects
and treat them uniformly, allowing you to work with complex structures in a simple and flexible manner.
*/