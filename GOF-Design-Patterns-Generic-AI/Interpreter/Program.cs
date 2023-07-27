/* 
The Interpreter Design Pattern is a behavioral pattern that is used to interpret and evaluate sentences in a 
language. It involves creating a grammar for the language and implementing classes that represent different
elements of the grammar. In this example, we'll create a simple language that supports addition and subtraction 
of numbers and implement an interpreter to evaluate expressions in this language.

Let's start with the grammar for our language:

<expression>: Represents an expression that can be either an addition or subtraction.
<number>: Represents a number in the expression.

Now, let's implement the Interpreter Design Pattern in C#:

*/
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System;

public interface IExpression
{
    int Interpret();
}

// Concrete expression class for addition
public class AdditionExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public AdditionExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret()
    {
        return _leftExpression.Interpret() + _rightExpression.Interpret();
    }
}

// Concrete expression class for subtraction
public class SubtractionExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public SubtractionExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret()
    {
        return _leftExpression.Interpret() - _rightExpression.Interpret();
    }
}

// Concrete expression class for numbers
public class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret()
    {
        return _number;
    }
}

// Step 2: Create the interpreter to parse the input expression:

public class ExpressionInterpreter
{
    public static IExpression Parse(string expression)
    {
        // For simplicity, assume that the input expression is in the form "number operator number"
        string[] elements = expression.Split(' ');

        int leftNumber = int.Parse(elements[0]);
        int rightNumber = int.Parse(elements[2]);
        char operation = elements[1][0];
        // When you try to directly assign char operation = elements[1];, it will result in a compiler error
        // because you cannot directly assign a string to a char variable.
        // The reason for this is that elements[1] is a string(since Split returns an array of strings),
        // not a single character.To extract the first character from the string, you should use elements[1][0]
        // as shown in the original code.The[0] indexing is used to access the first character of the string.

        IExpression leftExpression = new NumberExpression(leftNumber);
        IExpression rightExpression = new NumberExpression(rightNumber);
        switch (operation)
        {
            case '+':
                return new AdditionExpression(leftExpression, rightExpression);
            case '-':
                return new SubtractionExpression(leftExpression, rightExpression);
            default:
                throw new ArgumentException("Invalid operator.");
        }
    }
}

// Step 3: Use the interpreter to evaluate expressions:

class Program
{
    static void Main(string[] args)
    {
        string expression1 = "5 + 3";
        string expression2 = "10 - 4";
        IExpression parsedExpression1 = ExpressionInterpreter.Parse(expression1);
        IExpression parsedExpression2 = ExpressionInterpreter.Parse(expression2);
        int result1 = parsedExpression1.Interpret();
        int result2 = parsedExpression2.Interpret();

        Console.WriteLine($"{expression1} = {result1}");
        Console.WriteLine($"{expression2} = {result2}");
    }
}
/* 
In this example, we've implemented a basic interpreter for a simple language that can evaluate expressions 
with addition and subtraction. In real-world scenarios, you might have more complex grammars and interpreter 
implementations to support more advanced languages and expressions.
*/