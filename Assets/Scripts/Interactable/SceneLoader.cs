using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    private string scene;

    public void setScene(string scene) {
        this.scene = scene;
    }

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void OnInteract() {
        GetComponent<Animator>().Play("DoorOpen");

    }
}
