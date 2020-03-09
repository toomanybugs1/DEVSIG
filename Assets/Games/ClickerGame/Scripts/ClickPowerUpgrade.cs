using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickPowerUpgrade : MonoBehaviour
{
    int cost = 10;

    ProgressController progressController;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        progressController = FindObjectOfType<ProgressController>();
        text = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void Clicked() {
        if (progressController.GetScore() >= cost) {

            progressController.RemoveMoney(cost);

            Upgrades.clickPowerLevel++;
            Upgrades.clickPower += Mathf.FloorToInt(Mathf.Pow(Upgrades.clickPowerLevel, 1.05f));
            cost += Mathf.FloorToInt( Mathf.Pow(Upgrades.clickPowerLevel, 1.25f));

            string newText = "Level: " + Upgrades.clickPowerLevel;
            newText += "\nPixels/Click: " + Upgrades.clickPower;
            newText += "\nCost: " + cost;
            text.SetText(newText);
        }
    }
}
