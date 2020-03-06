using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    private string scene;
    Animator camAnimator;
    static float winChance = 0.01f;


    private void Start() {
        camAnimator = FindObjectOfType<FirstPersonAIO>().GetComponent<Animator>();
    }

    public void OpenDoor(){

        if (Random.value <= winChance) {
            Debug.Log("You Win!");
        } else {
            LoadScene();
        }
    }

    public void setScene(string scene) {
        this.scene = scene;
    }

    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void OnInteract() {

        if (camAnimator)
        {
            camAnimator.Play("CameraFade");
            GetComponent<Animator>().Play("DoorOpen");
        }

        OpenDoor();
    }
}
