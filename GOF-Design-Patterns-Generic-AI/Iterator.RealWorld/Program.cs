/* 
 * Consider a scenario where you have a music streaming service that stores a collection of songs in a 
 * playlist. You want to provide a way for users to iterate over the songs in the playlist without 
 * exposing the internal structure of the playlist. In this case, the Iterator design pattern can be used.
 */

using System;
using System.Collections;
using System.Collections.Generic;

// Iterator interface
interface ISongIterator
{
	bool HasNext();
	Song Next();
}

// Aggregate interface
interface IPlaylist : IEnumerable<Song>
{
	ISongIterator GetIterator();
}

// Concrete Iterator
class SongIterator : ISongIterator
{
	private readonly List<Song> _songs;
	private int _position;

	public SongIterator(List<Song> songs)
	{
		_songs = songs;
		_position = 0;
	}

	public bool HasNext()
	{
		return _position < _songs.Count;
	}

	public Song Next()
	{
		Song song = _songs[_position];
		_position++;
		return song;
	}
}

// Concrete Aggregate
class Playlist : IPlaylist
{
	private readonly List<Song> _songs;

	public Playlist()
	{
		_songs = new List<Song>();
	}

	public void AddSong(Song song)
	{
		_songs.Add(song);
	}

	public ISongIterator GetIterator()
	{
		return new SongIterator(_songs);
	}

	public IEnumerator<Song> GetEnumerator() // this method is called by the method below
	{
		return _songs.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator() // this is called when we run the foreach loop
	{
		return GetEnumerator(); // this calls the method above
	}
}

// Song class
class Song
{
	public string Title { get; set; }
	public string Artist { get; set; }

	public Song(string title, string artist)
	{
		Title = title;
		Artist = artist;
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		// Create a playlist
		var playlist = new Playlist();

		// Add songs to the playlist
		playlist.AddSong(new Song("Song 1", "Artist 1"));
		playlist.AddSong(new Song("Song 2", "Artist 2"));
		playlist.AddSong(new Song("Song 3", "Artist 3"));

		// Iterate over the playlist using iterator
		var iterator = playlist.GetIterator();
		while (iterator.HasNext())
		{
			Song song = iterator.Next();
			Console.WriteLine("Now playing: {0} by {1}", song.Title, song.Artist);
		}

		// Iterate over the playlist using foreach loop
		foreach (Song song in playlist)
		{
			Console.WriteLine("Now playing: {0} by {1}", song.Title, song.Artist);
		}
	}
}
/* In this example, we have a Song class that represents a song with properties like Title and Artist.

The ISongIterator interface defines the operations for iterating over the songs. The SongIterator class 
implements this interface and provides the concrete implementation of the iterator operations.

The IPlaylist interface represents a playlist and extends the IEnumerable<Song> interface to enable 
iteration using a foreach loop.The Playlist class implements this interface and provides the concrete 
implementation for managing the collection of songs and creating an iterator.

In the client code, we create a playlist, add songs to it, and then use the iterator to iterate over 
the playlist and display the current song information using Console.WriteLine.We also demonstrate 
iterating over the playlist using a foreach loop, which is possible due to implementing the 
IEnumerable<Song> interface.

This example demonstrates how the Iterator design pattern allows you to traverse and iterate over a 
collection of songs in a playlist without exposing the internal structure of the playlist itself.



- What does GetEnumerator do and why is it not used in the example

In the example provided, the GetEnumerator() method is implemented as part of the IPlaylist 
interface and the Playlist class. It allows the playlist to be treated as an iterable collection, 
enabling the use of the foreach loop to iterate over the songs.

The GetEnumerator() method returns an enumerator, which is an object responsible for iterating over a 
collection. The enumerator provides access to the elements of the collection one by one. In C#, the 
IEnumerator<T> interface represents the enumerator, and it includes methods like MoveNext() to advance
to the next element and Current to get the current element.

Although the GetEnumerator() method is implemented in the example, it is not explicitly used in the 
client code. Instead, the client code uses the custom iterator ISongIterator obtained from the 
GetIterator() method to iterate over the playlist.

The reason for implementing both GetEnumerator() and GetIterator() methods is to demonstrate two 
different approaches to iteration.

The GetIterator() method provides a custom iterator (ISongIterator) specific to the playlist, which 
gives more control over the iteration process, such as directly accessing the next song using Next().
The GetEnumerator() method enables the use of the foreach loop to iterate over the playlist by leveraging 
the built-in IEnumerator<T> implementation.
In the example, you can choose to use either the custom iterator (ISongIterator) or the foreach loop 
with GetEnumerator() depending on your specific requirements and coding preferences.
*/