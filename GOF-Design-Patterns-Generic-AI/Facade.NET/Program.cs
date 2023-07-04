/*
In this example, we have a video conversion library that consists of several complex subsystems: 
VideoCodec, AudioCodec, and MetadataExtractor. The VideoConversionFacade acts as a facade, 
providing a simplified interface for converting video files.

The VideoConversionFacade class initializes instances of the subsystems (VideoCodec, AudioCodec, 
and MetadataExtractor) in its constructor. The ConvertVideo method of the VideoConversionFacade 
class orchestrates the video conversion process by invoking the relevant methods from the subsystems.

The client code interacts with the system through the VideoConversionFacade class. 
It calls the ConvertVideo method, providing the filename and desired format for the video conversion. 
The facade shields the client from the complexity of the subsystems, making it easier to convert 
videos without directly interacting with or understanding the inner workings of the subsystems.

When you run the above example, it will simulate the video conversion process by extracting metadata, 
converting video and audio codecs, and displaying a completion message.

This real-world example demonstrates how the Facade design pattern simplifies the usage of complex 
subsystems (video conversion in this case) by providing a unified and simplified interface to the 
client code, making it easier to perform video conversions without dealing with the intricacies of 
each subsystem individually.
*/

using System;

// Complex subsystems
class VideoFile
{
	public string FileName { get; }

	public VideoFile(string fileName)
	{
		FileName = fileName;
	}
}

class VideoCodec
{
	public void Convert(VideoFile videoFile, string format)
	{
		Console.WriteLine($"Converting video '{videoFile.FileName}' to format '{format}'");
		// Conversion logic goes here
	}
}

class AudioCodec
{
	public void Convert(VideoFile videoFile, string format)
	{
		Console.WriteLine($"Converting audio of video '{videoFile.FileName}' to format '{format}'");
		// Conversion logic goes here
	}
}

class MetadataExtractor
{
	public void Extract(VideoFile videoFile)
	{
		Console.WriteLine($"Extracting metadata from video '{videoFile.FileName}'");
		// Metadata extraction logic goes here
	}
}

// Facade
class VideoConversionFacade
{
	private VideoCodec videoCodec;
	private AudioCodec audioCodec;
	private MetadataExtractor metadataExtractor;

	public VideoConversionFacade()
	{
		videoCodec = new VideoCodec();
		audioCodec = new AudioCodec();
		metadataExtractor = new MetadataExtractor();
	}

	public void ConvertVideo(string fileName, string format)
	{
		VideoFile videoFile = new VideoFile(fileName);

		metadataExtractor.Extract(videoFile);
		videoCodec.Convert(videoFile, format);
		audioCodec.Convert(videoFile, format);

		Console.WriteLine($"Video conversion completed for file '{fileName}'");
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		VideoConversionFacade facade = new VideoConversionFacade();
		facade.ConvertVideo("video.mp4", "avi");
	}
}