using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingXP : MonoBehaviour
{
    public static TMP_Text textMesh;
    
    public GameObject Delete;

    private bool isCOLOR;
    
    private void Start()
    {
        
        textMesh = GetComponent<TMP_Text>();

        if (Enemy.ChooseXP == "EnemyDF" && Enemy.XPenemy != 4)
        {
            textMesh.text = "+" + Enemy.XPenemy + "XP";

            Enemy.ChooseXP = "";
        }
        if (Boss.ChooseXP == "BossDF")
        {
            textMesh.text = "+" + Boss.XPboss + "XP";
            Boss.ChooseXP = "";
        }

        if (Enemy.XPenemy == 4)
        {
            textMesh.color = Color.yellow;
            textMesh.text = "+" + Enemy.XPenemy + "XP";
            Enemy.ChooseXP = "";
        }
            
            
        if (Boss.XPboss >= 130 && Boss.XPboss <= 150)
        {
            textMesh.color = Color.yellow;
            textMesh.text = "+" + Boss.XPboss + "XP";
            Boss.ChooseXP = "";
        }
    }
    public void OnAnimationOver()
    {
        Destroy(Delete);
    }
}