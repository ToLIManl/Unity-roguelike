using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryWarrior : MonoBehaviour
{
    
    
    public Renderer PlayerC;
    private Color OC;
    public float blendFactor = 0.7f;
    public bool IsAngry = false;
    public float time;
    
    
    public void DarkAngryWar()
    {
        if (IsAngry == true)
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
            IsAngry = true;
            Color blendedColor = Color.Lerp(OC, Color.black, blendFactor);
            PlayerC.material.color = blendedColor;
            time = 15f;
            PerfomanceEffect.HowManyPotions += 1;
            
            if (PerfomanceEffect.EffectTime < time)
            {
                PerfomanceEffect.EffectTime = time;
            }

        }
    }
    
    
    private void AngryFalse()
    {
        IsAngry = false;
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
                AngryFalse();
            }
        }
    }
}
