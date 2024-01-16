using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CharacterAnimation{
    class c_AtackAnim : IAnimation {
        
        public GameObject Head, Neck, LeftHand, RightHand, LeftLeg, RigthLeg, Body;
        public float duration;

        private GameObject g_arm;
        private GameObject g_forearm;
        public c_AtackAnim(GameObject rigthHand, float duration) {
            RightHand = rigthHand;
            this.duration = duration;
            g_arm = RightHand.transform.GetChild(0).gameObject;
            g_forearm = RightHand.transform.GetChild(0).transform.GetChild(0).gameObject;
        }

        public async void startAnimation() {
            await atack();
        }
        
        private Task atack() {
            Transform t_arm = RightHand.transform.GetChild(0).transform;
            Transform t_forearm = RightHand.transform.GetChild(0).transform.GetChild(0).transform;

            var tsc = new TaskCompletionSource<bool>();

            DOTween.Sequence()
                .Append(t_forearm.DOLocalRotate(new Vector3(74.547f, -113f, -113f), duration * 0.2f))
                .Join(t_arm.DOLocalRotate(new Vector3(68.547f, -70.223f, -93.223f), duration * 0.15f))
                //.Join(t_forearm.DOLocalRotate(new Vector3(75.884f, -100.195f, -86.873f), d_atackAnim * 0.15f))
                .Append(t_forearm.DOLocalRotate(new Vector3(9.707f, 0, -13.997f), duration * 0.1f))
                .Join(t_arm.DOLocalRotate(new Vector3(14.762f, 17.307f, -22.186f), duration * 0.1f))
                .Append(t_forearm.DOLocalRotateQuaternion(g_forearm.transform.localRotation, duration * 0.13f))
                .Join(t_arm.DOLocalRotateQuaternion(g_arm.transform.localRotation, duration * 0.13f))
                .AppendCallback(() => tsc.SetResult(true))
                .OnKill(() =>
                {
                            
                    t_arm.localRotation = g_arm.transform.localRotation;
                    t_forearm.localRotation = g_forearm.transform.localRotation;

                    tsc.SetResult(true);
                });

            return tsc.Task;
        }
    }
}