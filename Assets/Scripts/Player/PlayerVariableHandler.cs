using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVariableHandler : MonoBehaviour
{
    private int exp, health, mana; // cur variables 

    [SerializeField] private Slider s_level, s_health, s_mana;
    [SerializeField] private GameObject NumberAnimation_Handler;
    private int p_exp, p_health, p_mana; // previous variables 
    private NumbersAimation uiAnim;

    void Start()
    {

        exp = 1;
        health = (int)s_health.maxValue; 
        mana = (int)s_mana.maxValue;

        Variables.Object(this).Set("Level", 1);
        Variables.Object(this).Set("Exp", exp);
        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Mana", mana);
        uiAnim = NumberAnimation_Handler.GetComponent<NumbersAimation>();
        string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "1";

        s_health.value = health;
        s_mana.value = mana;
    }

    void Update()
    {
        mana = (int)(Variables.Object(this).Get("Mana"));
        health = (int)(Variables.Object(this).Get("Health"));
        exp = (int)(Variables.Object(this).Get("Exp"));

        if (mana != p_mana) {
            uiAnim.showAnim("Mana", mana - p_mana);
        }

        if (exp != p_exp) {
            uiAnim.showAnim("Exp", exp - p_exp);
        }

        if (health != p_health) {
            uiAnim.showAnim("Damage", health - p_health);
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
}
