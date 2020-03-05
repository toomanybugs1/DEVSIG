using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonRaycast : MonoBehaviour
{
    Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                SceneLoader sceneLoader = hit.transform.GetComponent<SceneLoader>();

                if (sceneLoader) {
                    sceneLoader.loadScene();
                }
            }
        }
    }
}
