using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerfomanceEffect : MonoBehaviour
{
    public float seconds;
    public GameObject effects;
    public bool TempEnable = false;
    public static float EffectTime;
    public float TempEffectTime;
    public static int HowManyPotions;
    

    private bool Angry;

    void Update()
    {
        if (EffectTime > 0)
        {
            EffectTime -= Time.deltaTime;
        }
    }

    public void PEshopON()
    {
        
        effects.GetComponent<AngryWarrior>().enabled = true;
        effects.GetComponent<ShieldEffect>().enabled = true;
    }
    


    public void TTTTT()
    {
        StartCoroutine(TempUpdate());

    }
    
    void Start()
    { 
        effects.GetComponent<AngryWarrior>().enabled = false;
        effects.GetComponent<ShieldEffect>().enabled = false;
    }

    private IEnumerator TempUpdate()
    {
        seconds = 0;
        TempEnable = true;
        while (TempEnable == true) 
        {
            if (EffectTime <= 0)
            {
                
                seconds += Time.deltaTime;
                
                if (seconds >= 30)
                {
                    effects.GetComponent<AngryWarrior>().enabled = false;
                    effects.GetComponent<ShieldEffect>().enabled = false;
                    TempEnable = false;
                }

            }
            else
            {
                seconds = 0;
            }
            yield return null;
        }
    }
    
    



    
    
}
