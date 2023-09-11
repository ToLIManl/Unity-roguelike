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

    private bool Angry;

    void Update()
    {
        TempEffectTime = EffectTime;
        
        if (EffectTime > 0)
        {
            EffectTime -= Time.deltaTime;
            if (EffectTime <= 0)
            {
                
            }
        }
    }

    public void PEshopON()
    {
        
        effects.GetComponent<AngryWarrior>().enabled = true;
        effects.GetComponent<ShieldEffect>().enabled = true;
    }
    
    public void PEshopOFF()
    {
        if (Angry == false)
        {
            effects.GetComponent<AngryWarrior>().enabled = false;
            effects.GetComponent<ShieldEffect>().enabled = false;
        }
        


    }

    /*void Update()
    {
        
        if (Shop.TempPE == 1 || AngryWarrior.IsAngry == true)
        {
            seconds += Time.deltaTime;
            if (seconds >= 30)
            {
                effects.GetComponent<AngryWarrior>().enabled = false;
                effects.GetComponent<ShieldEffect>().enabled = false;
            }
        }
    }*/
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
            Angry = effects.GetComponent<AngryWarrior>().IsAngry;
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
