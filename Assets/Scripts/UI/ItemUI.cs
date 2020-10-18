using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler
{
    private InventoryPanel InventoryUIManager;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUIManager = transform.parent.parent.GetComponent<InventoryPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(GetComponent<Image>().sprite != null)
        {
            int currentItemIndex = transform.GetSiblingIndex();
            if (InventoryUIManager.selectedItemIndex == -1)
                InventoryUIManager.selectedItemIndex = currentItemIndex;
            else
            {
                //Compare "selectedItemIndex" & "currentItemIndex" to see if they can be combined
                if (false)
                {

                }
                else
                    InventoryUIManager.selectedItemIndex = currentItemIndex;
            }
        }
    }
}
