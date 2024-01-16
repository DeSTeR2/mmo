using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour, IStun
{
    private EnemyController Controller;

    [SerializeField] GameObject stunBar;

    private void Start() {
        Controller = GetComponent<EnemyController>();
    }

    public void Stun(float duration) {
        Debug.Log("Enemy stunned");
        StartCoroutine(StunController(duration));
    }

    public IEnumerator StunController(float duration) {
        Controller.isStun = true;
        yield return new WaitForSeconds(duration);
        Controller.isStun = false;
    }

}
