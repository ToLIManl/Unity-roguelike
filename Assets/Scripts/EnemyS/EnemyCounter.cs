using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public static GameObject[] enemies;
    public TMP_Text enemyCounterText;
    public static int enemyCount;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCounterText.text = enemies.Length.ToString();

    }
}
