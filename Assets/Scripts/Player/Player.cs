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
    private float ex, health, mana;

    [SerializeField]
    private Slider s_level, s_health, s_mana;
    void Start()
    {
        ex = 0;
        health = s_health.maxValue;
        mana = s_mana.maxValue;

        Variables.Object(this).Set("Health", health);
        Variables.Object(this).Set("Mana", mana);

    }

    // Update is called once per frame
    void Update()
    {
        mana = (float)(Variables.Object(this).Get("Mana"));
        health = (float)(Variables.Object(this).Get("Health"));


        mana = Mathf.Min(mana, s_mana.maxValue);
        health = Mathf.Min(health, s_health.maxValue);

        if (s_level.maxValue < ex) {
            ex -= s_level.value;
            string text = s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            int lvl = int.Parse(text) + 1;
            text = lvl.ToString();
            s_level.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        }

        
        s_level.value = ex;
        s_health.value = health;
        s_mana.value = mana;
    }
}
