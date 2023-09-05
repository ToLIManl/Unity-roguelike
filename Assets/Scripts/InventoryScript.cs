using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    List<string> inventory = new List<string>()
    {

    };

    public GameObject inventoryPanel;
    public GameObject inventoryBar;
    public Plane plane;

    public int itemsOnBar;
    int maxItemsOnBar = 9;

    // Start is called before the first frame update
    void Start()
    {
        itemsOnBar = 1;
        ChangeBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeBar();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
            }
            else if(!inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(true);
            }

        }

        /*
        if (itemsOnBar > maxItemsOnBar)
            itemsOnBar = maxItemsOnBar;

        inventoryBar.gameObject.transform.localScale = new Vector3((130 + 20) * itemsOnBar, inventoryBar.gameObject.transform.localScale.y, inventoryBar.gameObject.transform.localScale.z);
        //inventoryBar.gameObject.transform.lossyScale.Set((130 + 20) * itemsOnBar, inventoryBar.gameObject.transform.lossyScale.y, inventoryBar.gameObject.transform.lossyScale.z);
        

        /*
        switch (itemsOnBar)
        {
            case 1:
                inventoryBar.gameObject.transform.localScale = new Vector3();
                break;
        }*/
    }

    void ChangeBar()
    {
        if (itemsOnBar > maxItemsOnBar)
            itemsOnBar = maxItemsOnBar;

        inventoryBar.gameObject.transform.localScale = new Vector3((130 + 20) * itemsOnBar, inventoryBar.gameObject.transform.localScale.y, inventoryBar.gameObject.transform.localScale.z);

    }
}
