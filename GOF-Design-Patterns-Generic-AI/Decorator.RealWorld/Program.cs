using System;

// The base text component interface
public interface ITextComponent
{
	string Render();
}

// The concrete text component representing plain text
public class TextComponent : ITextComponent
{
	private string content; // this is the variable where the nested objects will reside

	public TextComponent(string content)
	{
		this.content = content;
	}

	public string Render()
	{
		return content;
	}
}

// Base decorator class
public abstract class TextDecorator : ITextComponent
{
	protected ITextComponent component;

	public TextDecorator(ITextComponent component)
	{
		this.component = component;
	}

	public virtual string Render()
	{
		return component.Render();
	}
}

// Concrete decorator for bold formatting
public class BoldDecorator : TextDecorator
{
	public BoldDecorator(ITextComponent component) : base(component)
	{
	}

	public override string Render()
	{
		return "<b>" + base.Render() + "</b>";
	}
}

// Concrete decorator for italic formatting
public class ItalicDecorator : TextDecorator
{
	public ItalicDecorator(ITextComponent component) : base(component)
	{
	}

	public override string Render()
	{
		return "<i>" + base.Render() + "</i>";
	}
}

// Concrete decorator for underline formatting
public class UnderlineDecorator : TextDecorator
{
	public UnderlineDecorator(ITextComponent component) : base(component)
	{
	}

	public override string Render()
	{
		return "<u>" + base.Render() + "</u>";
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Create the base text component
		ITextComponent text = new TextComponent("Hello, world!");

		// Decorate the text with formatting options
		text = new BoldDecorator(text);
		text = new ItalicDecorator(text);
		text = new UnderlineDecorator(text);

		// Render the formatted text
		Console.WriteLine(text.Render());
	}
}