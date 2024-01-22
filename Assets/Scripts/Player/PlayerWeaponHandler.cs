using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    GameObject curWeapon;
    [SerializeField] private Transform weaponHolder;

    void dropWeapon() {
        if (curWeapon != null) {
            curWeapon.GetComponent<WeaponData>().deletePosition();
            curWeapon.transform.SetParent(default, true);
        }
    }

    public void setWeapon(GameObject weapon) {
        if (curWeapon == weapon) return;
        dropWeapon();
        weapon.GetComponent<WeaponData>().setPosition(weaponHolder);
        curWeapon = weapon;
    }
}
