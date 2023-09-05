using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{/*
    public int arenSizeX;
    public int arenSizeY;

    public GameObject gridTile;
    GameObject lastTile;

    public Sprite grass;
    public Sprite grassWithDirt;
    public Sprite grassWithPlesen;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0 - arenSizeX/2; x <= arenSizeX/2; x++)
        {
            for (int y = 0 - arenSizeY/2; y <= arenSizeY/2; y++)
            {
                lastTile = Instantiate(gridTile, new Vector3(x,y,1), Quaternion.identity);
                lastTile.gameObject.transform.parent = gameObject.transform;

                if (y == -arenSizeY / 2)
                {
                    //lastTile.GetComponent<SpriteRenderer>().sprite = grassWithDirt3;
                    var hz = Instantiate(gridTile, new Vector3(x, y-1, 1), Quaternion.identity);
                    hz.GetComponent<SpriteRenderer>().sprite = grassWithDirt;
                    hz.GetComponent<BoxCollider2D>().isTrigger = false;
                    hz.name = $"x{x}y{y-1}";
                    hz.gameObject.transform.parent = gameObject.transform;
                }
                if (x != arenSizeX / 2 && x != -arenSizeX / 2 && y != arenSizeY / 2 && y != -arenSizeY / 2)
                {
                    if (Random.Range(1, 51) == 1)
                    {
                        lastTile.GetComponent<SpriteRenderer>().sprite = grassWithPlesen;
                        switch (Random.Range(1, 5))
                        {
                            case 1:
                                lastTile.transform.rotation = new Quaternion(0, 0, 0, 0);
                                break;

                            case 2:
                                lastTile.transform.rotation = new Quaternion(0, 0, 90, 0);
                                break;

                            case 3:
                                lastTile.transform.rotation = new Quaternion(0, 0, 180, 0);
                                break;

                            case 4:
                                lastTile.transform.rotation = new Quaternion(0, 0, 270, 0);
                                break;

                            default:
                                lastTile.transform.rotation = new Quaternion(0, 0, 0, 0);
                                break;
                        }
                    }
                    else
                        lastTile.GetComponent<SpriteRenderer>().sprite = grass;
                }
                else
                    lastTile.GetComponent<SpriteRenderer>().sprite = grass;

                lastTile.name = $"x{x}y{y}";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
