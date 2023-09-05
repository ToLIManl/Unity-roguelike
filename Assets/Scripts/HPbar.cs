using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject player;
    public TMP_Text HP_Text;







    private void Start()
    {
        
        HP_Text.text = Player.currentHP.ToString();
        
        
    }
    public void SetMaxHealth(int health)
    {

        health = Player.currentHP;
        slider.maxValue = Player.maxHP;
        slider.value = health;
        HP_Text.text = Player.currentHP.ToString();
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        health = Player.currentHP;
        slider.value = health;
        HP_Text.text = Player.currentHP.ToString();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    
}