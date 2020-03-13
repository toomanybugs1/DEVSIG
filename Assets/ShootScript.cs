using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject gun, shootPoint;
    Animator gunAnimator, lineAnimator;
    LineRenderer lr;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        lr = shootPoint.GetComponent<LineRenderer>();

        gunAnimator = gun.GetComponent<Animator>();
        lineAnimator = shootPoint.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            gun.transform.LookAt(hit.point);
            if (Input.GetMouseButtonDown(0)) {
                fire(hit.point);
            }
        }
    }

    void fire(Vector3 hitPoint) {
        lr.SetPosition(0, shootPoint.transform.position);
        lr.SetPosition(1, hitPoint);
        lineAnimator.Play("SmokeShootAnim");
        gunAnimator.Play("ShootAnim");
    }
}
