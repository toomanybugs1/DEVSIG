using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCreator : MonoBehaviour {
    [SerializeField] GameObject doorPrefab;
    [SerializeField] int doorAmount;
    float radius;

    void Start() {
        radius = (doorAmount / 2) + 5;

        for (int i = 0; i < doorAmount; i++) {
            float angle = (Mathf.PI * 2 / doorAmount) * i;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject newInstance = Instantiate(doorPrefab, pos, Quaternion.identity, transform);
            newInstance.transform.LookAt(transform.position);
        }
    }
}
