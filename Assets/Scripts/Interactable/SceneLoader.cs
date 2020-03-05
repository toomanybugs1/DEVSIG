using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    public string scene;

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void OnInteract() {
        LoadScene();
    }
}
