using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManager : MonoBehaviour
{
    public GameObject curCollision;

    private void OnTriggerEnter(Collider other) {
        curCollision = other.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        curCollision = null;
    }
}
