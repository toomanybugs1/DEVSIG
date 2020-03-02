using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
  Trey Shaw

  This script will activate the doors when interacted with.
  For now, it will just contain functions, and we'll connect
  them to events later.
*/

public class DoorScript : MonoBehaviour
{
    //get number of scenes in the build
    //scene 0 is the main menu, scene 1 is the hallway

    [Range(0.0f, 1.0f)]
    public float winChance = 0.01f;
    int sceneCount;

    void Start() {
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    public void OpenDoor(){
        if (Random.value <= winChance) {
            Debug.Log("You Win!");
        } else {
            SceneManager.LoadScene(Random.Range(2, sceneCount));
        }
    }
}
