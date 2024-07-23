using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string StateProvince
    {
        get { return stateProvince; }
        set { stateProvince = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public string FullAddress()
    {
        return $"{street}, {city}, {stateProvince}, {country}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public DateTime DateTime
    {
        get { return dateTime; }
        set { dateTime = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public virtual string GetStandardDetails()
    {
        return $"Event: {title}\nDescription: {description}\nDate & Time: {dateTime}\nLocation: {address.FullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: General\nTitle: {title}\nDate: {dateTime.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public string Speaker
    {
        get { return speaker; }
        set { speaker = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Lecture\nTitle: {Title}\nDate: {DateTime.ToShortDateString()}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public string RsvpEmail
    {
        get { return rsvpEmail; }
        set { rsvpEmail = value; }
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Reception\nTitle: {Title}\nDate: {DateTime.ToShortDateString()}";
    }
}

class OutdoorGathering : Event
{
    private string weather;

    public string Weather
    {
        get { return weather; }
        set { weather = value; }
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {weather}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Outdoor Gathering\nTitle: {Title}\nDate: {DateTime.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address();
        address1.Street = "5678 History Street";
        address1.City = "Springfield";
        address1.StateProvince = "IL";
        address1.Country = "USA";

        Lecture lecture = new Lecture();
        lecture.Title = "The Constitution Explained";
        lecture.Description = "A talk on each ammendment.";
        lecture.DateTime = new DateTime(2024, 8, 1, 18, 0, 0);
        lecture.Address = address1;
        lecture.Speaker = "John Adams";
        lecture.Capacity = 150;

        Address address2 = new Address();
        address2.Street = "124 Party Avenue";
        address2.City = "Metropolis";
        address2.StateProvince = "NY";
        address2.Country = "USA";

        Reception reception = new Reception();
        reception.Title = "Annual Gala";
        reception.Description = "A formal gathering for all invited.";
        reception.DateTime = new DateTime(2024, 9, 15, 19, 0, 0);
        reception.Address = address2;
        reception.RsvpEmail = "rsvp@NYGala.com";

        Address address3 = new Address();
        address3.Street = "1632 Friendly Lane";
        address3.City = "Gotham";
        address3.StateProvince = "NJ";
        address3.Country = "USA";

        OutdoorGathering outdoorGathering = new OutdoorGathering();
        outdoorGathering.Title = "Community Picnic";
        outdoorGathering.Description = "A fun day out in the park.";
        outdoorGathering.DateTime = new DateTime(2024, 7, 30, 10, 0, 0);
        outdoorGathering.Address = address3;
        outdoorGathering.Weather = "Sunny with a chance of light showers.";

        DisplayEventDetails(lecture);
        DisplayEventDetails(reception);
        DisplayEventDetails(outdoorGathering);
    }

    static void DisplayEventDetails(Event eventItem)
    {
        Console.WriteLine(eventItem.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(eventItem.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(eventItem.GetShortDescription());
        Console.WriteLine();
    }
}
