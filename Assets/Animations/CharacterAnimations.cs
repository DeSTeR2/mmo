using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CharacterAnimation;
using UnityEngine.UIElements;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] GameObject Head, Neck, LeftHand, RightHand, LeftLeg, RigthLeg, Body;

    [SerializeField] float d_StandAnim, d_atackAnim = 3;

    private c_StandAnimation standAnimation;
    private c_AtackAnim atackAnimation;


    private float noMove_time = 0;

    private Vector3 bodyPos;
    private void Start() {

        bodyPos = this.transform.position;

        DOTween.Init();
        atackAnimation = new c_AtackAnim(RightHand, d_atackAnim);
        standAnimation = new c_StandAnimation(Head, RightHand, d_StandAnim);
    }
    private void Update() {

        #region Stand_animation
        if (noMove_time >= 20) {
            standAnimation.startAnimation();
            noMove_time = 0;
        }

        if (bodyPos != this.transform.position) {
            noMove_time = 0;
            bodyPos = this.transform.position;
        }

        if (bodyPos == this.transform.position) {
            noMove_time += Time.deltaTime;
        }
        #endregion



    }

    public void Atack() {
        atackAnimation.startAnimation();
    }


}
