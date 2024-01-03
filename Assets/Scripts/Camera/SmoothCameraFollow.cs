using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 curVelosity = Vector3.zero;

    private void Awake() {
        offset = transform.position - target.position; 
    }

    private void LateUpdate() {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref curVelosity,smoothTime);
    }
}
