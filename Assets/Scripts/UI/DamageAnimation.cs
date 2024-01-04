using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageAnimation : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float animDuration;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DOTween.Init();
        startAnim();
    }

    // Update is called once per frame
    private void Update() {
        this.transform.rotation = Quaternion.identity;
    }
    private void startAnim() {
        Vector3 curPosition = this.transform.position;
        transform.DOMove(curPosition + new Vector3(0, 3, 0), animDuration);
        canvasGroup.DOFade(0, animDuration);
        Destroy(this.gameObject, animDuration);
        DOTween.Play(this);
    }
}
