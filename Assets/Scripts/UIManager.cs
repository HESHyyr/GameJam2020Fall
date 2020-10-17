using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Black Screen Setting")]
    [SerializeField] Image blackScreenImage = default;
    [SerializeField] float speedOfFading = default;

    //To-do Possibly change this to canControl for playercontroller and use that there
    private bool canFadeScreen = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadingBlackScreen()
    {
        StartCoroutine(waitForBlackScreen());
    }

    IEnumerator waitForBlackScreen()
    {
        canFadeScreen = false;

        while(blackScreenImage.color.a < 1)
        {
            float oldTranceparency = blackScreenImage.color.a;
            blackScreenImage.color = new Color(0.0f, 0.0f, 0.0f, oldTranceparency + speedOfFading);
            yield return new WaitForSeconds(0.05f);
        }

        //To-do We load the new scene|image there

        while(blackScreenImage.color.a > 0)
        {
            float oldTranceparency = blackScreenImage.color.a;
            blackScreenImage.color = new Color(0.0f, 0.0f, 0.0f, oldTranceparency - speedOfFading);
            yield return new WaitForSeconds(0.05f);
        }

        canFadeScreen = true;
    }
}
