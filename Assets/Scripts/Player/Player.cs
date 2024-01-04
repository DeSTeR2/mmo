using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float exp, health, mana;

    [SerializeField] private Slider s_level, s_health, s_mana;
    [SerializeField] private float damageAmount, headAmount, wasteManaAmount;
    void Start()
    {
        exp = 0;
        health = s_health.maxValue;
        mana = s_mana.maxValue;

        Variables.Object(this).Set("Level", 1);
        Variables.Object(this).Set("Exp", exp);
        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Mana", mana);

        string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "1";

    }

    // Update is called once per frame
    void Update()
    {
        mana = (float)(Variables.Object(this).Get("Mana"));
        health = (float)(Variables.Object(this).Get("Health"));
        exp = (float)(Variables.Object(this).Get("Exp"));


        mana = Mathf.Min(mana, s_mana.maxValue);
        health = Mathf.Min(health, s_health.maxValue);
        if (mana < 0) mana = 0;
        if (health < 0) health = 0;

        if (s_level.maxValue <= exp) {
            exp -= s_level.maxValue;
            string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            int lvl = int.Parse(text) + 1;
            text = lvl.ToString();
            s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        }

        Variables.Object(this).Set("Mana", mana);
        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Exp", exp);

        
        s_level.value = exp;
        s_health.value = health;
        s_mana.value = mana;
    }
}
