using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour {
    int pixels, score;
    float progress;
    float pixelHeight;
    int steps;
    RectTransform bulk, row;
    Vector2 size;

    // Start is called before the first frame update
    void Start() {
        size = GetComponent<RectTransform>().sizeDelta;
        pixelHeight = Screen.height * (size.y / Screen.height);

        pixels = Mathf.FloorToInt(size.x * size.y);
        score = 0;

        bulk = transform.GetChild(0).GetComponent<RectTransform>();
        row = transform.GetChild(1).GetComponent<RectTransform>();

        steps = Mathf.FloorToInt(size.y);
    }

    // Update is called once per frame
    void UpdateUI() {
        progress =  (float)score / (float)pixels;
        float height = pixelHeight * Mathf.Floor(progress * steps) / steps;
        float width = size.x * (progress * steps % 1);

        bulk.sizeDelta = new Vector2(size.x, height);
        row.localPosition = new Vector2(-size.x/2, -height);
        row.sizeDelta = new Vector2(width, 1);
    }

    public void addMoney(int amount) {
        score += amount;
        UpdateUI();
    }
}
