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
    private GameObject parent;

    private void Start() {

    }

    private void Update() {
        if (position != null) {
            this.transform.SetParent(position, true);
            this.transform.GetComponent<Transform>().position = position.position;
            this.transform.localRotation = Quaternion.identity * Quaternion.EulerRotation(rotation);

            if (parent == null) {
                Transform cur = position;
                while (cur != null) {
                    parent = cur.gameObject;
                    cur = cur.parent;
                }
            }
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

}
