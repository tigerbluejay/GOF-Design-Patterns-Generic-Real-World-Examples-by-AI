using Microsoft.Win32;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

// Prototype interface
public interface IComponent
{
	void Render();
	IComponent Clone();
}

// Concrete prototype - Button
public class Button : IComponent
{
	public string Text { get; set; }

	public Button(string text)
	{
		Text = text;
	}

	public void Render()
	{
		Console.WriteLine("Rendering a button with text: " + Text);
	}

	public IComponent Clone()
	{
		return new Button(Text);
	}
}

// Concrete prototype - TextBox
public class TextBox : IComponent
{
	public string Placeholder { get; set; }

	public TextBox(string placeholder)
	{
		Placeholder = placeholder;
	}

	public void Render()
	{
		Console.WriteLine("Rendering a textbox with placeholder: " + Placeholder);
	}

	public IComponent Clone()
	{
		return new TextBox(Placeholder);
	}
}

// Component registry
public static class ComponentRegistry
{
	private static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

	public static void RegisterComponent(string key, IComponent component)
	{
		components.Add(key, component);
	}

	public static IComponent GetComponent(string key)
	{
		if (components.ContainsKey(key))
		{
			return components[key].Clone();
		}
		return null;
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		// Register prototype components
		ComponentRegistry.RegisterComponent("Button", new Button("Click me"));
		ComponentRegistry.RegisterComponent("TextBox", new TextBox("Enter text"));

		// Get cloned instances from the registry
		IComponent clonedButton = ComponentRegistry.GetComponent("Button");
		IComponent clonedTextBox = ComponentRegistry.GetComponent("TextBox");

		// Render the cloned components
		clonedButton?.Render();
		clonedTextBox?.Render();
		Console.ReadKey();
	}
}
/*
In this example, we have a Component registry (ComponentRegistry), which acts as a centralized 
store for prototype components. The registry is responsible for creating and managing instances 
of the components.

The IComponent interface defines the common Render method that all components must implement, 
as well as the Clone method for creating a clone of the component.

The Button and TextBox classes are concrete prototypes that implement the IComponent interface. 
Each component has its own properties and behavior specific to its type.

The ComponentRegistry class provides methods for registering components with the registry 
and retrieving cloned instances of the components. When a component is registered, it is stored 
with a unique key. When a client requests a component, the registry retrieves the prototype and 
returns a cloned instance using the Clone method.This ensures that the client receives a new 
instance of the component without modifying the original prototype.

In the Main method, we register prototype components (a Button and a TextBox) with the 
ComponentRegistry. Then, we retrieve cloned instances of the components using the GetComponent 
method.Finally, we invoke the Render method on the cloned components to demonstrate their 
functionality.

This example showcases how the Prototype design pattern can be applied in a .NET application 
development scenario, where you might have reusable components that need to be cloned and 
rendered multiple times. The pattern allows you to efficiently manage and retrieve cloned 
instances of components from a centralized registry, providing flexibility and ease of use 
for component creation.
*/