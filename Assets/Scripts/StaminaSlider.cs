using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public Slider staminaSlider;
    public float staminaDisplayDuration = 3f; 
    
    public Gradient gradient;
    public Image fill;

    private float lastStaminaChangeTime;

    
    
    
    
    void Start()
    {
        lastStaminaChangeTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastStaminaChangeTime >= staminaDisplayDuration)
        {
            staminaSlider.gameObject.SetActive(false);
        }
    }

    public void UpdateStamina(float currentStamina, float maxStamina)
    {
        staminaSlider.maxValue = maxStamina;
        
        staminaSlider.gameObject.SetActive(true);
        staminaSlider.value = currentStamina;
        //staminaSlider.value = currentStamina / maxStamina;

        // Проверяем, если стамина полная и игрок не использовал стамина в течение staminaDisplayDuration секунд
        if (currentStamina >= maxStamina)
        {
            if (Time.time - lastStaminaChangeTime >= staminaDisplayDuration)
            {
                staminaSlider.gameObject.SetActive(false);
            }
        }
        else
        {
            lastStaminaChangeTime = Time.time;
        }
    }
}