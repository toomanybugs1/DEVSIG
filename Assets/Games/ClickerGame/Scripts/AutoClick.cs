using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoClick : MonoBehaviour {
    ProgressController progressController;
    TMP_Text text;
    Coroutine coroutine;


    void Start() {
        progressController = FindObjectOfType<ProgressController>();
        text = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void Clicked() {
        if (progressController.GetScore() >= Upgrades.autoClickCost) {

            progressController.RemoveMoney(Upgrades.autoClickCost);

            Upgrades.autoClickLevel++;
            Upgrades.autoClickPerSecond = Mathf.FloorToInt(Mathf.Pow(Upgrades.autoClickLevel, 1.05f));
            Upgrades.autoClickCost += Mathf.FloorToInt(Mathf.Pow(Upgrades.autoClickLevel, 1.25f));

            string newText = "Level: " + Upgrades.autoClickLevel;
            newText += "\nClicks/Sec: " + Upgrades.autoClickPerSecond;
            newText += "\nCost: " + Upgrades.autoClickCost;

            text.SetText(newText);

            RestartInvoke();
        }
    }

    public void RestartInvoke() {
        CancelInvoke("autoClick");
        InvokeRepeating("Click", 0, 1.0f / Upgrades.autoClickPerSecond);

    }

    void Click() {
        print(Upgrades.autoClickPower);
        progressController.AddMoney(Upgrades.autoClickPower);
    }
}
