using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [HideInInspector] public static InventoryPanel instance;
    private Transform inventoryListUI;
    private Transform inventoryListItem;

    
    // Start is called before the first frame update
    void Start()
    {
        //Since inventory is passed between scenes, we might want to use the sigleten pattern
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory()
    {
        if(inventoryListItem.childCount > 4)
        {
            //Do we really want to have so many items?
            Debug.Log("Reach Max Size");
            return;
        }


    }

    
}
