using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour, IStun
{
    private EnemyController Controller;
    private CharacterAnimations animations;

    [SerializeField] GameObject stunBar, stunStars;

    private void Start() {
        Controller = GetComponent<EnemyController>();
        animations = GetComponent<CharacterAnimations>();
    }

    public void Stun(float duration) {
        //Debug.Log("Enemy stunned");
        StartCoroutine(StunController(duration));
    }

    public IEnumerator StunController(float duration) {
        Controller.isStun = true;
        stunStars.active = true;
        animations.enabled = false;
        yield return new WaitForSeconds(duration);
        Controller.isStun = false;
        stunStars.active = false;
        animations.enabled = true;
    }

}
