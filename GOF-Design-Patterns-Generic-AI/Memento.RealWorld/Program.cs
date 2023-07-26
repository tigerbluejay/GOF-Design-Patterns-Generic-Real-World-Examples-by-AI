/*
Let's consider a real-world example using a simple text editor application that allows users to write and edit 
documents. We'll implement the Memento design pattern to allow users to undo and redo changes they made to the 
document.

Here's the C# implementation:
*/

// Memento class
public class DocumentMemento
{
    public string Text { get; }

    public DocumentMemento(string text)
    {
        Text = text;
    }
}

// Originator class
public class Document
{
    private string _text;

    public Document(string text)
    {
        _text = text;
    }

    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            Console.WriteLine("Document: Current text is now: " + _text);
        }
    }

    public DocumentMemento Save()
    {
        Console.WriteLine("Document: Saving current state...");
        return new DocumentMemento(_text);
    }

    public void Restore(DocumentMemento memento)
    {
        _text = memento.Text;
        Console.WriteLine("Document: Restoring to previous state: " + _text);
    }
}

// Caretaker class
public class History
{
    private Stack<DocumentMemento> _mementos = new Stack<DocumentMemento>();

    public void Push(DocumentMemento memento)
    {
        _mementos.Push(memento);
    }

    public DocumentMemento Pop()
    {
        return _mementos.Pop();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Document document = new Document("Hello, world!");
        History history = new History();

        // First save
        history.Push(document.Save());

        document.Text = "Hello, ChatGPT!";
        // Second save
        history.Push(document.Save());

        document.Text = "Hello, AI!";
        // Third save
        history.Push(document.Save());

        // Restoring previous state
        document.Restore(history.Pop()); // Restores "Hello, ChatGPT!"
        document.Restore(history.Pop()); // Restores "Hello, world!"

        // Output:
        // Document: Saving current state...
        // Document: Current text is now: Hello, ChatGPT!
        // Document: Saving current state...
        // Document: Current text is now: Hello, AI!
        // Document: Saving current state...
        // Document: Current text is now: Hello, world!
        // Document: Restoring to previous state: Hello, ChatGPT!
        // Document: Restoring to previous state: Hello, world!
    }
}

/*
In this example, the Document class represents the text editor document, and users can change its text 
using the Text property.The History class serves as the caretaker, managing the stack of DocumentMemento 
instances, which store the previous states of the Document. When users make changes, the caretaker saves 
the current state, and when they want to undo, the caretaker restores the previous state.

Please note that this example is simplified to illustrate the Memento pattern. In a real-world application, 
you might want to implement additional logic to handle the actual content of the document and handle more 
complex changes, but the basic pattern of Memento remains the same.
*/