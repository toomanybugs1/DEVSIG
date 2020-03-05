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
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit)) {
                IInteractable interactable = hit.transform.GetComponent<IInteractable>();

                if (interactable == null) {return;}
                Debug.Log(interactable);
                interactable.OnInteract();
            }
        }
    }
}
