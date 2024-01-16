using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemAnim : MonoBehaviour
{
    [SerializeField] private float minSpeed, maxSpeed;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 randomDir = new Vector3(Random.Range(-360,360), 50, Random.Range(-360, 360)).normalized;

        float speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = randomDir * speed;
    }

}
