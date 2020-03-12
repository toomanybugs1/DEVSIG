using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGizmo : MonoBehaviour
{
    [SerializeField] bool showing = true;

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if (showing) {
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
