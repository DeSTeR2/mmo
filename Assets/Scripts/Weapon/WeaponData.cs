using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponData : MonoBehaviour {
    public int damage;
    public float stunTime;
    public Transform position;

    private Vector3 rotation = new Vector3(0, 0, 90);
    
    public GameObject parent;

    PressSlider pressSlider;

    private void Start() {
        pressSlider = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<PressSlider>();
    }

    private void Update() {
        
        if (position != null) {
            setPosition(position);
        }

    }

    private void OnTriggerEnter(Collider target) {
        if (target==null || parent == null || target.gameObject == parent.gameObject) return;

        DamageController curCollision = target?.gameObject?.GetComponent<DamageController>();
        EnemyStun enemyStun = target?.gameObject?.GetComponent<EnemyStun>();

        curCollision?.getDamaged(damage);

        if (enemyStun != null && stunTime > 0) {
            enemyStun?.Stun(stunTime);
        }

    }

    private void setParent() {
        Transform cur = position;
        while (cur != null) {
            parent = cur.gameObject;
            cur = cur.parent;
        }
    }

    public void setPosition(Transform weaponHolder) {
        position = weaponHolder;
        this.transform.SetParent(position, true);
        this.transform.GetComponent<Transform>().position = position.position;
        this.transform.localRotation = Quaternion.identity * Quaternion.EulerRotation(rotation);
        this.transform?.GetChild(0).gameObject?.SetActive(false);
        setParent();
    }
    public void deletePosition() {
        position = null;
        pressSlider.DisAllow();
        this.transform.position += new Vector3(0, 0, 1f);
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        this.transform?.GetChild(0).gameObject?.SetActive(true);
        setParent();
    }
}
