using Fabric.DropItem;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public int exp, health, mana; // cur variables 

    [SerializeField] private Slider s_level, s_health, s_mana;
    [SerializeField] private float damageAmount, headAmount, wasteManaAmount;

    private int p_exp, p_health, p_mana; // previous variables 

    private PlayerMovement playerMovement;
    private DamageController damageController;
    private PlayerVariableHandler playerVariableHandler;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        damageController = GetComponent<DamageController>();
        playerVariableHandler = GetComponent<PlayerVariableHandler>();

        exp = 0;
        health = (int)s_health.maxValue;
        mana = (int)s_mana.maxValue;

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "DropItem") {
            
            DropItem item = new DropItem(other.gameObject.GetComponent<DropItemLogic>().getDropItem());

            if (item == null) 
                Debug.LogWarning(other.gameObject.name + " has no DropItemLogic");
            else {
                Variables.Object(this).Set(item.getName(), (int)Variables.Object(this).Get(item.getName()) + item.getValue());
                Destroy(other.gameObject);
            }

        }
    }

    public void setVariable(string Name, int value) {
        Variables.Object(this).Set(Name, value);
    }

    public int getVariable(string Name) {
        return (int)Variables.Object(this).Get(Name);
    }
}
