using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private ProgressController progressController;

    void Start()
    {
        progressController = SceneLoader.FindObjectOfType<ProgressController>();
    }

    public void Clicked() {
        progressController.AddMoney(Upgrades.clickPower);
    }
}
