/* 
In this example, we have a Flight Booking System that simulates booking flights with different airlines.
The AirlineInfo class represents the shared properties of an airline, including the airline name and contact number.
It implements the IAirlineInfo interface, which defines the contract for displaying airline information.

The AirlineInfoFactory is responsible for managing shared airline information. It stores the unique airline 
codes as keys in the dictionary. When the client (Flight Booking System) requests airline information based on 
a specific airline code, the factory checks if the corresponding information already exists in the dictionary. 
If not, it creates a new AirlineInfo instance and adds it to the dictionary. Otherwise, it returns the existing 
shared instance.

The FlightBookingSystem class handles flight bookings and uses the Flyweight pattern to efficiently manage and 
share airline information. When booking a flight, the system requests the appropriate airline information from 
the factory based on the airline code. If the same airline is used for booking multiple flights, the Flyweight
pattern ensures that the shared AirlineInfo instance is reused, optimizing memory usage.

This real-world example demonstrates how the Flyweight pattern can efficiently manage and share airline information 
in a flight booking system, reducing memory consumption and improving performance when handling a large number of 
flights with different airlines.
*/

using System;
using System.Collections.Generic;

// Flyweight interface
public interface IAirlineInfo
{
    void DisplayInfo(string flightNumber, DateTime departureTime, string destination);
}

// Concrete Flyweight class representing airline information
public class AirlineInfo : IAirlineInfo
{
    private string airlineName;
    private string contactNumber;

    public AirlineInfo(string airlineName, string contactNumber)
    {
        this.airlineName = airlineName;
        this.contactNumber = contactNumber;
    }

    public void DisplayInfo(string flightNumber, DateTime departureTime, string destination)
    {
        Console.WriteLine($"Airline: {airlineName}, Flight Number: {flightNumber}, " +
            $"Departure Time: {departureTime}, Destination: {destination}");
        Console.WriteLine($"Contact: {contactNumber}");
        Console.WriteLine();
    }
}

// Flyweight Factory
public class AirlineInfoFactory
{
    private Dictionary<string, IAirlineInfo> airlineInfos;

    public AirlineInfoFactory()
    {
        airlineInfos = new Dictionary<string, IAirlineInfo>();
    }

    public IAirlineInfo GetAirlineInfo(string airlineCode, string airlineName, string contactNumber)
    {
        string key = airlineCode.ToUpper();

        if (!airlineInfos.TryGetValue(key, out IAirlineInfo airlineInfo))
        {
            airlineInfo = new AirlineInfo(airlineName, contactNumber);
            airlineInfos[key] = airlineInfo;
        }

        return airlineInfo;
    }
}

// Client code (Flight Booking System)
class FlightBookingSystem
{
    private AirlineInfoFactory airlineInfoFactory;

    public FlightBookingSystem()
    {
        airlineInfoFactory = new AirlineInfoFactory();
    }

    public void BookFlight(string airlineCode, string flightNumber, DateTime departureTime, string destination)
    {
        IAirlineInfo airlineInfo = airlineInfoFactory.GetAirlineInfo(airlineCode, 
            GetAirlineName(airlineCode), GetContactNumber(airlineCode));
        airlineInfo.DisplayInfo(flightNumber, departureTime, destination);
    }

    private string GetAirlineName(string airlineCode)
    {
        // Simulate getting airline name based on airline code (could be fetched from a database)
        // For the sake of simplicity, we'll use hardcoded values.
        switch (airlineCode.ToUpper())
        {
            case "AA":
                return "American Airlines";
            case "DL":
                return "Delta Air Lines";
            case "UA":
                return "United Airlines";
            default:
                return "Unknown Airline";
        }
    }

    private string GetContactNumber(string airlineCode)
    {
        // Simulate getting airline contact number based on airline code (could be fetched from a database)
        // For the sake of simplicity, we'll use hardcoded values.
        switch (airlineCode.ToUpper())
        {
            case "AA":
                return "1-800-433-7300";
            case "DL":
                return "1-800-221-1212";
            case "UA":
                return "1-800-864-8331";
            default:
                return "N/A";
        }
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        FlightBookingSystem flightBookingSystem = new FlightBookingSystem();

        // Book flights with different airlines
        flightBookingSystem.BookFlight("AA", "AA1234", DateTime.Now.AddHours(2), "New York");
        flightBookingSystem.BookFlight("DL", "DL5678", DateTime.Now.AddHours(4), "Los Angeles");
        flightBookingSystem.BookFlight("UA", "UA9876", DateTime.Now.AddHours(3), "Chicago");

        // Book another flight with the same airline
        flightBookingSystem.BookFlight("AA", "AA4567", DateTime.Now.AddHours(5), "Miami");

        // ... More flight bookings
    }
}