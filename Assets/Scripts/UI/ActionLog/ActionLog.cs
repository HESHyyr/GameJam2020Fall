using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionLog : MonoBehaviour
{
    [SerializeField] CanvasGroup alphaGroup;
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] RectTransform actionLogRect;
    [SerializeField] float lifetime = 3f;

    public void SetLabel(string s)
    {
        label.text = s;
    }

    float t;

    private void OnEnable()
    {
        t = lifetime;
        //actionLogRect.sizeDelta = Vector2.up * 40f;
    }


    private void Update()
    {
        alphaGroup.alpha = Mathf.Clamp01(t);
        t -= Time.deltaTime;
        /*
        if(t < 1f)
        {
            actionLogRect.sizeDelta = new Vector2(0f, Mathf.Lerp(0f, 40f, Mathf.Clamp01(t)));
        }*/

        if(t < 0f)
        {
            gameObject.SetActive(false);
        }
    }

}
