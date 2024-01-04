using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManager : MonoBehaviour
{
    public GameObject curCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        curCollision = other.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        curCollision = null;
    }
}
