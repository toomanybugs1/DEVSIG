using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    public string scene;
    Animator camAnimator;

    private void Start() {
        camAnimator = GameObject.Find("FadeToBlackPanel").GetComponent<Animator>();
    }

    public void OpenDoor(){

        if (Random.value <= GameManager.GetWinChance()) {
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

        //OpenDoor();
    }
}
