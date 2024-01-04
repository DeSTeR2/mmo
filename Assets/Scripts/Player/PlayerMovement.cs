using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private Animator animator;
    private Rigidbody rigidbody;
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);    
        if (joystick.Horizontal !=0 || joystick.Vertical !=0) {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            
        }
    }
}
