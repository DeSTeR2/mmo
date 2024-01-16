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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the player based on the calculated direction and speed
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
        if (movement.magnitude >= 0.1f) {
            // Calculate the rotation to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        //rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, Input.GetAxis("Vertical") * speed)*Time.deltaTime;    
        //if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && rigidbody.velocity != Vector3.zero) {
        //}
    }
}
