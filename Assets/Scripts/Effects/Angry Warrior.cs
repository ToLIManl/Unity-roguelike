using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryWarrior : MonoBehaviour
{
    
    
    public Renderer PlayerC;
    private Color OC;
    public float blendFactor = 0.7f;
    public float time;
    
    
    public void DarkAngryWar()
    {
        if (IsHappening.IsAngry == true)
        {
            time += 5f;
        }
        else
        {
            OC = PlayerC.material.color;
            IsHappening.IsAngry = true;
            Color blendedColor = Color.Lerp(OC, Color.black, blendFactor);
            PlayerC.material.color = blendedColor;
            time = 15f;
            
        }
    }
    
    
    private void AngryFalse()
    {
        IsHappening.IsAngry = false;
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
                AngryFalse();
            }
        }
    }
}
