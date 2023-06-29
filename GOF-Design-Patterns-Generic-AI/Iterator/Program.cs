using System;
using System.Collections.Generic;

// Iterator interface
interface IIterator<T>
{
	T Current { get; }
	bool MoveNext();
	void Reset();
}

// Aggregate interface
interface IAggregate<T>
{
	IIterator<T> CreateIterator();
}

// Concrete Iterator
class Iterator<T> : IIterator<T>
{
	private readonly List<T> _collection;
	private int _position;

	public Iterator(List<T> collection)
	{
		_collection = collection;
		_position = 0;
	}

	public T Current
	{
		get { return _collection[_position]; }
	}

	public bool MoveNext()
	{
		_position++;
		return _position < _collection.Count;
	}

	public void Reset()
	{
		_position = 0;
	}
}

// Concrete Aggregate
class Aggregate<T> : IAggregate<T>
{
	private readonly List<T> _collection;

	public Aggregate()
	{
		_collection = new List<T>();
	}

	public IIterator<T> CreateIterator()
	{
		return new Iterator<T>(_collection);
	}

	public void AddItem(T item)
	{
		_collection.Add(item);
	}
}

// Client
class Program
{
	static void Main(string[] args)
	{
		// Create the aggregate
		var aggregate = new Aggregate<int>();

		// Add items to the aggregate
		aggregate.AddItem(1);
		aggregate.AddItem(2);
		aggregate.AddItem(3);

		// Create the iterator
		var iterator = aggregate.CreateIterator();

		// Traverse the collection using the iterator
		while (iterator.MoveNext())
		{
			Console.WriteLine(iterator.Current);
		}
	}
}
/* 
 * In this example, we have an IIterator<T> interface that defines the operations for iterating over a 
 * collection. The Iterator<T> class implements this interface and provides the concrete implementation 
 * for iterating over a List<T> collection.
 * 
 * The IAggregate<T> interface represents the aggregate object that holds a collection of items. 
 * The Aggregate<T> class implements this interface and provides a method to create an iterator for the 
 * collection.
 * 
 * Finally, in the client code, we create an instance of Aggregate<int>, add some items to it, and 
 * create an iterator using the CreateIterator method.We then use the iterator to traverse the collection 
 * and print the current item using Console.WriteLine.
 * 
 * This example demonstrates the basic structure and usage of the Iterator design pattern in C#.
 */

/* What's the essence of the iterator design pattern?

The essence of the Iterator design pattern is to provide a standardized way to access the elements of 
a collection without exposing its underlying structure. It separates the responsibility of traversal 
from the collection itself, promoting loose coupling between the collection and the code that uses it.

The key concepts of the Iterator design pattern are:

Iterator: This is an interface or an abstract class that defines the operations for accessing elements 
in a collection. It typically includes methods like Current to get the current element, MoveNext to move 
to the next element, and Reset to reset the iterator to the beginning of the collection.

Concrete Iterator: This is the implementation of the Iterator interface. It keeps track of the current 
position in the collection and provides the actual implementation of the iterator operations.

Aggregate: This is an interface or an abstract class that represents the collection of objects. 
It declares a method to create an iterator object for the collection.

Concrete Aggregate: This is the implementation of the Aggregate interface. It creates a concrete 
iterator object that is specific to the collection it represents.

By using the Iterator design pattern, the client code can access the elements of a collection in a 
consistent manner, regardless of the collection's specific implementation details. The client 
interacts with the iterator object, which encapsulates the traversal logic, instead of directly 
accessing the collection.

The benefits of using the Iterator design pattern include:

Encapsulation: The pattern encapsulates the iteration logic within the iterator object, allowing the 
collection to change its internal structure without affecting the client code.

Separation of Concerns: The pattern separates the responsibility of traversal from the collection itself,
promoting a clear separation of concerns between the collection and the code that uses it.

Simplified Client Code: The client code only needs to interact with the iterator interface, providing a 
simple and consistent way to access elements in different types of collections.

Overall, the Iterator design pattern enhances flexibility, maintainability, and reusability by 
decoupling the collection from the iteration logic, providing a standardized way to traverse collections.
*/