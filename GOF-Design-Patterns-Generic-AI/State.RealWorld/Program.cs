/* 
Let's consider a real-world example of the State pattern in a video game context. Imagine we have a 
player character in a game that can be in different states such as "Idle", "Walking", and "Running". 
The behavior of the character will vary depending on its current state. Here's an example 
implementation in C#:
*/

using System;

// Context class
class PlayerCharacter
{
	private IPlayerState currentState;

	public PlayerCharacter()
	{
		// Set initial state
		currentState = new IdleState();
	}

	public void SetState(IPlayerState state)
	{
		currentState = state;
	}

	public void HandleInput(Input input)
	{
		currentState.HandleInput(this, input);
	}
}

// State interface
interface IPlayerState
{
	void HandleInput(PlayerCharacter player, Input input);
}

// Concrete state class: IdleState
class IdleState : IPlayerState
{
	public void HandleInput(PlayerCharacter player, Input input)
	{
		switch (input)
		{
			case Input.PressUpArrow:
			case Input.PressDownArrow:
			case Input.PressLeftArrow:
			case Input.PressRightArrow:
				Console.WriteLine("Player starts walking");
				player.SetState(new WalkingState());
				break;
			case Input.PressSpace:
				Console.WriteLine("Player jumps");
				// Perform jump logic
				break;
			// Other cases for handling inputs in the idle state
			default:
				Console.WriteLine("Invalid input");
				break;
		}
	}
}

// Concrete state class: WalkingState
class WalkingState : IPlayerState
{
	public void HandleInput(PlayerCharacter player, Input input)
	{
		switch (input)
		{
			case Input.ReleaseArrowKeys:
				Console.WriteLine("Player stops walking");
				player.SetState(new IdleState());
				break;
			case Input.PressSpace:
				Console.WriteLine("Player jumps while walking");
				// Perform jump logic
				break;
			case Input.PressShift:
				Console.WriteLine("Player starts running");
				player.SetState(new RunningState());
				break;
			// Other cases for handling inputs in the walking state
			default:
				Console.WriteLine("Invalid input");
				break;
		}
	}
}

// Concrete state class: RunningState
class RunningState : IPlayerState
{
	public void HandleInput(PlayerCharacter player, Input input)
	{
		switch (input)
		{
			case Input.ReleaseArrowKeys:
				Console.WriteLine("Player slows down to walking");
				player.SetState(new WalkingState());
				break;
			case Input.PressSpace:
				Console.WriteLine("Player jumps while running");
				// Perform jump logic
				break;
			case Input.ReleaseShift:
				Console.WriteLine("Player stops running");
				player.SetState(new WalkingState());
				break;
			// Other cases for handling inputs in the running state
			default:
				Console.WriteLine("Invalid input");
				break;
		}
	}
}

// Input enum
enum Input
{
	PressUpArrow,
	PressDownArrow,
	PressLeftArrow,
	PressRightArrow,
	PressSpace,
	PressShift,
	ReleaseArrowKeys,
	ReleaseShift
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		PlayerCharacter player = new PlayerCharacter();

		// Simulating inputs
		player.HandleInput(Input.PressUpArrow);
		player.HandleInput(Input.PressSpace);
		player.HandleInput(Input.ReleaseArrowKeys);
		player.HandleInput(Input.PressShift);
		player.HandleInput(Input.PressSpace);
		player.HandleInput(Input.ReleaseShift);
	}
}
/*
In C#, the this keyword refers to the current instance of the class. When you pass this as a 
parameter to a method, you are passing a reference to the current object.

In the context of the State pattern example, when currentState.HandleInput(this, input) is called, 
it means that the current instance of the PlayerCharacter object is passed as the first parameter 
to the HandleInput method of the current state. This allows the state object to access the current 
PlayerCharacter instance and perform any necessary operations or state transitions.

By passing this as a parameter, the state object can have access to the current context 
(the PlayerCharacter instance) and interact with it accordingly.
*/

