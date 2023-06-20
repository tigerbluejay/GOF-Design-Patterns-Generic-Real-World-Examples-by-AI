/* In this example, we have a WeatherStation class that represents the subject. It maintains the 
 * current weather data, including temperature, humidity, and pressure. It also keeps track of a 
 * list of displays (IDisplay) that are interested in receiving weather updates.
 * 
 * The IDisplay interface represents the observer, and the MobileAppDisplay and WebsiteDisplay 
 * classes implement this interface as concrete observers.These display classes define how they 
 * react to weather updates by implementing the Update method.
 * 
 * In the Program class, we create a WeatherStation object and two display objects: MobileAppDisplay
 * and WebsiteDisplay. We register these displays with the weather station using the AddDisplay 
 * method.Then, we simulate weather updates by calling UpdateWeatherData on the weather station. 
 * The weather station notifies all the registered displays, and they update their respective 
 * displays with the latest weather information.
 * 
 * Later, we demonstrate how to remove a display from the weather station by calling the RemoveDisplay
 * method. After that, when another weather update occurs, only the remaining display will receive 
 * the update.
 * 
 * Overall, this example showcases how the Observer pattern allows the weather station (subject) 
 * to automatically notify the displays (observers) whenever there is a change in the weather data. 
 * The displays can then update their visuals or perform any necessary actions based on the new 
 * weather information.
*/

using System;
using System.Collections.Generic;

// Weather Station (Subject)
class WeatherStation
{
    private double temperature;
    private double humidity;
    private double pressure;
    private List<IDisplay> displays = new List<IDisplay>();

    public void AddDisplay(IDisplay display)
    {
        displays.Add(display);
    }

    public void RemoveDisplay(IDisplay display)
    {
        displays.Remove(display);
    }

    public void UpdateWeatherData(double temperature, double humidity, double pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        NotifyDisplays();
    }

    private void NotifyDisplays()
    {
        foreach (var display in displays)
        {
            display.Update(temperature, humidity, pressure);
        }
    }
}

// Display Interface (Observer)
interface IDisplay
{
    void Update(double temperature, double humidity, double pressure);
}

// Mobile App Display (Concrete Observer)
class MobileAppDisplay : IDisplay
{
    public void Update(double temperature, double humidity, double pressure)
    {
        Console.WriteLine("Mobile App Display:");
        Console.WriteLine($"Temperature: {temperature}°C");
        Console.WriteLine($"Humidity: {humidity}%");
        Console.WriteLine($"Pressure: {pressure} hPa");
        Console.WriteLine();
    }
}

// Website Display (Concrete Observer)
class WebsiteDisplay : IDisplay
{
    public void Update(double temperature, double humidity, double pressure)
    {
        Console.WriteLine("Website Display:");
        Console.WriteLine($"Temperature: {temperature}°C");
        Console.WriteLine($"Humidity: {humidity}%");
        Console.WriteLine($"Pressure: {pressure} hPa");
        Console.WriteLine();
    }
}

// Program (Client)
class Program
{
    static void Main(string[] args)
    {
        // Create a weather station
        var weatherStation = new WeatherStation();

        // Create displays (observers)
        var mobileAppDisplay = new MobileAppDisplay();
        var websiteDisplay = new WebsiteDisplay();

        // Register displays with the weather station
        weatherStation.AddDisplay(mobileAppDisplay);
        weatherStation.AddDisplay(websiteDisplay);

        // Simulate weather updates
        weatherStation.UpdateWeatherData(25.5, 70.2, 1013.2);
        weatherStation.UpdateWeatherData(27.8, 65.9, 1012.8);

        // Unregister the mobile app display
        weatherStation.RemoveDisplay(mobileAppDisplay);

        // Simulate another weather update
        weatherStation.UpdateWeatherData(29.1, 72.6, 1014.5);

        Console.ReadLine();
    }
}