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
    public float time;

    public void ShieldPlayer()
    {
        if (Player.IsShield == true)
        {
            time += 5f;
            
            if (PerfomanceEffect.EffectTime < time)
            {
                PerfomanceEffect.EffectTime = time;
            }
        }
        else
        {
            OC = PlayerC.material.color;
            Player.IsShield = true;
            Color blendedColor = Color.Lerp(OC, blueColor, blendFactor);
            PlayerC.material.color = blendedColor;
            time = 10f;
            // Invoke("ShieldFalse", remainingTime)
            PerfomanceEffect.HowManyPotions += 1;

            if (PerfomanceEffect.EffectTime < time)
            {
                PerfomanceEffect.EffectTime = time;
            }

        }
    }

    private void ShieldFalse()
    {
        Player.IsShield = false;
        PlayerC.material.color = OC;
        PerfomanceEffect.HowManyPotions -= 1;
        
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