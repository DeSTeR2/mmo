using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetThisWeapon : MonoBehaviour
{
    pickUpPosition pickUp;
    PressSlider pressSlider;
    GameObject weapon;

    PlayerWeaponHandler weaponHandler;

    private void Start() {
        pressSlider = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<PressSlider>();
        weapon = transform.parent.gameObject;
        weaponHandler = GameObject.Find("Player").GetComponent<PlayerWeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        pickUp = this.transform.GetChild(0).gameObject.GetComponent<pickUpPosition>();
        if (pressSlider.Allowed()) {
            weaponHandler.setWeapon(weapon);
            //pressSlider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            pickUp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            pickUp.FadeBack();
            
        }
    }
}
