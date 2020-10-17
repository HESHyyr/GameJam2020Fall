using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Serialized Event", menuName = "Serialized Events/New Serialized Event")]
public class SerializedEvent : ScriptableObject
{

    private readonly List<SerializedEventListener> eventListeners =
        new List<SerializedEventListener>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised();
    }

    public void RegisterListener(SerializedEventListener listener)
    {
        if (!eventListeners.Contains(listener))
        {
            for (int i = 0; i < eventListeners.Count; i++)
            {
                if (eventListeners[i].priority < listener.priority)
                {
                    eventListeners.Insert(i, listener);
                    return;
                }
            }

            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(SerializedEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
