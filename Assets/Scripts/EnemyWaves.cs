using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public int enemyAmount = 5;
    private int arenSizeX = 20;
    private int arenSizeY = 20;

    EnemySpawner enemySpawner;

    GameObject player;
    public GameObject enemyPrefab;
    //private GameObject lastEnemy;

    private GridMaker gridMaker;

    Vector3 topLeftCorner;
    Vector3 topRightCorner;
    Vector3 downLeftCorner;
    Vector3 downRightCorner;

    // Start is called before the first frame update
    void Start()
    {
        gridMaker = GameObject.Find("Grid").GetComponent<GridMaker>();
        enemySpawner = GameObject.Find("enemy spawner").GetComponent<EnemySpawner>();

        topLeftCorner = new Vector3(-arenSizeX / 2, arenSizeY / 2, 0);
        topRightCorner = new Vector3(arenSizeX / 2, arenSizeY / 2, 0);
        downLeftCorner = new Vector3(-arenSizeX / 2, -arenSizeY / 2, 0);
        downRightCorner = new Vector3(arenSizeX / 2, -arenSizeY / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartWave();
        }
    }

    void StartWave()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            var rndNum = Random.Range(1,5);

            switch (rndNum)
            {
                case 1:
                    SpawnEnemy(topLeftCorner);
                    break;


                case 2:
                    SpawnEnemy(topRightCorner);
                    break;


                case 3:
                    SpawnEnemy(downLeftCorner);
                    break;


                case 4:
                    SpawnEnemy(downRightCorner);
                    break;

                default:
                    print("SMEEERRTT");
                    break;
            }

        }
    }

    void SpawnEnemy(Vector3 spawnPoint)
    {
        Instantiate(enemyPrefab, new Vector3(spawnPoint.x + Random.Range(-3,3), spawnPoint.y + Random.Range(-3, 3),0), Quaternion.identity, GameObject.Find("LightObject").transform);

    }
}
