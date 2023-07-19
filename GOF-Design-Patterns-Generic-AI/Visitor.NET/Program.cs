using System;
using System.Collections.Generic;

// Visitor interface
interface IVisitor
{
	void Visit(File file);
	void Visit(Folder folder);
}

// Element interface
interface IElement
{
	void Accept(IVisitor visitor);
}

// Concrete Element: File
class File : IElement
{
	public string Name { get; set; }
	public int Size { get; set; }

	public void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}

// Concrete Element: Folder
class Folder : IElement
{
	public string Name { get; set; }
	public List<IElement> Children { get; } = new List<IElement>();

	public void Accept(IVisitor visitor)
	{
		visitor.Visit(this);

		foreach (var child in Children)
		{
			child.Accept(visitor);
		}
	}
}

// Concrete Visitor: FileSizeVisitor
class FileSizeVisitor : IVisitor
{
	public int TotalSize { get; private set; }

	public void Visit(File file)
	{
		TotalSize += file.Size;
	}

	public void Visit(Folder folder)
	{
		// Do nothing for folders
	}
}

// Concrete Visitor: FileCountVisitor
class FileCountVisitor : IVisitor
{
	public int TotalCount { get; private set; }

	public void Visit(File file)
	{
		TotalCount++;
	}

	public void Visit(Folder folder)
	{
		// Do nothing for folders
	}
}

// Client
class Client
{
	static void Main(string[] args)
	{
		var rootFolder = new Folder { Name = "Root" };

		var subFolder1 = new Folder { Name = "Subfolder 1" };
		subFolder1.Children.Add(new File { Name = "File 1", Size = 10 });
		subFolder1.Children.Add(new File { Name = "File 2", Size = 20 });

		var subFolder2 = new Folder { Name = "Subfolder 2" };
		subFolder2.Children.Add(new File { Name = "File 3", Size = 15 });

		rootFolder.Children.Add(subFolder1);
		rootFolder.Children.Add(subFolder2);
		rootFolder.Children.Add(new File { Name = "File 4", Size = 5 });

		var fileSizeVisitor = new FileSizeVisitor();
		rootFolder.Accept(fileSizeVisitor);
		Console.WriteLine($"Total file size: {fileSizeVisitor.TotalSize} bytes");

		var fileCountVisitor = new FileCountVisitor();
		rootFolder.Accept(fileCountVisitor);
		Console.WriteLine($"Total file count: {fileCountVisitor.TotalCount}");
	}
}

/*
In this example, we have an application with a folder structure represented by Folder and File 
classes. The IElement interface declares the Accept method that accepts a visitor. Each concrete 
element (File and Folder) implements the Accept method, which calls the corresponding visitor 
method.

The IVisitor interface declares separate Visit methods for files and folders. The FileSizeVisitor 
and FileCountVisitor classes implement the IVisitor interface and provide the implementation 
for each Visit method. The FileSizeVisitor calculates the total size of all files, while the 
FileCountVisitor counts the total number of files.

In the client code (Client class), we create a folder structure and add files to it. We then 
create instances of the concrete visitors (FileSizeVisitor and FileCountVisitor). Finally, 
we call the Accept method on the root folder, passing the visitors, which triggers the visitation
process.

When you run the example, you'll see the output displaying the total file size and total file 
count calculated by the visitors.
*/