using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler
{
    private InventoryPanel InventoryUIManager;
    private int currentItemIndex;

    public static ItemUI selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUIManager = transform.parent.parent.GetComponent<InventoryPanel>();
        currentItemIndex = transform.GetSiblingIndex();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(pointerEventData.button == PointerEventData.InputButton.Left)
        {
            selectedItem = this;
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


    }

    

    public void SelectCurrentImage()
    {
        InventoryUIManager.selectedItemImage = transform;
        transform.parent = InventoryUIManager.transform.parent;
        InventoryUIManager.selectedItemIndex = currentItemIndex;
    }
}
