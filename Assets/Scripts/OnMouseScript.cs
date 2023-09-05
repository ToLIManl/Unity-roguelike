using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseScript : MonoBehaviour
{/*

    GridMaker gridMaker;
    GameObject player;
    [Header("Arrows")]
    public GameObject leftDownArrow;
    public GameObject leftTopArrow;
    public GameObject rightDownArrow;
    public GameObject rightTopArrow;

    [Header("Conturs")]
    public GameObject topContur;
    public GameObject leftContur;
    public GameObject downContur;
    public GameObject rightContur;

    bool underPlayer;

    public bool isFree = true;

    //bool overMouse = false;

    // Start is called before the first frame update
    void Start()
    {
        gridMaker = GameObject.Find("Grid").GetComponent<GridMaker>();
        player = GameObject.Find("Player");
        isFree = true;

        CreateContur();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!overMouse)
        {
            onCursorObject.GetComponent<SpriteRenderer>().color = new Color(
                onCursorObject.GetComponent<SpriteRenderer>().color.r,
                onCursorObject.GetComponent<SpriteRenderer>().color.g,
                onCursorObject.GetComponent<SpriteRenderer>().color.b,
                onCursorObject.GetComponent<SpriteRenderer>().color.a + -4 - onCursorObject.GetComponent<SpriteRenderer>().color.a/100 * Time.deltaTime);

            if(onCursorObject.GetComponent<SpriteRenderer>().color.a < 0)
            {
                onCursorObject.GetComponent<SpriteRenderer>().color = new Color(
                    onCursorObject.GetComponent<SpriteRenderer>().color.r,
                    onCursorObject.GetComponent<SpriteRenderer>().color.g,
                    onCursorObject.GetComponent<SpriteRenderer>().color.b,
                    0);
            }
        }*/
    }
/*
    public void OnMouseEnter()
    {
        if(player.GetComponent<Player>().shopChoise != "4x4 shit" || !player.GetComponent<Player>().isInShop)
        {

            leftTopArrow.SetActive(true);
            leftDownArrow.SetActive(true);
            rightTopArrow.SetActive(true);
            rightDownArrow.SetActive(true);
        }
        else if(player.GetComponent<Player>().shopChoise == "4x4 shit" && player.GetComponent<Player>().isInShop)
        {
            leftTopArrow.SetActive(true);
            GameObject.Find($"x{gameObject.transform.position.x}y{gameObject.transform.position.y - 1}").GetComponent<OnMouseScript>().leftDownArrow.SetActive(true);
            //GameObject.Find($"x{gameObject.transform.position.x}y{gameObject.transform.position.y - 1}").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y}").GetComponent<OnMouseScript>().rightTopArrow.SetActive(true);
            //GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y}").transform.GetChild(3).gameObject.SetActive(true);
            GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y - 1}").GetComponent<OnMouseScript>().rightDownArrow.SetActive(true);
            //GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y - 1}").transform.GetChild(1).gameObject.SetActive(true);
        }

        /*
        if (player.GetComponent<Player>().isInShop)
        {
            if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                gameObject.GetComponent<SpriteRenderer>().color = Color.grey;

            else if (gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

            else if (gameObject.GetComponent<SpriteRenderer>().color == Color.cyan)
                gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }*/
   /* }

    private void OnMouseOver()
    {
        //overMouse = true;

        if (Input.GetMouseButtonDown(1))
        {
            if (player.GetComponent<Player>().isInShop)
            {
                if (player.GetComponent<Player>().shopChoise == "green stuff")
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    OnMouseEnter();
                }

                else if (player.GetComponent<Player>().shopChoise == "alt" && !underPlayer)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    OnMouseEnter();
                }
            }
        }

        /*
        onCursorObject.GetComponent<SpriteRenderer>().color = new Color(
            onCursorObject.GetComponent<SpriteRenderer>().color.r,
            onCursorObject.GetComponent<SpriteRenderer>().color.g,
            onCursorObject.GetComponent<SpriteRenderer>().color.b,
            onCursorObject.GetComponent<SpriteRenderer>().color.a + 5 * Time.deltaTime);

        if(onCursorObject.GetComponent<SpriteRenderer>().color.a < 1)
        {
            onCursorObject.GetComponent<SpriteRenderer>().color = new Color(
                onCursorObject.GetComponent<SpriteRenderer>().color.r,
                onCursorObject.GetComponent<SpriteRenderer>().color.g,
                onCursorObject.GetComponent<SpriteRenderer>().color.b,
                1);
        }*/
    /*}

    public void OnMouseExit()
    {
        leftTopArrow.SetActive(false);
        leftDownArrow.SetActive(false);
        rightTopArrow.SetActive(false);
        rightDownArrow.SetActive(false);

        if (player.GetComponent<Player>().shopChoise == "4x4 shit")
        {
            leftTopArrow.SetActive(false);

            GameObject.Find($"x{gameObject.transform.position.x}y{gameObject.transform.position.y - 1}").GetComponent<OnMouseScript>().leftDownArrow.SetActive(false);
            //GameObject.Find($"x{gameObject.transform.position.x}y{gameObject.transform.position.y - 1}").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y}").GetComponent<OnMouseScript>().rightTopArrow.SetActive(false);
            //GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y}").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y - 1}").GetComponent<OnMouseScript>().rightDownArrow.SetActive(false);
            //GameObject.Find($"x{gameObject.transform.position.x + 1}y{gameObject.transform.position.y - 1}").transform.GetChild(1).gameObject.SetActive(false);
        }

        //overMouse = false;
        //onCursorObject.SetActive(false);
        /*
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.grey)   
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        else if (gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        else if (gameObject.GetComponent<SpriteRenderer>().color == Color.magenta)
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;*/
    /*}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            underPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            underPlayer = false;
        }

    }

    void CreateContur()
    {
        if(GameObject.Find($"x{transform.position.x - 1}y{transform.position.y}") == null && gameObject.GetComponent<SpriteRenderer>().sprite != gridMaker.grassWithDirt)
        {
            leftContur.transform.GetChild(0).gameObject.SetActive(true);
            leftContur.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(GameObject.Find($"x{transform.position.x - 1}y{transform.position.y}") == null)
            leftContur.transform.GetChild(0).gameObject.SetActive(true);
        else 
            leftContur.SetActive(false);


        if (GameObject.Find($"x{transform.position.x}y{transform.position.y + 1}") == null)
        {
            topContur.transform.GetChild(0).gameObject.SetActive(true);
            topContur.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
            topContur.SetActive(false);

/*
        if (GameObject.Find($"x{transform.position.x + 1}y{transform.position.y}") == null && gameObject.GetComponent<SpriteRenderer>().sprite != gridMaker.grassWithDirt)
        {
            rightContur.transform.GetChild(0).gameObject.SetActive(true);
            rightContur.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (GameObject.Find($"x{transform.position.x + 1}y{transform.position.y}") == null)
            rightContur.transform.GetChild(0).gameObject.SetActive(true);
        else
            rightContur.SetActive(false);

        if (GameObject.Find($"x{transform.position.x}y{transform.position.y - 1}") == null)
        {
            downContur.transform.GetChild(0).gameObject.SetActive(true);
            //downContur.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (GameObject.Find($"x{transform.position.x}y{transform.position.y - 1}").GetComponent<SpriteRenderer>().sprite == gridMaker.grassWithDirt)
        {
            downContur.transform.GetChild(0).gameObject.SetActive(true);
            downContur.transform.GetChild(1).gameObject.SetActive(true);

        }
    }*/

