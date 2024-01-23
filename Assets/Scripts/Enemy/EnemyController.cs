using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Fabric;
using Factory;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float timeToHit;
    [SerializeField] private Slider s_health;

    private float timer, health;
    private bool allowHit = true;

    public bool isStun = false;

    private AbilityFactory abilityFactory;
    private Dictionary<string, float> coolDown, defCoolDown;

    GameObject stunStars;

    private void Start() {
        stunStars = GetComponent<EnemyStun>().GetStars();

        abilityFactory = new AbilityFactory();

        coolDown = new Dictionary<string, float>();
        coolDown.Add("damage", 0);
        coolDown.Add("heal", 0);
        coolDown.Add("addExp", 0);

        defCoolDown = new Dictionary<string, float>();
        defCoolDown.Add("damage", 5);
        defCoolDown.Add("heal", 2);
        defCoolDown.Add("addExp", 0);
    }

    void Update()
    {
        isStun = stunStars.active;

        health = this.GetComponent<DamageController>().getHealth();
        s_health.value = health;

        if (health <= 0) {
            this.GetComponent<DeadLogic>().dead();
        }

        if (isStun) return;

        foreach (var cool in defCoolDown) {
            coolDown[cool.Key] -= (float)Time.deltaTime;
        }

        if(!allowHit) timer += Time.deltaTime;

        if (timer >= timeToHit) {
            timer = 0;
            allowHit = true;
        }
    }



    private void OnTriggerStay(Collider other) {
        if (isStun == true) return;

        if (other.gameObject.tag == "Player") {
            DamageController damageController = other.gameObject.GetComponent<DamageController>();
            PlayerStun playerStun = other.gameObject.GetComponent<PlayerStun>();

            if (damageController != null) 
                if (allowHit) {
                    Ability ability = abilityFactory.GetAbility("damage");
                    ability.Process(this.gameObject, -1, coolDown["damage"]);
                    if (coolDown["damage"] < 0) coolDown["damage"] = defCoolDown["damage"];
                    allowHit=false;
                }
        }
    }



}
