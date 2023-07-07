/* The Bridge design pattern is a structural pattern that decouples an abstraction from its 
 * implementation, allowing both to vary independently.*/

using System;

// Abstraction
abstract class Shape
{
	protected IDrawingAPI drawingAPI;

	protected Shape(IDrawingAPI drawingAPI)
	{
		this.drawingAPI = drawingAPI;
	}

	public abstract void Draw();
}

// Refined Abstraction
class Circle : Shape
{
	private double x, y, radius;

	public Circle(double x, double y, double radius, IDrawingAPI drawingAPI) : base(drawingAPI)
	{
		this.x = x;
		this.y = y;
		this.radius = radius;
	}

	public override void Draw()
	{
		drawingAPI.DrawCircle(x, y, radius);
	}
}


// Implementor
interface IDrawingAPI
{
	void DrawCircle(double x, double y, double radius);
}

// Concrete Implementor
class DrawingAPI1 : IDrawingAPI
{
	public void DrawCircle(double x, double y, double radius)
	{
		Console.WriteLine($"API1.circle at ({x},{y}) with radius {radius}");
	}
}

// Concrete Implementor

class DrawingAPI2 : IDrawingAPI
{
	public void DrawCircle(double x, double y, double radius)
	{
		Console.WriteLine($"API2.circle at ({x},{y}) with radius {radius}");
	}
}

// Client
class Program
{
	static void Main(string[] args)
	{
		Shape[] shapes = new Shape[2];
		shapes[0] = new Circle(1, 2, 3, new DrawingAPI1());
		shapes[1] = new Circle(5, 7, 11, new DrawingAPI2());

		foreach (var shape in shapes)
		{
			shape.Draw();
		}
	}
}
/* In this example, we have an abstraction Shape that defines the interface for various shapes. 
 * The Circle class is a refined abstraction that inherits from Shape. It has coordinates (x and y) 
 * and a radius, and it delegates the drawing operation to an implementation object (IDrawingAPI).

The IDrawingAPI interface serves as the implementor, defining the contract for drawing operations. 
The DrawingAPI1 and DrawingAPI2 classes are concrete implementations that provide different ways of 
drawing a circle.

Finally, in the client code, we create instances of circles with different drawing APIs and call 
the Draw() method on each shape. The appropriate drawing API implementation is invoked based on 
the implementation object associated with each shape.

This way, the Bridge pattern allows us to change or extend the shape hierarchy and the drawing 
implementation independently, without impacting each other.*/