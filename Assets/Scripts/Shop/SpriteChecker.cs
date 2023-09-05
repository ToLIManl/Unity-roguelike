using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChecker : MonoBehaviour
{
    public static bool HasSprite(GameObject obj, Sprite targetSprite)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        
        if (spriteRenderer != null && spriteRenderer.sprite == targetSprite)
        {
            return true;
        }
        
        return false;
    }
}
