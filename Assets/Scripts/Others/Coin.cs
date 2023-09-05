using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coins = 100;
    public TMP_Text coinText;

    void Start()
    {
        coinText.text = coins.ToString();
    }

    void Update()
    {
        if (coins < 0)
        {
            coins = 0;
            coinText.text = coins.ToString();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Coin"))
        {
            CollectCoin(coll.gameObject);
        }
    }

    private void CollectCoin(GameObject coinObject)
    {
        coins++;
        coinText.text = coins.ToString();
        Destroy(coinObject);
    }
}











/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coins = 0;
    public TMP_Text coinText;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinText.text = coins.ToString();
            Destroy(coll.gameObject);

        }
    }

    void Update()
    {

    }


}
*/