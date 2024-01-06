using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour {
    [SerializeField] private int health;
    [SerializeField] private GameObject showDamagePanel;
    [SerializeField] private Canvas damagePanelCanvas;
    [SerializeField] private float offset;
    // Start is called before the first frame update

    public bool playerHit = false;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Variables.Object(this).IsDefined("Health") == true) {
            health = (int)Variables.Object(this).Get("Health");
        }
    }

    public void getDamaged(int amound) {
        if (amound > 0) amound *= -1;

        GameObject newDamagePanel = showDamagePanel;
        newDamagePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = amound.ToString();
        if (playerHit == true) {
            newDamagePanel.GetComponent<Image>().color = new Color(0, 255, 152);
            playerHit = false;
        } else newDamagePanel.GetComponent<Image>().color = new Color(0, 0, 0);
        Instantiate(newDamagePanel, this.gameObject.transform.position + new Vector3(UnityEngine.Random.Range(-offset, offset), 2, UnityEngine.Random.Range(-offset, offset)), Quaternion.identity, damagePanelCanvas.transform);
        health += amound;
        if (Variables.Object(this).IsDefined("Health") == true) {
            Variables.Object(this).Set("Health", health);
        } 
        
    }

    public int getHealth() {
        return health;
    }

}
