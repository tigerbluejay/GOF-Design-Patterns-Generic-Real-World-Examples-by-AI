/* 
 * In a text editor, the user performs various actions such as typing, deleting, formatting, etc.
 * Each of these actions can be represented as a command object implementing the ICommand interface. 
 * The text editor itself acts as the invoker, maintaining a stack of executed commands.
 */

using System;
using System.Collections.Generic;

// The Command interface declares the Execute() method.
interface ICommand
{
	void Execute();
	void Undo();
}

// Concrete command classes implementing the ICommand interface.

class TypeCommand : ICommand
{
	private readonly string _text;

	public TypeCommand(string text)
	{
		_text = text;
	}

	public void Execute()
	{
		Console.WriteLine("Typing: " + _text);
	}

	public void Undo()
	{
		Console.WriteLine("Deleting: " + _text);
	}
}

class DeleteCommand : ICommand
{
	private readonly string _text;

	public DeleteCommand(string text)
	{
		_text = text;
	}

	public void Execute()
	{
		Console.WriteLine("Deleting: " + _text);
	}

	public void Undo()
	{
		Console.WriteLine("Typing: " + _text);
	}
}

// The Invoker class maintains a history of executed commands and executes them upon request.

class TextEditor
{
	private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

	public void ExecuteCommand(ICommand command)
	{
		command.Execute();
		_commandHistory.Push(command);
	}

	public void UndoCommand()
	{
		if (_commandHistory.Count > 0)
		{
			var command = _commandHistory.Pop();
			command.Undo();
		}
		else
		{
			Console.WriteLine("No more commands to undo.");
		}
	}
}

// Client code

class Program
{
	static void Main(string[] args)
	{
		var editor = new TextEditor();

		// Typing commands
		var typeCommand1 = new TypeCommand("Hello");
		var typeCommand2 = new TypeCommand(", world!");

		// Deleting command
		var deleteCommand = new DeleteCommand(" world!");

		// Executing commands
		editor.ExecuteCommand(typeCommand1);
		editor.ExecuteCommand(typeCommand2);
		editor.ExecuteCommand(deleteCommand);

		// Undoing commands
		editor.UndoCommand();
		editor.UndoCommand();
		editor.UndoCommand();
	}
}

/* In this example, the ICommand interface declares the Execute() and Undo() methods, which are 
 * implemented by concrete command classes like TypeCommand and DeleteCommand. The TextEditor 
 * class acts as the invoker and maintains a stack of executed commands.
 * 
 * When the program runs, the user types "Hello" and ", world!" and then deletes " world!". 
 * The TextEditor executes and stores these commands in its history. Later, when the user 
 * invokes the UndoCommand() method, the most recent command is popped from the history stack, 
 * and its Undo() method is called to reverse the action.
 * 
 * This example demonstrates how the Command pattern can be applied to implement undo/redo 
 * functionality in a text editor, allowing users to undo and redo their actions in a sequential 
 * manner.
 */