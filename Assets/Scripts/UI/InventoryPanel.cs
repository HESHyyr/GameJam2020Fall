using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Inventory Setting")]
    [SerializeField] private float iterationNumber;
    [SerializeField] private float iterationWaitTime;

    private Transform inventoryListUI;

    
    // Start is called before the first frame update
    void Start()
    {
        inventoryListUI = transform.Find("InventoryListUI");
    }

    public void AddItemToInventory()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ShowInventory(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ShowInventory(false));
    }

    private IEnumerator ShowInventory(bool shouldDisplayInventory)
    {
        float inventoryTransformIncreament = 600 / iterationNumber;

        for(int i = 0; i < (int)iterationNumber; i++)
        {
            inventoryListUI.localPosition = inventoryListUI.localPosition + new Vector3(shouldDisplayInventory ? inventoryTransformIncreament : -inventoryTransformIncreament, 0.0f, 0.0f);
            yield return new WaitForSeconds(iterationWaitTime);
        }
    }


}
