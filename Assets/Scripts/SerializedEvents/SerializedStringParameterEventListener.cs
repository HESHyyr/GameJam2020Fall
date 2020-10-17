using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StringUnityEvent : UnityEvent<string> { }
public class SerializedStringParameterEventListener : SerializedParameterizedEventListener<string>
{
    [SerializeField] SerializedStringParameterEvent serializedStringEvent = null;
    [SerializeField] StringUnityEvent stringUnityEvent = null;

    protected override void OnEnable()
    {
        serializedEvent = serializedStringEvent;
        response = stringUnityEvent;
        base.OnEnable();
    }
}
