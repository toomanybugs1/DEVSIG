using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private ProgressController progressController;

    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        progressController = SceneLoader.FindObjectOfType<ProgressController>();
    }

    public void Clicked() {
        progressController.addMoney(level);
    }
}
