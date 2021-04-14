using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evently
{
    private static Evently eventManagerInstance;
    public static Evently instance => eventManagerInstance ?? (eventManagerInstance = new Evently());

    private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();

    //This system will have three methods

    //Subscribe
    //Be something like this...+=
    public void Subscribe<T>(Action<T> del)
    {
        if (delegates.ContainsKey(typeof(T)))
        {
            delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)],del);
        }
        else
        {
            delegates[typeof(T)] = del;
        }
    }

    //Unsubscribe
    //Be something like this...-=
    public void Unsubscribe<T>(Action<T> del)
    {
        if (!delegates.ContainsKey(typeof(T))) return;

        var currentDel = Delegate.Remove(delegates[typeof(T)], del);

        if (currentDel == null)
        {
            delegates.Remove(typeof(T));
        }
        else
        {
            delegates[typeof(T)] = currentDel;
        }
    }
    //Publish
    //Gonna have something to do with Invoke...
    public void Publish<T>(T t)
    {
        if (t == null)
        {
            Debug.Log("Invalid event argument");
            return;
        }

        if (delegates.ContainsKey(t.GetType()))
        {
            delegates[t.GetType()].DynamicInvoke(t);
        }
    }
}
