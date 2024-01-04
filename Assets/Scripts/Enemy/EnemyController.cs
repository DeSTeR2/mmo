using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) {
            print("Enemy 1 is dead");
        }
    }

    public void getDamaged(float amound) {
        health += amound;
        print("Damaged by player");
    }
}
