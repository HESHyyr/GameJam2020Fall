using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SerializedEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public SerializedEvent serializedEvent;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent response;

    [Tooltip("Priority at which this listener should activate. Default 0: higher numbers get activated earlier, lower numbers later.")]
    public int priority = 0;

    public bool runOnlyOnce = false;

    public bool delayed = false;
    [HideInInspector]
    public float timeToWait = 1.0f;
    [HideInInspector]
    public bool scaledTime = true;

    private void OnEnable()
    {
        serializedEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        serializedEvent.UnregisterListener(this);
    }

    public virtual void OnEventRaised()
    {
        if (delayed)
        {
            StartCoroutine(DelayedEventRaise());
        }
        else
        {
            response.Invoke();
        }

        if(runOnlyOnce)
        {
            enabled = false;
        }
    }

    private IEnumerator DelayedEventRaise()
    {
        if (scaledTime)
        {
            yield return new WaitForSeconds(timeToWait);
        }
        else
        {
            yield return new WaitForSecondsRealtime(timeToWait);
        }

        response.Invoke();
    }
}
