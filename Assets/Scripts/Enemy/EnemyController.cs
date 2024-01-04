using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float timeToHit;
    [SerializeField] private Slider s_health;

    private float timer, health;
    private bool allowHit = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = this.GetComponent<DamageController>().getHealth();
        s_health.value = health;
        if(!allowHit) timer += Time.deltaTime;

        if (timer >= timeToHit) {
            timer = 0;
            allowHit = true;
        }

        if (health <= 0) {
            this.GetComponent<DeadLogic>().dead();
        }
    }



    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            DamageController damageController = other.gameObject.GetComponent<DamageController>();

            if (damageController != null) 
                if (allowHit) {
                    damageController.playerHit = true;
                    damageController.getDamaged(-10); allowHit=false;
                }
        }
    }




}
