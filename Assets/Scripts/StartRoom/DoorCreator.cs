using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DoorCreator : MonoBehaviour {
    [SerializeField] GameObject doorPrefab;
    int sceneCount;
    float radius;

    void Start() {
        sceneCount = SceneManager.sceneCountInBuildSettings;

        //doorAmount subtracts 2 because we dont want the menu screen
        //or the hall as loadable scenes
        int doorAmount = sceneCount - 2;
        radius = (doorAmount / 2) + 5;

        //list of scene indicies to generate from
        List<int> sceneNums = new List<int>();
        for (int i = 2; i < sceneCount; i++)
            sceneNums.Add(i);

        for (int i = 0; i < doorAmount; i++) {
            float angle = (Mathf.PI * 2 / doorAmount) * i;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject newInstance = Instantiate(doorPrefab, pos, Quaternion.identity, transform);

            newInstance.transform.LookAt(transform.position);

            //get random scene index, get the scene at the index, then
            //remove that index from the list
            int curIndex = Random.Range(0, sceneNums.Count);
            string curScene = SceneUtility.GetScenePathByBuildIndex(sceneNums[curIndex]);
            sceneNums.RemoveAt(curIndex);

            //assign difficulty above door based on first char of the scene name
            //will later be changed to a graphic most likely
            string diffText = " ";
            switch(curScene[0])
            {
                case 'E':
                    diffText = "Easy";
                    break;
                case 'M':
                    diffText = "Medium";
                    break;
                case 'H':
                    diffText = "Hard";
                    break;
                default:
                    diffText = "Easy";
                    break;
            }

            newInstance.GetComponentInChildren<TMP_Text>().text = diffText;
            newInstance.GetComponentInChildren<SceneLoader>().setScene(curScene);
        }
    }
}
