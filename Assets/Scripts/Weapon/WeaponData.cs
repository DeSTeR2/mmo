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

    private void Start() {
        if (position == null) {
            position = transform;
        }
    }

    private void Update() {
        if (this.transform != position) { 
            this.transform.SetParent(position, true);
        }

        this.GetComponent<Transform>().position = position.position;
        this.transform.localRotation = Quaternion.identity * Quaternion.EulerRotation(rotation);
    }

    private void OnTriggerEnter(Collider target) {
        DamageController curCollision = target?.gameObject?.GetComponent<DamageController>();
        EnemyStun enemyStun = target?.gameObject?.GetComponent<EnemyStun>();

        curCollision?.getDamaged(damage);

        if (enemyStun != null && stunTime > 0) {
            enemyStun?.Stun(stunTime);
        }
    }
}
