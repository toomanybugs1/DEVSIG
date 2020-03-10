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
            Upgrades.autoClickCost += Mathf.FloorToInt(Mathf.Pow(Upgrades.autoClickLevel * 10, 1.3f));

            string newText = "Level: " + Upgrades.autoClickLevel;
            newText += "\nClicks/Sec: " + Upgrades.autoClickLevel;
            newText += "\nCost: " + Upgrades.autoClickCost;

            text.SetText(newText);

            RestartInvoke();
        }
    }

    public void RestartInvoke() {
        InvokeRepeating("Click", 0, 1.0f / Upgrades.autoClickLevel);
    }

    void Click() {
        progressController.AddMoney(Upgrades.autoClickPower);
    }
}
