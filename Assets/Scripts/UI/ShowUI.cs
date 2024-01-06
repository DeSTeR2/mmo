using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] int animTime;

    private void Start() {
        DOTween.Init();
        anim();
    }

    private void anim() {
        transform.DOMove(target.position, animTime);
        Destroy(this.gameObject, animTime + (float)0.1);
        DOTween.Play(this);
    }
}
