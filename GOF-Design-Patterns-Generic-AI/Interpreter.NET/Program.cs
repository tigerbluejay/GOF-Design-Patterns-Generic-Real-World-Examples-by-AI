/*
Let's consider a real-world example of the Interpreter Design Pattern in the context of a .NET application 
that involves parsing and interpreting a custom query language to filter and retrieve data from a database. 
For this example, we'll build a simple query language for querying books based on their attributes like title, 
author, and publication year.

Imagine we have a database of books, and we want to allow users to search for books using our custom query 
language. The query language could look like this:

title contains "pattern": Query to find books whose title contains the word "pattern."
author == "John Doe": Query to find books written by the author "John Doe."
year > 2000: Query to find books published after the year 2000.
Let's see how we can implement this using the Interpreter Design Pattern in C#:

Step 1: Define the expression interface and concrete classes:
*/

// Interface for expression
public interface IExpression
{
    bool Interpret(Book book);
}

// Enum for comparison operators
public enum ComparisonOperator
{
    Equal,
    NotEqual,
    LessThan,
    GreaterThan
}

// Concrete expression class for title condition
public class TitleExpression : IExpression
{
    private readonly string _keyword;

    public TitleExpression(string keyword)
    {
        _keyword = keyword;
    }

    public bool Interpret(Book book)
    {
        return book.Title.Contains(_keyword, StringComparison.OrdinalIgnoreCase);
    }
}

// Concrete expression class for author condition
public class AuthorExpression : IExpression
{
    private readonly string _author;

    public AuthorExpression(string author)
    {
        _author = author;
    }

    public bool Interpret(Book book)
    {
        return book.Author.Equals(_author, StringComparison.OrdinalIgnoreCase);
    }
}

// Concrete expression class for publication year condition
public class YearExpression : IExpression
{
    private readonly int _year;
    private readonly ComparisonOperator _comparisonOperator;

    public YearExpression(int year, ComparisonOperator comparisonOperator)
    {
        _year = year;
        _comparisonOperator = comparisonOperator;
    }

    public bool Interpret(Book book)
    {
        switch (_comparisonOperator)
        {
            case ComparisonOperator.Equal:
                return book.PublicationYear == _year;
            case ComparisonOperator.NotEqual:
                return book.PublicationYear != _year;
            case ComparisonOperator.LessThan:
                return book.PublicationYear < _year;
            case ComparisonOperator.GreaterThan:
                return book.PublicationYear > _year;
            default:
                throw new ArgumentException("Invalid comparison operator.");
        }
    }
}
//Step 2: Create the Book class and the QueryInterpreter to parse the input query:
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

public class QueryInterpreter
{
    public static IExpression Parse(string query)
    {
        // For simplicity, assume that the input query is in the form "column operator value"
        string[] elements = query.Split(new[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);

        if (elements.Length != 3)
        {
            throw new ArgumentException("Invalid query format.");
        }

        string column = elements[0];
        ComparisonOperator comparisonOperator;
        string operatorString = elements[1];
        string value = elements[2].Trim('"');

        switch (operatorString)
        {
            case "contains":
                return new TitleExpression(value);
            case "==":
                comparisonOperator = ComparisonOperator.Equal;
                break;
            case "!=":
                comparisonOperator = ComparisonOperator.NotEqual;
                break;
            case "<":
                comparisonOperator = ComparisonOperator.LessThan;
                break;
            case ">":
                comparisonOperator = ComparisonOperator.GreaterThan;
                break;
            default:
                throw new ArgumentException("Invalid comparison operator.");
        }

        switch (column)
        {
            case "author":
                return new AuthorExpression(value);
            case "title":
                return new TitleExpression(value);
            case "year":
                if (int.TryParse(value, out int intValue))
                    return new YearExpression(intValue, comparisonOperator);
                throw new ArgumentException("Invalid value for year.");
            default:
                throw new ArgumentException("Invalid column.");
        }
    }
}

//Step 3: Use the interpreter to evaluate the queries:

class Program
{
    static void Main(string[] args)
    {
        var books = new List<Book>
        {
            new Book { Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma", PublicationYear = 1994 },
            new Book { Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", PublicationYear = 2008 },
            new Book { Title = "The Pragmatic Programmer: Your Journey to Mastery", Author = "Andrew Hunt", PublicationYear = 1999 },
            new Book { Title = "C# in Depth", Author = "Jon Skeet", PublicationYear = 2019 }
        };

        string query1 = "title contains \"Pattern\"";
        string query2 = "author == \"Jon Skeet\"";
        string query3 = "year > 2000";

        var parsedQuery1 = QueryInterpreter.Parse(query1);
        var parsedQuery2 = QueryInterpreter.Parse(query2);
        var parsedQuery3 = QueryInterpreter.Parse(query3);

        var result1 = books.Where(b => parsedQuery1.Interpret(b)).ToList();
        var result2 = books.Where(b => parsedQuery2.Interpret(b)).ToList();
        var result3 = books.Where(b => parsedQuery3.Interpret(b)).ToList();

        Console.WriteLine("Books with title containing 'Pattern':");
        foreach (var book in result1)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nBooks by 'Jon Skeet':");
        foreach (var book in result2)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nBooks published after 2000:");
        foreach (var book in result3)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.PublicationYear}");
        }
    }
}