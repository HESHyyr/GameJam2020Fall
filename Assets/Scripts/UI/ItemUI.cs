using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler
{
    private InventoryPanel InventoryUIManager;
    private int currentItemIndex;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUIManager = transform.parent.parent.GetComponent<InventoryPanel>();
        currentItemIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (GetComponent<Image>().sprite != null)
            {
                int currentItemIndex = transform.GetSiblingIndex();
                if (InventoryUIManager.selectedItemIndex == -1)
                    SelectCurrentImage();

                else
                {
                    //Compare "selectedItemIndex" & "currentItemIndex" to see if they can be combined
                    if (false)
                    {

                    }
                    else
                        SelectCurrentImage();

                }
            }
        }
        else if(pointerEventData.button == PointerEventData.InputButton.Right)
        {
            if(InventoryUIManager.selectedItemIndex == currentItemIndex)
            {
                InventoryUIManager.selectedItemIndex = -1;
                //Calculate the image's original position
                transform.parent = InventoryUIManager.inventoryListUI;
                transform.SetSiblingIndex(currentItemIndex);
                Debug.Log(transform.GetSiblingIndex());
                transform.GetComponent<RectTransform>().localPosition = new Vector2(-140.5f + 40 * transform.GetSiblingIndex(), 0.0f);
            }
        }


    }

    public void SelectCurrentImage()
    {
        InventoryUIManager.selectedItemImage = transform;
        transform.parent = InventoryUIManager.transform.parent;
        InventoryUIManager.selectedItemIndex = currentItemIndex;
    }
}
