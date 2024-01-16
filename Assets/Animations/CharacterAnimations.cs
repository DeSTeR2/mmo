using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CharacterAnimation;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] GameObject Head, Neck, LeftHand, RightHand, LeftLeg, RigthLeg, Body;

    [SerializeField] float d_StandAnim;


    private void Start() {
        DOTween.Init();
    }
    private void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            c_StandAnimation anim = new c_StandAnimation(Head, RightHand, d_StandAnim);
            anim.startAnimation();
        }
    }

}
