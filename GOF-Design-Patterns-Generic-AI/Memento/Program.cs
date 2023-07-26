/*
The Memento design pattern is a behavioral pattern that allows an object's state to be captured and restored at a 
later time without exposing its internal structure. Here's a generic C# example of the Memento design pattern:

Let's say we have an Originator class that represents the object whose state we want to save and restore, and a 
Memento class to store the state, and a Caretaker class to manage the mementos:
*/

// Memento class
public class Memento<T>
{
    public T State { get; }

    public Memento(T state)
    {
        State = state;
    }
}

// Originator class
public class Originator<T>
{
    private T _state;

    public T State
    {
        get { return _state; }
        set
        {
            _state = value;
            Console.WriteLine("Originator: Setting state to " + _state);
        }
    }

    public Memento<T> SaveState()
    {
        Console.WriteLine("Originator: Saving state...");
        return new Memento<T>(_state);
    }

    public void RestoreState(Memento<T> memento)
    {
        _state = memento.State;
        Console.WriteLine("Originator: Restoring state to " + _state);
    }
}

// Caretaker class
public class Caretaker<T>
{
    private List<Memento<T>> _mementos = new List<Memento<T>>();

    public void AddMemento(Memento<T> memento)
    {
        _mementos.Add(memento);
    }

    public Memento<T> GetMemento(int index)
    {
        return _mementos[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Originator<string> originator = new Originator<string>();
        Caretaker<string> caretaker = new Caretaker<string>();

        // Changing and saving states in the originator
        originator.State = "State 1";
        caretaker.AddMemento(originator.SaveState());

        originator.State = "State 2";
        caretaker.AddMemento(originator.SaveState());

        originator.State = "State 3";

        // Restoring to a previous state
        originator.RestoreState(caretaker.GetMemento(1)); // Restores to State 2

        // Output:
        // Originator: Setting state to State 1
        // Originator: Saving state...
        // Originator: Setting state to State 2
        // Originator: Saving state...
        // Originator: Setting state to State 3
        // Originator: Restoring state to State 2
    }
}
/*
In this example, the Originator represents the object whose state we want to track, the Memento represents 
the saved state, and the Caretaker manages and stores the mementos. When we change the state of the Originator,
we save it in the caretaker's list of mementos. Later, if we want to restore the state, we can retrieve the 
appropriate memento from the caretaker and set it back to the Originator.
*/