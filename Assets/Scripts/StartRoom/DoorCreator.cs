using UnityEngine;
using UnityEditor;
using TMPro;

public class DoorCreator : MonoBehaviour {
    [SerializeField] GameObject doorPrefab;
    [SerializeField] LevelScriptableObject[] scenes;
    float radius;

    void Start() {
        int doorAmount = scenes.Length;
        radius = (doorAmount / 2) + 5;

        for (int i = 0; i < doorAmount; i++) {
            float angle = (Mathf.PI * 2 / doorAmount) * i;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject newInstance = Instantiate(doorPrefab, pos, Quaternion.identity, transform);

            newInstance.transform.LookAt(transform.position);

            LevelScriptableObject level = scenes[i];

            newInstance.GetComponentInChildren<TMP_Text>().text = "" + level.difficulty;
            newInstance.GetComponentInChildren<SceneLoader>().setScene(level.scene.name);
        }
    }
}
