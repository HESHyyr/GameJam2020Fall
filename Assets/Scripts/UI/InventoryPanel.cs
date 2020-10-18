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
    private int nextAvailableInventorySlot = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        inventoryListUI = transform.Find("InventoryListUI");

        //We need to read the inventory array and draw all images here
    }

    public void AddItemToInventory()
    {
        //Change image parent to this transform
        //
        //inventoryListUI.GetChild(nextAvailableInventorySlot) = 



        nextAvailableInventorySlot++;
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
        float inventoryTransformIncreament = 380 / iterationNumber;

        for(int i = 0; i < (int)iterationNumber; i++)
        {
            inventoryListUI.localPosition = inventoryListUI.localPosition + new Vector3(shouldDisplayInventory ? inventoryTransformIncreament : -inventoryTransformIncreament, 0.0f, 0.0f);
            yield return new WaitForSeconds(iterationWaitTime);
        }
    }


}
