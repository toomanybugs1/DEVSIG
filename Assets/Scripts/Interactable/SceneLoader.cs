using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    private string scene;
    Animator camAnimator;

    private void Start() {
        camAnimator = FindObjectOfType<FirstPersonAIO>().GetComponent<Animator>();
    }

    public void setScene(string scene) {
        this.scene = scene;
    }

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void OnInteract() {
        camAnimator.Play("CameraFade");
        GetComponent<Animator>().Play("DoorOpen");

    }
}
