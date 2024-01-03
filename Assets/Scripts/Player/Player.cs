using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float ex, health, mana;

    [SerializeField]
    private Slider s_level, s_health, s_mana;
    void Start()
    {
        ex = 0;
        health = s_health.maxValue;
        mana = s_mana.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        mana = Mathf.Max(mana, s_mana.maxValue);
        health = Mathf.Max(health, s_health.maxValue);

        if (s_level.value < ex) {
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
