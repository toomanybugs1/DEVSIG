using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoClickPower : MonoBehaviour {
    ProgressController progressController;
    AutoClick autoClick;
    TMP_Text text;


    void Start() {
        progressController = FindObjectOfType<ProgressController>();
        text = transform.GetChild(1).GetComponent<TMP_Text>();
        autoClick = FindObjectOfType<AutoClick>();
    }

    public void Clicked() {
        if (progressController.GetScore() >= Upgrades.autoClickPowerCost) {
            progressController.RemoveMoney(Upgrades.autoClickPowerCost);

            Upgrades.autoClickPowerLevel++;
            Upgrades.autoClickPower = Mathf.FloorToInt(Mathf.Pow(Upgrades.autoClickPowerLevel, 1.05f));
            Upgrades.autoClickPowerCost += Mathf.FloorToInt(Mathf.Pow(Upgrades.autoClickPowerLevel * 100, 1.1f));

            string newText = "Level: " + Upgrades.autoClickPowerLevel;
            newText += "\nPixels/Click: " + Upgrades.autoClickPower;
            newText += "\nCost: " + Upgrades.autoClickPowerCost;

            text.SetText(newText);

            autoClick.RestartInvoke();
        }
    }
}
