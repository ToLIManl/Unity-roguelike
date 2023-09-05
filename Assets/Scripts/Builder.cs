using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
    
{/*
    public GameObject furnace;
    GameObject player;
    Coin coinScript;

    void Start()
    {
        player = GameObject.Find("Player");
        coinScript = player.GetComponent<Coin>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && player.GetComponent<Player>().shopChoise == "4x4 shit")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider.gameObject.tag == "Grid")
            {
                var pointing = hit.collider.gameObject;
                Vector3 pointingPos = new Vector3(pointing.transform.position.x, pointing.transform.position.y, pointing.transform.position.z);

                if(pointing.GetComponent<OnMouseScript>().isFree && GameObject.Find($"x{pointingPos.x + 1}y{pointingPos.y}").GetComponent<OnMouseScript>().isFree && GameObject.Find($"x{pointingPos.x}y{pointingPos.y - 1}").GetComponent<OnMouseScript>().isFree && GameObject.Find($"x{pointingPos.x + 1}y{pointingPos.y - 1}").GetComponent<OnMouseScript>().isFree)
                {
                    if(coinScript.coins >= 5)
                    {
                        coinScript.coins -= 5;
                        coinScript.coinText.text = coinScript.coins.ToString();
                        pointing.GetComponent<OnMouseScript>().isFree = false;
                        GameObject.Find($"x{pointingPos.x + 1}y{pointingPos.y}").GetComponent<OnMouseScript>().isFree = false;
                        GameObject.Find($"x{pointingPos.x}y{pointingPos.y - 1}").GetComponent<OnMouseScript>().isFree = false;
                        GameObject.Find($"x{pointingPos.x + 1}y{pointingPos.y - 1}").GetComponent<OnMouseScript>().isFree = false;
                        Instantiate(furnace, new Vector3(pointingPos.x + 0.5f, pointingPos.y - 0.5f, -1), Quaternion.identity);
                    }
                }
            }
        }
    }*/
}
