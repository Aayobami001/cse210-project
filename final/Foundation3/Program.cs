// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Foundation3 World!");
//     }
// }

using System;

// Address Class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

// Base Event Class
public abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private string time;
    private Address address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title Of Event: {title}\nDescription Of The Event: {description}\nDate Of The Event: {date.ToShortDateString()}\nPrecise Time Event Is Happening : {time}\nAddress Of Event: {address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"{this.GetType().Name}: {title} on {date.ToShortDateString()}\n";
    }
}

// Lecture Class
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType Of Event: Lecture\nChief Speaker: {speaker}\nMax Capacity: {capacity}";
    }
}

// Reception Class
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType Of Event: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// Outdoor Gathering Class
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType Of Event: Outdoor Gathering\nWell Detailed Weather Forecast: {weatherForecast}";
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        Console.WriteLine("\nInheritance With Event Planning\n");
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "San Francisco", "CA", "USA");
        Address address3 = new Address("789 Oak St", "Austin", "TX", "USA");

        // Create events
        Lecture lecture = new Lecture("Life Of A Programmer", "A talk on life of a programmer and latest in tech.", new DateTime(2024, 7, 7), "2:00 AM", address1, "Kelvin Doe 100", 100);
        Reception reception = new Reception("Networking Event", "An event to network with professionals.", new DateTime(2024, 8, 15), "5:00 PM", address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "A fun outdoor gathering.", new DateTime(2024, 9, 21), "11:00 AM", address3, "Sunny");

        // Create a list of events
        Event[] events = { lecture, reception, outdoorGathering };

        // Display event details
        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
