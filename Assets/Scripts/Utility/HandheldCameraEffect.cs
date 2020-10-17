using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandheldCameraEffect : MonoBehaviour
{
    [SerializeField] float strength;
    [SerializeField] float speed;
    Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    void LateUpdate()
    {
        float xDisp = Mathf.PerlinNoise(0f, Time.time * speed) - .5f;
        float yDisp = Mathf.PerlinNoise(10f, Time.time * speed) - .5f;

        Vector3 disp = new Vector3(xDisp, yDisp, 0f) * strength;
        transform.position = _startingPosition + disp;
    }
}
