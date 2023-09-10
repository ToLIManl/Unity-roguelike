using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public Renderer PlayerC;
    private Color OC;
    private Color blueColor = new Color(0f, 1f, 0.94f);
    public float blendFactor = 0.5f;
    public float remainingTime;
    public float time;

    public void ShieldPlayer()
    {
        if (Player.IsShield == true)
        {
            time += 5f;
        }
        else
        {
            Player.IsShield = true;
            Color blendedColor = Color.Lerp(OC, blueColor, blendFactor);
            PlayerC.material.color = blendedColor;
            time = 5f;
            // Invoke("ShieldFalse", remainingTime);
            
        }
    }

    private void ShieldFalse()
    {
        Player.IsShield = false;
        PlayerC.material.color = OC;
        
    }

    private void Start()
    {
        OC = PlayerC.material.color;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                ShieldFalse();
            }
        }
    }
}