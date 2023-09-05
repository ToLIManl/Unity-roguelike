using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemiesToSpawn = 10;
    public float spawnInterval = 1.5f;

    private GridMaker gridMaker;
    private Transform playerTransform; // Позиция игрока

    private void Start()
    {
        gridMaker = GameObject.Find("Grid").GetComponent<GridMaker>();
        playerTransform = GameObject.Find("Player").transform; // Записываем позицию игрока
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, GameObject.Find("LightObject").transform);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;

        // Генерируем случайную позицию
        do
        {
            spawnPosition = new Vector3(Random.Range(-20 / 2f, 20 / 2f),
                Random.Range(-20 / 2f, 20 / 2f), 0f);
        } while (Vector3.Distance(spawnPosition, playerTransform.position) < 2f); // Проверяем расстояние до игрока

        return spawnPosition;
    }
}












/* using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //GameObject camera;
    GameObject player;
    public GameObject enemyPrefab;
    private GameObject lastEnemy;

    private GridMaker gridMaker;



    public TMP_Text enemyCounterText;
    //public int enemyCounter;


    // Start is called before the first frame update
    void Start()
    {
        
        gridMaker = GameObject.Find("Grid").GetComponent<GridMaker>();

        //HPbar = GameObject.Find("HPbar");
        //camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");

        for (int i = 0; i < 10; i++)
        {
            lastEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(0 - gridMaker.arenSizeX / 2, gridMaker.arenSizeY / 2),
                Random.Range(0 - gridMaker.arenSizeX / 2, gridMaker.arenSizeY / 2), 0), Quaternion.identity);
            
            lastEnemy.transform.parent = GameObject.Find("enemy spawner").transform;
            
            //lastEnemy.transform.parent -------- это типа создает родителя. тоесть я могу перемещать чото в обьект

            //enemyCounter++;

            


        }
        
         //enemyCounterText.text = $"{enemyCounter}";
    }


    /*private void OnGUI()
    {
        GUI.Box(new Rect(960, 540, Screen.width, Screen.height), "123");
        
    }
    */


// Update is called once per frame
//void Update()
//{
/*
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(0 - gridMaker.arenSizeX / 2, gridMaker.arenSizeY / 2),
                Random.Range(0 - gridMaker.arenSizeX / 2, gridMaker.arenSizeY / 2), 0) , Quaternion.identity);

            enemyCounter++;
            enemyCounterText.text = $" {enemyCounter}";
        } */
//}
    
//}
