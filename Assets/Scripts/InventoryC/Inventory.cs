using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public DataBase data;
    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;
    
    public static bool isInventoryOpen = false;
    
    public int currentID;
    public float MoveObjZpos;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    public GameObject background;

    public void Start()
    {
        
        if (items.Count == 0)
        {
            AddGraphics();
            
        }
        for (int i = 0; i < maxCount; i++)
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1,32));
        }
        UpdateInventory();
    }

    public void Update()
    {
        if (currentID != -1)
        {
            MoveObject();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !EscapePanel.isPaused && Player.gameOver != true)
        {
            ToggleInventory();
        }
        
        
        
        /*if (Input.GetKeyDown(KeyCode.Tab) && !EscapePanel.isPaused)
        {
            if (background.activeSelf)
            {
                // The inventory is being closed
                background.SetActive(false);
                isInventoryOpen = false;
                Time.timeScale = 1; // Set timeScale to 1 only when the inventory is closed
            }
            else
            {
                // The inventory is being opened
                background.SetActive(true);
                isInventoryOpen = true;
                UpdateInventory();
                Cursor.visible = true;
                // Time.timeScale is not set here to pause the game, so it will continue running at the current value.
            }
        }*/
    }
    
    
    
    public void ToggleInventory()
    {
        if (background.activeSelf)
        {
            // The inventory is being closed
            background.SetActive(false);
            isInventoryOpen = false;
            Time.timeScale = 1; // Set timeScale to 1 only when the inventory is closed
            Cursor.visible = false; // Hide the cursor if the inventory is closed
        }
        else
        {
            // The inventory is being opened
            background.SetActive(true);
            isInventoryOpen = true;
            UpdateInventory();
            Cursor.visible = true; // Show the cursor if the inventory is open
            Time.timeScale = 0; // Pause the game when the inventory is open
        }
    }
    
    
    

    public void SearchForSameItem(Item item, int count)
    {
        // Проверяем наличие пустой ячейки с таким же ID
        var sameItem = items.FirstOrDefault(x => x.id == item.id && x.count < 64);

        if (sameItem != null)
        {
            int spaceLeft = 64 - sameItem.count;
            sameItem.count += Mathf.Min(spaceLeft, count);
            count -= Mathf.Min(spaceLeft, count);
        }

        // Добавляем новый предмет, если остались нераспределенные предметы
        while (count > 0)
        {
            var emptySlot = items.FirstOrDefault(x => x.id == 0);
            if (emptySlot != null)
            {
                emptySlot.id = item.id;
                emptySlot.count = Mathf.Min(64, count);
                count -= emptySlot.count;
            }
            else
            {
                // Если нет пустых слотов, выходим из цикла
                break;
            }
        }
    }
    
    /*public void SearchForSameItem(Item item, int count)
    {
        
        for (int i = 0; i < maxCount; i++)
        {
            

            
    if (items[i].id == item.id)
    {
        if (items[i].count < 64)
        {
            items[i].count += count;
                    
            if (items[i].count > 64)
            {
                count = items[i].count - 64;
                items[i].count = 32;
            }
            else
            {
                        
                count = 0;
                i = maxCount;
            }
                    
        }
    }
}

    if (count > 0)
{
    for (int i = 0; i < maxCount; i++)
    {
        if (items[i].id == 0)
        {
            AddItem(i, item, count);
            i = maxCount;
        }
                
    }
}
}*/
    
    /*public void OnGUI()
    {
        if (!isInventoryOpen)
        {
            Cursor.visible = false; // Hide the cursor if the inventory is closed
        }
        else if(!EscapePanel.isPaused)
        {
            Cursor.visible = true; // Show the cursor if the inventory is open
            Time.timeScale = 0; // Pause the game when the inventory is open
        }
    }*/
    

    
    
    
    
    
    
    public void AddItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.image;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = true; // Enable the TextMeshProUGUI component
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = "";
            items[id].count = 0;
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = false; // Disable the TextMeshProUGUI component
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].image;

        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = invItem.count.ToString();
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = true; // Enable the TextMeshProUGUI component
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = "";
            items[id].count = 0;
            items[id].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = false; // Disable the TextMeshProUGUI component
        }
    }
    
    
    
    
    
    
    
    

    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1,1,1);
            
            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate{SelectObject();});
            
            items.Add(ii);

        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].image;
                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = items[i].count.ToString();
                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = true; // Enable the TextMeshProUGUI component
            }
            else if (items[i].id != 0 && items[i].count <= 1)
            {
                items[i].itemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].image;
                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = ""; // Empty text
                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = true; // Enable the TextMeshProUGUI component
            }
            else
            {

                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = ""; // Empty text
                items[i].itemGameObj.GetComponentInChildren<TextMeshProUGUI>().enabled = false; // Disable the TextMeshProUGUI component
            }
        }
    }
    

    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].image;
            
            
            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ это сделал ChatGPT
            
            // Добавляем проверку, что если текущий выбранный предмет имеет ID равный 0, то сбрасываем текущий ID
            if (currentItem.id == 0)
            {
                currentID = -1;
                movingObject.gameObject.SetActive(false);
            }
            
            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ это сделал ChatGPT
            
            
            
            else
            {
                AddItem(currentID, data.items[0], 0);
            }
        }
        else
        {
            ItemInventory ii = items[int.Parse(es.currentSelectedGameObject.name)];
                if (ii.id == 0)
                {
                    movingObject.gameObject.SetActive(false);
                }
                
                //if (currentItem.id != II.id)
                if (currentItem.id != ii.id && currentItem.id != 0)

                {
                    AddInventoryItem(currentID, ii);
                    AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                }
                else
                {
                
                    if (ii.count + currentItem.count <= 64)
                    {
                        ii.count += currentItem.count;
                    }
                    else
                    {
                        AddItem(currentID, data.items[ii.id], ii.count + currentItem.count - 64);
                        ii.count = 64;
                    }

                    ii.itemGameObj.GetComponentInChildren<TextMeshProUGUI>().text = ii.count.ToString();
                }
                
            
            currentID = -1;
            
            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z + MoveObjZpos;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;

        return New;


    }
    
    
    




}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;
    public int count;

}
