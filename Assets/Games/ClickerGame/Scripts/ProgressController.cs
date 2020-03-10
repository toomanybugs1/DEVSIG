using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ProgressController : MonoBehaviour {
    int pixels, score;
    float progress;
    float pixelHeight;
    int steps;

    RectTransform bulk, row;
    TMP_Text scoreText;

    Vector2 size;

    // Start is called before the first frame update
    void Start() {
        size = GetComponent<RectTransform>().sizeDelta;
        pixelHeight = Screen.height * (size.y / Screen.height);

        pixels = Mathf.FloorToInt(size.x * size.y);
        score = 0;

        bulk = transform.GetChild(2).GetComponent<RectTransform>();
        row = transform.GetChild(3).GetComponent<RectTransform>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();

        steps = Mathf.FloorToInt(size.y);
    }

    // Update is called once per frame
    void UpdateUI() {
        progress =  (float)score / (float)pixels;

        scoreText.SetText("Score:" + score);

        float height = pixelHeight * Mathf.Floor(progress * steps) / steps;
        float width = size.x * (progress * steps % 1);

        bulk.sizeDelta = new Vector2(size.x, height);
        row.localPosition = new Vector2(-size.x/2, -height);
        row.sizeDelta = new Vector2(width, 1);
    }

    public void AddMoney(int amount) {
        score += amount;
        score = Mathf.Clamp(score, 0, pixels);
        UpdateUI();
    }

    internal void RemoveMoney(int cost) {
        score -= cost;
        UpdateUI();
    }

    public int GetScore() {
        return score;
    }
}
