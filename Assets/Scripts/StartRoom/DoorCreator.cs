using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorCreator : MonoBehaviour {
    [SerializeField] GameObject doorPrefab;
    float radius;

    void Start() {
        //scene count returns every scene so we subtract the first two
        //which represent the main menu and hall scene

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int doorAmount = sceneCount - 2;
        radius = (doorAmount / 2) + 5;

        //generate list of indicies for build scenes from 2 to length
        List<int> randList;
        for (int i = 2; i < sceneCount; i++)
            randList.append(i);

        for (int i = 0; i < doorAmount; i++) {
            float angle = (Mathf.PI * 2 / doorAmount) * i;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject newInstance = Instantiate(doorPrefab, pos, Quaternion.identity, transform);

            newInstance.transform.LookAt(transform.position);

            int curScene = randList.RemoveAt(Random.Range(0, randList.Count - 1));

            Scene level = SceneManager.GetSceneAt(curScene);

            newInstance.GetComponentInChildren<TMP_Text>().text = "" + level.difficulty;
            newInstance.GetComponentInChildren<SceneLoader>().setScene(level.scene.name);
        }
    }
}
