/*
Let's consider a real-world example of the Interpreter Design Pattern in a scenario where we want to 
interpret and evaluate a simple query language for a database. The query language will support basic 
filtering on columns using conditions like equality, inequality, and comparison.

Imagine we have a database with a list of employees, and we want to allow users to search for employees 
based on their attributes like name, age, and department. The query language could look like this:

name == "John": Query to find employees with the name "John."
age > 30: Query to find employees older than 30 years.
department != "HR": Query to find employees from departments other than HR.
Let's see how we can implement this using the Interpreter Design Pattern in C#:

Step 1: Define the expression interface and concrete classes:

*/

// Interface for expression
public interface IExpression
{
    bool Interpret(Employee employee);
}

// Concrete expression class for name condition
public class NameExpression : IExpression
{
    private readonly string _name;

    public NameExpression(string name)
    {
        _name = name;
    }

    public bool Interpret(Employee employee)
    {
        return employee.Name.Equals(_name.Trim('"'), StringComparison.InvariantCultureIgnoreCase);
    }
}
// Concrete expression class for age condition
public class AgeExpression : IExpression
{
    private readonly object _value;
    private readonly ComparisonOperator _comparisonOperator;

    public AgeExpression(object value, ComparisonOperator comparisonOperator)
    {
        _value = value;
        _comparisonOperator = comparisonOperator;
    }

    public bool Interpret(Employee employee)
    {
        if (_value is int intValue)
        {
            switch (_comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return employee.Age == intValue;
                case ComparisonOperator.NotEqual:
                    return employee.Age != intValue;
                case ComparisonOperator.LessThan:
                    return employee.Age < intValue;
                case ComparisonOperator.GreaterThan:
                    return employee.Age > intValue;
                default:
                    throw new ArgumentException("Invalid comparison operator.");
            }
        }
        else
        {
            throw new ArgumentException("Invalid value type for AgeExpression.");
        }
    }
}

// Concrete expression class for department condition
public class DepartmentExpression : IExpression
{
    private readonly string _department;

    public DepartmentExpression(string department)
    {
        _department = department;
    }

    public bool Interpret(Employee employee)
    {
        bool result = employee.Department.Equals(_department.Trim('"'), StringComparison.OrdinalIgnoreCase);

        if (result == true)
        {
            return false;
        }
        if (result == false)
        {
            return true;
        }
        return false;
    }
}
//Step 2: Create the Employee class and the Interpreter to parse the input query:

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }
}

public enum ComparisonOperator
{
    Equal,
    NotEqual,
    LessThan,
    GreaterThan
}

public class QueryInterpreter
{
    public static IExpression Parse(string query)
    {
        // For simplicity, assume that the input query is in the form "column operator value"
        string[] elements = query.Split(' ');

        string column = elements[0];
        ComparisonOperator comparisonOperator;
        object value;

        switch (elements[1])
        {
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

        if (int.TryParse(elements[2], out int intValue))
        {
            value = intValue;
        }
        else
        {
            // Check if the value is a "not equal" condition
            if (elements[2].StartsWith("!"))
            {
                value = elements[2].Substring(1).Trim('"'); // Remove "!" and quotes for string values
            }
            else
            {
                value = elements[2].Trim('"'); // Remove double quotes for string values
            }
        }

        switch (column)
        {
            case "name":
                return new NameExpression(value.ToString());
            case "age":
                return new AgeExpression(value, comparisonOperator);
            case "department":
                return new DepartmentExpression(value.ToString());
            default:
                throw new ArgumentException("Invalid column.");
        }
    }
}

// Step 3: Use the interpreter to evaluate the queries:
class Program
{
    static void Main(string[] args)
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 35, Department = "HR" },
            new Employee { Name = "Alice", Age = 28, Department = "IT" },
            new Employee { Name = "Bob", Age = 40, Department = "Finance" },
            new Employee { Name = "Eve", Age = 32, Department = "HR" }
        };

        string query1 = "name == \"John\"";
        string query2 = "age > 30";
        string query3 = "department != \"HR\"";

        var parsedQuery1 = QueryInterpreter.Parse(query1);
        var parsedQuery2 = QueryInterpreter.Parse(query2);
        var parsedQuery3 = QueryInterpreter.Parse(query3);

        var result1 = employees.Where(e => parsedQuery1.Interpret(e)).ToList();
        var result2 = employees.Where(e => parsedQuery2.Interpret(e)).ToList();
        var result3 = employees.Where(e => parsedQuery3.Interpret(e)).ToList();

        Console.WriteLine("Employees with name 'John':");
        foreach (var employee in result1)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");
        }

        Console.WriteLine("\nEmployees older than 30:");
        foreach (var employee in result2)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");
        }

        Console.WriteLine("\nEmployees not from HR department:");
        foreach (var employee in result3)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");
        }
    }
}
/* 
In this example, we used the Interpreter Design Pattern to interpret and evaluate simple queries for 
filtering employees based on their attributes. The QueryInterpreter class parses the input query and 
creates the appropriate expressions for evaluation. We then apply these expressions to the list of employees 
to filter and retrieve the desired results. This example illustrates how the Interpreter Design Pattern 
can be used to build a query language for a specific domain.
*/