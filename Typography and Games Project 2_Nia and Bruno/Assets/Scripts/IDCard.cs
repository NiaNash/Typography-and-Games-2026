using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCard : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
}