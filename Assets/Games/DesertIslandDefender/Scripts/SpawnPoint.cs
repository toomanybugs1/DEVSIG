using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);
        Gizmos.DrawLine(transform.position + Vector3.up, transform.position + Vector3.up + transform.forward);
    }
}
