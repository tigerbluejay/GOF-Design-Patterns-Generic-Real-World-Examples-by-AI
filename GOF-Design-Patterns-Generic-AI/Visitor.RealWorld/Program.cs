using System;
using System.Collections.Generic;
using System.ComponentModel;

// Visitor interface
interface IVisitor
{
	void Visit(Product product);
}

// Concrete Visitor A
class DiscountVisitor : IVisitor
{
	public void Visit(Product product)
	{
		Console.WriteLine($"Applying 10% discount to {product.Name}");
		decimal discountedPrice = product.Price - (product.Price * 0.1m);
		Console.WriteLine($"Discounted price: {discountedPrice:C}");
	}
}

// Concrete Visitor B
class TaxVisitor : IVisitor
{
	public void Visit(Product product)
	{
		Console.WriteLine($"Applying 15% tax to {product.Name}");
		decimal taxedPrice = product.Price + (product.Price * 0.15m);
		Console.WriteLine($"Taxed price: {taxedPrice:C}");
	}
}

// Element interface
interface IElement
{
	void Accept(IVisitor visitor);
}

// Concrete Element: Product
class Product : IElement
{
	public string Name { get; set; }
	public decimal Price { get; set; }

	public void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}

// Object Structure
class ShoppingCart
{
	private List<Product> products = new List<Product>();

	public void AddProduct(Product product)
	{
		products.Add(product);
	}

	public void RemoveProduct(Product product)
	{
		products.Remove(product);
	}

	public void Accept(IVisitor visitor)
	{
		foreach (var product in products)
		{
			product.Accept(visitor);
		}
	}
}

// Client
class Client
{
	static void Main(string[] args)
	{
		var shoppingCart = new ShoppingCart();
		shoppingCart.AddProduct(new Product { Name = "Laptop", Price = 1000 });
		shoppingCart.AddProduct(new Product { Name = "Headphones", Price = 100 });

		var discountVisitor = new DiscountVisitor();
		var taxVisitor = new TaxVisitor();

		Console.WriteLine("Applying discount to products:");
		shoppingCart.Accept(discountVisitor);

		Console.WriteLine();

		Console.WriteLine("Applying tax to products:");
		shoppingCart.Accept(taxVisitor);
	}
}
/*
In this example, we have a shopping cart (ShoppingCart) that contains products (Product). 
The Product class implements the IElement interface, which declares an Accept method accepting 
a visitor. Each concrete product accepts a visitor by calling the visitor's Visit method, 
passing itself as an argument.

The IVisitor interface declares the Visit method, which is implemented by concrete visitors 
(DiscountVisitor and TaxVisitor). Each visitor applies a specific operation to the product 
based on its type. In this case, the DiscountVisitor applies a discount of 10% to the product's
price, while the TaxVisitor applies a tax of 15% to the product's price.

The client code (Client class) creates a shopping cart and adds products to it. It also creates 
instances of the concrete visitors (DiscountVisitor and TaxVisitor). Finally, it calls the 
Accept method on the shopping cart, passing the visitor, which triggers the visitation process.

When you run the example, you'll see the output that demonstrates the visitors applying the 
appropriate operations (discount or tax) to each product in the shopping cart.
*/