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
            newInstance.GetComponentInChildren<TMP_Text>().text = scene.name;
            newInstance.GetComponentInChildren<SceneLoader>().scene = scene.name;
        }
    }
}
