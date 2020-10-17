using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SerializedEventListener))]
public class SerializedEventListenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SerializedEventListener eventListener = (SerializedEventListener)target;

        if(eventListener.delayed)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Time to Wait");
            eventListener.timeToWait = EditorGUILayout.FloatField(eventListener.timeToWait);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Use Scaled Time");
            eventListener.scaledTime = EditorGUILayout.Toggle(eventListener.scaledTime);
            EditorGUILayout.EndHorizontal();
        }

    }
}
