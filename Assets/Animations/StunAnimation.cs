using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Collections.LowLevel.Unsafe;

public class StunAnimation : MonoBehaviour
{
    public float rotationDuration;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        RotateInfinitely();
    }

    void RotateInfinitely() {
        // Rotate the object 360 degrees around its up axis over the specified duration
        transform.DORotate(new Vector3(0f, 360f, 0f), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(RotateInfinitely); // Call RotateInfinitely again when the rotation completes
    }

}
