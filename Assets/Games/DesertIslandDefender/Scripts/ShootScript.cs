using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject gun, shootPoint, shootParticles;
    [SerializeField] int damage = 10;
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

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                CrabController enemy = hit.transform.GetComponent<CrabController>();
                if (enemy) {
                    enemy.Damage(damage);
                }
            } else {
                hit.point = cam.transform.position + (ray.direction * 10);
            }
            fire(hit.point);
        }

        //**********Gun originally pointed where you looked, animation breaks this fix later
        /*
        if (Physics.Raycast(ray, out hit)) {
            gun.transform.LookAt(hit.point);

            if (Input.GetMouseButtonDown(0)) {
                CrabController enemy = hit.transform.GetComponent<CrabController>();
                if (enemy) {
                    enemy.Damage(damage);
                }
                fire(hit.point);
            }
        }
        */
    }

    void fire(Vector3 hitPoint) {
        lr.SetPosition(0, shootPoint.transform.position);
        lr.SetPosition(1, hitPoint);
        Instantiate(shootParticles, shootPoint.transform);
        //gunAnimator.transform.localPosition = new Vector3(0.35f, 1.2f, 0.5f);
        lineAnimator.Play("SmokeShootAnim");
        gunAnimator.Play("ShootAnim");
    }
}
