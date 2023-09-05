using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{
    public int minHealAmount = 20; // Минимальное значение восстанавливаемого здоровья
    public int maxHealAmount = 40; // Максимальное значение восстанавливаемого здоровья
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, если игрок подобрал объект с тегом "Player"
        if (other.gameObject.CompareTag("Player"))
        {

            // Генерируем случайное значение для восстанавливаемого здоровья
            int healAmount = Random.Range(minHealAmount, maxHealAmount + 1);

            // Увеличиваем здоровье игрока
            Player.Heal(healAmount);

            // Уничтожаем объект Heals
            Destroy(gameObject);
        }
    }
}