using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
public class UpgradeXP : MonoBehaviour
{
    
    public GameObject upgradePanel;

    public bool isOpenUX = false;
    
    public static int UPpoint = 0;
    private int previousLevel = 0;
    private int TempUPpoint = 0;
    
    public TMP_Text UPText;
    

    
    
    
 
    

    void Start()
    {
        upgradePanel.SetActive(false);
        TempUPpoint = UPpoint;
    }

    void Update()
    {
        if (XP.TempXP != XP.lvl || TempUPpoint != UPpoint)
        {
            int levelDifference = XP.lvl - previousLevel;
            previousLevel = XP.lvl;
            StartUpgrade(levelDifference);
        }
        
        
        
            if (Input.GetKeyDown(KeyCode.Alpha1) && isOpenUX == true && UPpoint > 0)
            {
                ChooseUpgrade("First");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && isOpenUX == true && UPpoint > 0)
            {
                ChooseUpgrade("Second");
            }
        
    }

    public void FinishUpgrade()
    {
        UPpoint--;
        
        if (UPpoint == 0)
        {
            upgradePanel.SetActive(false);
            isOpenUX = false;
        }

        if (UPpoint <= 1)
        {
            UPText.enabled = false;
        }
        UPText.text = "x" + UPpoint;

    }
    
    
    public void StartUpgrade(int levelDifference)
    {
        
        UPpoint += levelDifference;
        
        if (UPpoint > 0)
        {
            upgradePanel.SetActive(true);
            UPText.text = "x" + UPpoint;
            isOpenUX = true;
        }

        if (UPpoint >= 2)
        {
            UPText.enabled = true;
        }
    }





    public void ChooseUpgrade(string choice)
    {
        if (choice == "First")
        {
            Weapon.TempFire += 5;
            FinishUpgrade();
        }
        
        else if (choice == "Second")
        {

            Player.maxHP += 20;
            FinishUpgrade();
            Player.UpdateBars();
        }
    }


}
