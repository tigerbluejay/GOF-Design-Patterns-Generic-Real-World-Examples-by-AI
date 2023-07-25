using System;
using System.Collections.Generic;

public interface ICharacterFormat
{
    void ApplyFormatting();
}

public class CharacterFormat : ICharacterFormat
{
    private string font;
    private int size;
    private ConsoleColor color;

    public CharacterFormat(string font, int size, ConsoleColor color)
    {
        this.font = font;
        this.size = size;
        this.color = color;
    }

    public void ApplyFormatting()
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"Font: {font}, Size: {size}");
        Console.ResetColor();
    }
}

public class CharacterFormatFactory
{
    private Dictionary<string, ICharacterFormat> characterFormats;

    public CharacterFormatFactory()
    {
        characterFormats = new Dictionary<string, ICharacterFormat>();
    }

    public ICharacterFormat GetCharacterFormat(string key)
    {
        if (!characterFormats.ContainsKey(key))
        {
            // Parse the key and initialize properties accordingly
            string[] parts = key.Split('_');
            string font = parts[0];
            int size = int.Parse(parts[1]);
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), parts[2]);

            characterFormats[key] = new CharacterFormat(font, size, color);
        }

        return characterFormats[key];
    }
}

class Program
{
    static void Main(string[] args)
    {
        CharacterFormatFactory formatFactory = new CharacterFormatFactory();

        // Client code requesting character formats
        ICharacterFormat format1 = formatFactory.GetCharacterFormat("Arial_12_Black");
        ICharacterFormat format2 = formatFactory.GetCharacterFormat("TimesNewRoman_14_Red");
        ICharacterFormat format3 = formatFactory.GetCharacterFormat("Arial_12_Black"); // Reusing the same format

        // Apply formatting for different characters using the shared formats
        Console.WriteLine("Character 1:");
        format1.ApplyFormatting();

        Console.WriteLine("Character 2:");
        format2.ApplyFormatting();

        Console.WriteLine("Character 3:");
        format3.ApplyFormatting();
    }
}

/*
The example demonstrates the implementation of the Flyweight design pattern in C#. 
The pattern aims to reduce memory consumption by sharing common data between multiple objects. 
In this case, we are building a text editor that allows users to format characters in a document.
We create a CharacterFormat class that represents the shared properties for character formatting, including font,
size, and color. The CharacterFormat class implements the ICharacterFormat interface, which defines the contract 
for applying formatting.

To manage the shared CharacterFormat instances efficiently, we use a CharacterFormatFactory. The factory 
maintains a dictionary that stores the unique character format configurations as keys. When a client requests a 
character format based on a specific key (e.g., "Arial_12_Black"), the factory checks if it already exists in 
the dictionary. If not, it creates a new CharacterFormat instance with the appropriate font, size, and color 
based on the key. Otherwise, it returns the existing shared instance associated with that key.

By using the Flyweight pattern, the text editor can efficiently apply character formatting while avoiding the 
creation of redundant instances. When multiple characters share the same formatting, they reuse the same 
CharacterFormat object, leading to reduced memory overhead. The example demonstrates how shared CharacterFormat 
instances can be obtained from the factory, and the formatting is applied correctly to different characters, 
ensuring that the console color is reset after each application.
*/