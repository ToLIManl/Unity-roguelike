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

        if (Enemy.enemyChooseXP == "EnemyDF" && (Enemy.XPenemy != 4 || Enemy.XPenemy == 3))
        {
            textMesh.text = "+" + Enemy.XPenemy + "XP";
            Enemy.enemyChooseXP = "";
        }
        else if (Boss.ChooseXP == "BossDF" && !(Boss.XPboss > 130))
        {
            textMesh.text = "+" + Boss.XPboss + "XP"; Boss.ChooseXP = "";
        }
        
        
        
        
        
        

        else if (Enemy.XPenemy == 4)
        {
            textMesh.text = "+" + Enemy.XPenemy + "XP";
            textMesh.color = Color.yellow;
            Enemy.enemyChooseXP = "";
        }
            
            
        else if (Boss.XPboss >= 130)
        {
            textMesh.text = "+" + Boss.XPboss + "XP";
            textMesh.color = Color.yellow;
            Boss.ChooseXP = "";
        }
        
        
        
    }
    public void OnAnimationOver()
    {
        Destroy(Delete);
    }
}