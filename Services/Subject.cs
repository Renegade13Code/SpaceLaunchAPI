using System;
using System.Collections.Generic;
namespace SpaceLaunchAPI.Services;

public class Subject : ISubject
{
    // other parameters of launch can be added
    private List<IObserver> observers = new List<IObserver>();
    private string LauncherId { get; set; }
    private DateTime StartTime { get; set; }
    
    public Subject(string launcherId, DateTime startTime)
    {
        LauncherId = launcherId;
        StartTime = startTime;
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(); // smtp email notification to be performed here
        }
    }
}