using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickPowerUpgrade : MonoBehaviour {
    ProgressController progressController;
    TMP_Text text;


    void Start() {
        progressController = FindObjectOfType<ProgressController>();
        text = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void Clicked() {
        if (progressController.GetScore() >= Upgrades.clickCost) {

            progressController.RemoveMoney(Upgrades.clickCost);

            Upgrades.clickPowerLevel++;
            Upgrades.clickPower += Mathf.FloorToInt(Mathf.Pow(Upgrades.clickPowerLevel, 1.05f));
            Upgrades.clickCost += Mathf.FloorToInt(Mathf.Pow(Upgrades.clickPowerLevel, 1.25f));

            string newText = "Level: " + Upgrades.clickPowerLevel;
            newText += "\nPixels/Click: " + Upgrades.clickPower;
            newText += "\nCost: " + Upgrades.clickCost;
            text.SetText(newText);
        }
    }
}
