using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PressSlider : MonoBehaviour
{
    public char reqButton;
    public float timeToPress;
    Slider slider;
    TextMeshProUGUI text;
    bool allow = false, startTimer = false;
    float timer = 0;

    void Start()
    {
        slider = GetComponent<Slider>();

        text = this.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        if (reqButton >= 'A' && reqButton <= 'Z') {
            text.text = reqButton.ToString();
            reqButton += (char)32; 
        }
        else text.text = (reqButton + (char)32).ToString();
    }

    void Update()
    {
        //if (allow) return;
        //if (allow) {
        //    setActiveChilde(false);
        //    return;
        //} else setActiveChilde(true);
        

        if (Input.anyKey) {
            foreach(char x in Input.inputString) {
                if (x == reqButton) startTimer = true;
                else {
                    startTimer = false;
                    timer = 0;
                }
            }
        } else startTimer = false;

        if (startTimer) {
            timer += Time.deltaTime;
            if (timer >= timeToPress) {
                allow = true;
                timer = 0;
                return;
            } else 
            slider.value = slider.maxValue / (timeToPress / timer);
        } else {
            startTimer = false;
            timer = 0;
            slider.value = slider.minValue;
            allow = false;
        }
    }

    private void setActiveChilde(bool active) {
        int childNumber = transform.childCount;
        for (int i = 0; i < childNumber; i++) 
            transform.GetChild(i).gameObject.SetActive(active);

    }
    public bool Allowed() {
        //setActiveChilde(false);
        return allow;
    }

    public void DisAllow() {
        allow = false;
        //setActiveChilde(true);
    }
}
