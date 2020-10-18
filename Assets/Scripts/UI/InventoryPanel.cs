using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GameJam2020;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Inventory Setting")]
    [SerializeField] private float iterationNumber;
    [SerializeField] private float iterationWaitTime;
    [SerializeField] private Inventory inventory;

    [HideInInspector] public Transform inventoryListUI;
    [HideInInspector] public int selectedItemIndex;
    private Transform selectionBoxTransform;

    
    // Start is called before the first frame update
    void Start()
    {
        inventoryListUI = transform.Find("InventoryListUI");
        selectionBoxTransform = transform.Find("SelectionBox");
        for (int i = 0; i < inventory.Items.Count; i++)
            ChangeImage(i, inventory.Items[i].Sprite);

        selectedItemIndex = -1;
    }

    void Update()
    {
        if (selectedItemIndex != -1)
            selectionBoxTransform.position = inventoryListUI.GetChild(selectedItemIndex).position;
            
    }

    public void AddItemToInventory(Item item)
    {
        inventory.AddItem(item);
        ChangeImage(inventory.Items.Count - 1, inventory.Items[inventory.Items.Count - 1].Sprite);
    }

    public void RemoveItemFromInventory(int removeItemIndex)
    {
        //We need to shift the UI to 1 unit left
        for(int i = removeItemIndex; i + 1 < inventory.Items.Count; i++)
            ChangeImage(i, inventory.Items[i + 1].Sprite);

        inventory.RemoveItem(inventory.Items[removeItemIndex]);
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

    private void ChangeImage(int imageIndex, Sprite resultImage)
    {
        inventoryListUI.GetChild(imageIndex).gameObject.GetComponent<Image>().sprite = resultImage;
    }


}
