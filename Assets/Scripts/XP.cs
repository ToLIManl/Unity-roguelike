using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XP : MonoBehaviour
{
    public Slider slider;
    public TMP_Text lvlText;
    public TMP_Text XPText;

    public static int TempXP;
    
    private GameObject activeUpgradePanel;
    
    public GameObject upgradePanel;
    public Canvas canvas; 
    public TMP_Text UPText;

    
    

    int xp;
    public static int lvl = 0;
    const int MAX_LEVEL = 1000; // Maximum level in the game

    private void Start()
    {

        
        lvlText.text = lvl.ToString();
        XPText.text = xp.ToString();
        SetMaxXP();
        TempXP = lvl;
    }

    public void SetMaxXP()
    {
        int currentMaxXP = GetRandomXPForLevel(lvl);
        slider.maxValue = currentMaxXP;
        slider.value = this.xp;
    }

    void Update()
    {

    }

    public void GetXp(int gotXp)
    {
        //if (UpgradeXP.isOpenUX == false)
        //{
            xp += gotXp;

            while (xp >= slider.maxValue)
            {
                LevelUp();
            }
            XPText.text = xp.ToString();
            slider.value = xp;
            

        //}
    }

    private void LevelUp()
    {
        xp -= (int)slider.maxValue;
        lvl++;
        
        
        if (lvl <= MAX_LEVEL)
        {
            int currentMaxXP = GetRandomXPForLevel(lvl);
            if (currentMaxXP <= slider.maxValue)
            {
                currentMaxXP = (int)(slider.maxValue * 1.05f); // Ensure the current max XP is at least 5% higher than the previous one
            }
            slider.maxValue = currentMaxXP;
            lvlText.text = lvl.ToString();
        }
        else
        {
            lvlText.text = MAX_LEVEL.ToString();
        }

        



    }
    

    private int GetRandomXPForLevel(int level)
    {
        int baseXP = 20 + (level - 1) * 10;
        int maxXPIncrease = 10 + (level - 1) * 20;
        return Random.Range(baseXP, baseXP + maxXPIncrease + 1);
    }
}