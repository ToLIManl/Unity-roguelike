using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;


public class Shop : MonoBehaviour
{
    public GameObject objectToCheck; // Укажите объект, который вы хотите проверить
    public Sprite[] targetSprites; 
    

    public TMP_Text E_text;
    public TMP_Text coin_text;
    public bool playerInRange;
    private int TempRandom;
    public GameObject effects;

    public static int TempPE = 0;
    
    
    public TMP_Text coinText;
    
    void Start()
    {
        RandomSprites();
        E_text.enabled = false;
        

    }
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
            {
                int coinValue = int.Parse(coin_text.text);
                if (TempRandom == 6)
                {
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                        effects.GetComponent<AngryWarrior>().DarkAngryWar();
                    }
                }
                else if (TempRandom == 1)
                {
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                    }
                }
                else if (TempRandom == 2)
                { 
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                        effects.GetComponent<ShieldEffect>().ShieldPlayer(10);

                    } 
                }
                else if (TempRandom == 3)
                {
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                    }
                }
                else if (TempRandom == 4)
                { 
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                        Player.Heal(Random.Range(20, 70));
                    }
                }
                else if (TempRandom == 5)
                {
                    if (Coin.coins >= coinValue)
                    {
                        Coin.coins -= coinValue;
                        Destroy(objectToCheck);
                    }
                }
                coinText.text = Coin.coins.ToString();
                
            }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            E_text.enabled = true;
            playerInRange = true;
            effects.GetComponent<PerfomanceEffect>().PEshopON();
            effects.GetComponent<PerfomanceEffect>().TTTTT();
            effects.GetComponent<PerfomanceEffect>().TempEnable = false;
            

        }
    }
    
    
    
    
    
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            E_text.enabled = false;
            playerInRange = false;  
            //effects.GetComponent<PerfomanceEffect>().PEshopOFF();
            effects.GetComponent<PerfomanceEffect>().TTTTT();
            
            
        }
    }
    
    
    void RandomSprites()
    {
        int randomIndex = Random.Range(1, targetSprites.Length);
        SpriteRenderer spriteRenderer = objectToCheck.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = targetSprites[randomIndex];

        TempRandom = randomIndex;
        
        for (int i = 1; i < targetSprites.Length; i++)
        {
            if (SpriteChecker.HasSprite(objectToCheck, targetSprites[i]))
            {
                objectToCheck.name = "good";
                break; // Выходим из цикла, если спрайт найден
            }
        }
        
        switch (randomIndex)
        {
            case 6: coin_text.text = "18"; break;
            case 1: coin_text.text = "1"; break;
            case 2: coin_text.text = "16"; break;
            case 3: coin_text.text = "9"; break;
            case 4: coin_text.text = "20"; break;
            case 5: coin_text.text = "13"; break;
        }
    }


}
