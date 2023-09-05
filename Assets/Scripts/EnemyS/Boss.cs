using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{
    public float speed;
    private Transform player;
    public GameObject effectDead;
    public GameObject penny;
    public GameObject HealthPoint;

    public GameObject HPbar;
    GameObject bar;
    GameObject barParent;
    public Gradient gradient;
    public Image fill;
    public Slider slider;
    public TMP_Text HP_Text;

    public int HP;
    private int MaxHP;


    private int CoinsIs = 0;
    private int PotionIs = 0;

    private bool isDestroyed = false;
    
    
    private string Choose;
    
    
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        bar = Instantiate(HPbar, transform.position, Quaternion.identity);
        bar.GetComponent<Slider>().maxValue = HP;
        bar.transform.GetChild(2).GetComponent<TMP_Text>().text = HP.ToString();
        barParent = GameObject.Find("BarParent");
        bar.transform.SetParent(barParent.transform, false);
        bar.transform.localScale = new Vector3(0.25f, 0.5f, 1);

        fill.color = gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        bar.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 1);
    }

    void OnCollisionEnter2D(Collision2D collision) //PLAYER
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Choose = "Player";
            Instantiate();
            
            player.GetComponent<XP>().GetXp(Random.Range(1, 4));
            
            Destroy(gameObject);
            Destroy(bar);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //BULLET
    {
        if (isDestroyed) return; // Ignore the collision if the enemy is already being destroyed

        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(Weapon.damage);

            if (HP <= 0)
            {
                isDestroyed = true; // Set the flag to true to indicate that the enemy is being destroyed
                Choose = "Bullet";
                
                Instantiate();

                player.GetComponent<XP>().GetXp(Random.Range(1, 4));

                Destroy(bar);
                Destroy(gameObject);
            }
        }
    }

    void TakeDamage(int damage)
    {
        HP -= damage;
        RecalculateBar();
    }
    
    void Instantiate()
    {
        if (Choose == "Player")
        {
            if (Random.Range(0, 10) < 10)
                Instantiate(penny, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(effectDead, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
        }

        if (Choose == "Bullet")
        {
            if (Random.Range(0, 10) < 7 && PotionIs != 1)
            {
                CoinsIs = 1;
                Instantiate(penny, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

            if (Random.Range(0, 10) < 2 && CoinsIs != 1)
            {
                PotionIs = 1;
                Instantiate(HealthPoint, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

            Instantiate(effectDead, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
        }
 
 
    }                                               

    void RecalculateBar()                   
    {                                          
        bar.GetComponent<Slider>().value = HP;
        bar.transform.GetChild(2).GetComponent<TMP_Text>().text = HP.ToString();
    }
}
