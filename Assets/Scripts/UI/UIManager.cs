using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Black Screen Setting")]
    [SerializeField] Image blackScreenImage = default;
    [SerializeField] float speedOfFading = default;

    [SerializeField] private string dialogueName;

    //Varaiable for testing purpose
    [SerializeField] private string[] testDialogueArray = default;

    //To-do Possibly change this to canControl for playercontroller and use that there
    private bool canFadeScreen = true;

    private GameObject dialoguePanel;
    private DialoguePanel dialoguePanelScript;

    void Start()
    {
        dialoguePanel = transform.Find("DialoguePanel").gameObject;
        dialoguePanelScript = dialoguePanel.gameObject.GetComponent<DialoguePanel>();
    }

    public void FadingBlackScreen()
    {
        StartCoroutine(waitForBlackScreen());
    }

    //Function for testing button callback
    public void TestDialogue()
    {
        dialoguePanel.SetActive(true);
        int RN = Random.Range(0, 10);
        dialoguePanelScript.StartDialogue(dialogueName, testDialogueArray);
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
