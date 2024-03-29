﻿using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{

    private int hitsRemaining = 5;

    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;

    private LevelUIManager levelUIManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        levelUIManager = FindObjectOfType<LevelUIManager>();
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;

        if (hitsRemaining > 0)
        {
            UpdateVisualState();
            AudioManager.instance.Play("Hit");
        }
        else
        {
            Destroy(gameObject);
            AudioManager.instance.Play("Destroy");
            levelUIManager.addScore(1);
        }

    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}