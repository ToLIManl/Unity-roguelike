using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Sprite crosshairSprite;
    public float crosshairScale = 1.0f;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = crosshairSprite;
        transform.localScale = new Vector3(crosshairScale, crosshairScale, 1.0f); // Apply the scale factor
    }

    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseCursorPos.x, mouseCursorPos.y, -5f);
    }
}

