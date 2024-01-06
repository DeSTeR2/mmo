using Fabric.DropItem;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Fabric.DropItem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private int exp, health, mana;

    [SerializeField] private Slider s_level, s_health, s_mana;
    [SerializeField] private float damageAmount, headAmount, wasteManaAmount;
    [SerializeField] private GameObject NumberAnimation_Handler;

    private int p_exp, p_health, p_mana;
    private NumbersAimation uiAnim;
    void Start()
    {
        uiAnim = NumberAnimation_Handler.GetComponent<NumbersAimation>();

        uiAnim.showAnim("Mana", -10);

        exp = 0;
        health = (int)s_health.maxValue;
        mana = (int)s_mana.maxValue;

        Variables.Object(this).Set("Level", 1);
        Variables.Object(this).Set("Exp", exp);
        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Mana", mana);

        string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "1";

    }

    // Update is called once per frame
    void Update()
    {
        mana = (int)(Variables.Object(this).Get("Mana"));
        health = (int)(Variables.Object(this).Get("Health"));
        exp = (int)(Variables.Object(this).Get("Exp"));

        if (mana != p_mana) {
            uiAnim.showAnim("Mana", mana-p_mana);
        }

        if (exp != p_exp) {
            uiAnim.showAnim("Exp", exp-p_exp);
        }

        if (health != p_health) {
            uiAnim.showAnim("Damage", health-p_health);
        }

        mana = (int)Mathf.Min(mana, s_mana.maxValue);
        health = (int)Mathf.Min(health, s_health.maxValue);
        if (mana < 0) mana = 0;
        if (health < 0) health = 0;

        if (s_level.maxValue <= exp) {
            exp -= (int)s_level.maxValue;
            string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            int lvl = int.Parse(text) + 1;
            text = lvl.ToString();
            s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        }

        Variables.Object(this).Set("Mana", mana);
        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Exp", exp);

        p_exp = exp;
        p_mana = mana;
        p_health = health;

        s_level.value = exp;
        s_health.value = health;
        s_mana.value = mana;
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
