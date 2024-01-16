using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CharacterAnimation {
    class c_StandAnimation : IAnimation{

        private GameObject Head, Neck, LeftHand, RightHand, LeftLeg, RigthLeg, Body;

        private float duration;

        public c_StandAnimation(GameObject Head, GameObject RightHand, float duration) {
            this.Head = Head;
            this.RightHand = RightHand;
            this.duration = duration;
        }

        public async void startAnimation() {
            await HeadRotation();
            await InspectWeapon();
        }



        private Task InspectWeapon() {
            Transform defRightArm_Transform = RightHand.transform.GetChild(0).transform.GetChild(0);
            Transform defForeArm_Transform = RightHand.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
            Transform defHeadTransform = Head.transform;

            var tcs = new TaskCompletionSource<bool>();

            GameObject arm = RightHand.transform.GetChild(0).transform.GetChild(0).gameObject;
            GameObject forearm = RightHand.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;

            DOTween.Sequence()
                .Append(arm.transform.DOLocalRotate(new Vector3(76.013f, -77.911f, -80.529f), duration * 0.3f))
                .Join(Head.transform.DOLocalRotate(new Vector3(-16, 53.872f, -20.785f), duration * 0.3f))
                .Join(forearm.transform.DOLocalRotate(new Vector3(0.504f, -49.726f, 5.655f), duration * 0.2f))
                .AppendInterval(duration * 0.2f)
                .Append(forearm.transform.DOLocalRotate(new Vector3(-5.653f, 50.67f, -0.526f), duration * 0.2f))
                .AppendInterval(duration * 0.2f)
                .Append(forearm.transform.DOLocalRotateQuaternion(defForeArm_Transform.localRotation, duration * 0.2f))
                .Append(arm.transform.DOLocalRotateQuaternion(defRightArm_Transform.localRotation, duration * 0.2f))
                .Join(Head.transform.DOLocalRotateQuaternion(defHeadTransform.localRotation, duration * 0.2f))
                .AppendCallback(() => tcs.SetResult(true))
                .OnKill(() =>
                {
                    forearm.transform.localRotation = defForeArm_Transform.localRotation;
                    arm.transform.localRotation = defRightArm_Transform.localRotation;
                    Head.transform.localRotation = defHeadTransform.localRotation;

                    tcs.SetResult(true);
                });
            return tcs.Task;
        }

        private Task HeadRotation() {
            Transform defHeadTransform = Head.transform;

            var tcs = new TaskCompletionSource<bool>();

            DOTween.Sequence()
                .Append(Head.transform.DOLocalRotate(new Vector3(-16, 53.872f, -20.785f), duration * 0.3f))
                .Append(Head.transform.DOLocalRotate(new Vector3(-24, -25, 10.5f), duration * 0.3f))
                .Append(Head.transform.DOLocalRotateQuaternion(defHeadTransform.localRotation, duration * 0.3f))
                .AppendCallback(() => tcs.SetResult(true));
            return tcs.Task;
        }
    }
}