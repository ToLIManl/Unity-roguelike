using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamage : MonoBehaviour
{
    public static TMP_Text textMesh;
    
    public GameObject Delete;
    private bool NoP;

    private bool isCOLOR;
    
    private void Start()
    {
        NoP = Enemy.Choose != "Player";
        if (isCOLOR == true)
        {

            isCOLOR = false;
        }
        
        textMesh = GetComponent<TMP_Text>();
        
        if (Enemy.Choose == "Player")
        {
            textMesh.text = "";
        }
        
        if (Enemy.Choose == "Bullet" && Weapon.isCRIT == false && Enemy.ChooseOher != "OS" && NoP)
        {
            textMesh.text = "-" + Weapon.damage;


        }
        
        if (Weapon.isCRIT == true && Enemy.ChooseOher != "OS" && NoP)
        {
            textMesh.enableVertexGradient = true;
            VertexGradient gradient = new VertexGradient(new Color32(255,180,117,255), new Color32(255,0,0,255), new Color32(0,0,255,255),new Color32(255,143,255,255));
            textMesh.colorGradient = gradient;
            textMesh.fontSize = 530;

            
            isCOLOR = true;

            
            textMesh.text = "-" + Weapon.damage;
            
        }
        




    }

    public void OnAnimationOver()
    {
        Destroy(Delete);
    }
}
