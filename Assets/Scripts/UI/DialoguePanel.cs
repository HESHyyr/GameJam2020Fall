using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialoguePanel : MonoBehaviour, IPointerDownHandler
{
    #region local variables

    //For displaying text
    [HideInInspector]
    public string[] dialogueArray;
    private int currentDialogueIndex = 0;
    private enum PanelState { fadeIn, fadeOut, popingText, idle, inactive};
    private PanelState currentPanelState = PanelState.inactive;
    private Coroutine popingTextCoroutine;

    //For indicator icon
    [Header("Indicator Setting")]
    [SerializeField] float floatingDistance;
    [SerializeField] float floatingSpeed;
    private GameObject indicator;
    private Vector3 indicatorInitialPosition;

    //UI Child
    private Text characterTextUI;
    private Text dialogueTextUI;

    //Components
    private AudioSource textPopingSoundSource;
 

    #endregion

    private void Awake()
    {
        characterTextUI = transform.Find("CharacterText").GetComponent<Text>();
        dialogueTextUI = transform.Find("DialogueText").GetComponent<Text>();
        indicator = transform.Find("Indicator").gameObject;
        indicatorInitialPosition = indicator.transform.position;
        textPopingSoundSource = GetComponents<AudioSource>()[0];
    }

    void Update()
    {
        if(indicator.activeInHierarchy)
            indicator.transform.position = indicatorInitialPosition + new Vector3(0.0f, Mathf.Sin(Time.time * floatingSpeed) * floatingDistance, 0.0f);
    }

    //To-do: Should we add a fade-in fade-out effect for UI?
    public void FadeDialoguePanel(bool isFadeIn)
    {
        
    }

    public void StartDialogue(string characterName, string[] dialogue)
    {
        characterTextUI.text = characterName;
        dialogueArray = dialogue;
        currentDialogueIndex = 0;
        popingTextCoroutine = StartCoroutine(DisPlayDialogue(dialogueArray[currentDialogueIndex]));
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        switch (currentPanelState)
        {
            case PanelState.idle:

                if (currentDialogueIndex < dialogueArray.Length - 1)
                {
                    currentDialogueIndex++;
                    popingTextCoroutine = StartCoroutine(DisPlayDialogue(dialogueArray[currentDialogueIndex]));
                }
                else
                    gameObject.SetActive(false);
                break;

            case PanelState.popingText:
                StopCoroutine(popingTextCoroutine);
                dialogueTextUI.text = dialogueArray[currentDialogueIndex];
                break;
        }
    }

    #region private method

    IEnumerator DisPlayDialogue(string dialogue)
    {
        indicator.SetActive(false);
        currentPanelState = PanelState.popingText;
        dialogueTextUI.text = "";
        for (int i = 0; i < dialogue.Length; i++)
        {
            if (i % 2 == 0)
                textPopingSoundSource.Play();
            dialogueTextUI.text = dialogue.Substring(0, i + 1);
            yield return new WaitForSeconds(0.1f);
        }
        currentPanelState = PanelState.idle;
        indicator.SetActive(true);
    }

    #endregion
}
