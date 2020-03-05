using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class DoorCreator : MonoBehaviour {
    [SerializeField] GameObject doorPrefab;
    [SerializeField] SceneAsset[] scenes;
    float radius;

    void Start() {
        int doorAmount = scenes.Length;
        radius = (doorAmount / 2) + 5;

        for (int i = 0; i < doorAmount; i++) {
            float angle = (Mathf.PI * 2 / doorAmount) * i;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject newInstance = Instantiate(doorPrefab, pos, Quaternion.identity, transform);

            newInstance.transform.LookAt(transform.position);

            SceneAsset scene = scenes[i];

            //we can keep track of difficulty with the first character of the scene
            //this way we don't tell the user the name of each scene, just it's difficulty
            //we will likely replace this with a graphic
            char diffChar = scene.name[0];
            string difficulty;

            switch (diffChar) {
                case 'E':
                    difficulty = "Easy";
                    break;
                case 'M':
                    difficulty = "Medium";
                    break;
                case 'H':
                    difficulty = "Hard";
                    break;
                default:
                    difficulty = "Easy";
                    break;
            }

            newInstance.GetComponentInChildren<TMP_Text>().text = difficulty;
            newInstance.GetComponentInChildren<SceneLoader>().setScene(scene.name);
        }
    }
}
