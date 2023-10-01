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

    public static int PlayerDamage = 10;

    public GameObject floatingDamage;

    public GameObject HPbar;
    GameObject bar;
    GameObject barParent;
    public Gradient gradient;
    public Image fill;
    public Slider slider;
    public TMP_Text HP_Text;

    public int HP;
    public static int TempHP;
    public int MaxHP = 15;
    
    public static int XPboss;

    private int CoinsIs = 0;
    private int PotionIs = 0;

    private bool isDestroyed = false;


    public static string Choose;
    public static string ChooseXP;
    public static string ChooseOher;
    
    public float OffsetBarZ;
    public float OffsetBarY;
    
    
    
    

    void Start()
    {
        HP = MaxHP;
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        

        bar = Instantiate(HPbar, transform.position, Quaternion.identity);
        bar.GetComponent<Slider>().maxValue = MaxHP;
        bar.transform.GetChild(2).GetComponent<TMP_Text>().text = HP.ToString();
        barParent = GameObject.Find("BarParent");
        bar.transform.SetParent(barParent.transform, false);
        bar.transform.localScale = new Vector3(0.35f, 0.6f, 1.1f);

        fill.color = gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        bar.transform.position = new Vector3(transform.position.x, transform.position.y - OffsetBarY, transform.position.z - OffsetBarZ);
    }



    void OnTriggerEnter2D(Collider2D collision) //BULLET
    {
        if (isDestroyed) return; 

        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(Weapon.damage);

            if (HP <= 0)
            {
                Player.AllEnemyKills++;
                Choose = "Bullet";
                ChooseXP = "BossDF";
   
                Player.BossKills10++;
    
                
                
                Instantiate();
            }
        }
    }

    void TakeDamage(int damage)
    {

        HP -= damage;
        TempHP = HP;
        
        HP = Mathf.Clamp(HP, 0, MaxHP);
    
        RecalculateBar();

        
        Instantiate(floatingDamage, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 3), Quaternion.identity, GameObject.Find("Particles").transform);
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        int currentHP = Player.currentHP;
        if (collision.gameObject.CompareTag("Player") && Player.IsShield == false)
        {
            
            Player.currentHP -= Random.Range(20, 40);
            
            // Instantiate(floatingDamage, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 3), Quaternion.identity, GameObject.Find("Effects").transform);
            
            
        }
    }

    
    void Instantiate()
    {
        if (Choose == "Player")
        {
            player.GetComponent<XP>().GetXp(Random.Range(1, 4));
            
            if (Random.Range(0, 10) < 10)
                Instantiate(penny, transform.position, Quaternion.identity, GameObject.Find("Pickable").transform);
            Instantiate(effectDead, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity, GameObject.Find("Particles").transform);

        }

        if (Choose == "Bullet")
        {
            XPboss = Random.Range(60, 150);
            player.GetComponent<XP>().GetXp(XPboss);
            
            if (Random.Range(0, 10) < 7 && PotionIs != 1)
            {
                CoinsIs = 1;
                Instantiate(penny, transform.position, Quaternion.identity, GameObject.Find("Pickable").transform);
                
                //Instantiate(penny, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        
            }

            if (Random.Range(0, 10) < 2 && CoinsIs != 1)
            {
                PotionIs = 1;
                Instantiate(HealthPoint, transform.position, Quaternion.identity, GameObject.Find("Pickable").transform);
            }

            Instantiate(effectDead, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity, GameObject.Find("Particles").transform);
            
        }
        
        isDestroyed = true;
        HP = 0;
        Destroy(bar);
        Destroy(gameObject);
        
    }

    public void RecalculateBar()                   
    {                                          
        bar.GetComponent<Slider>().value = HP;
        bar.transform.GetChild(2).GetComponent<TMP_Text>().text = HP.ToString();
    }
    
    

}
