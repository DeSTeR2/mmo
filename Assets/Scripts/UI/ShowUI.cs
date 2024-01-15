using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject target;
    [SerializeField] int animTime;

    public int amountOnText = 0;

    private void Start() {
        DOTween.Init();
        string text = amountOnText.ToString();
        if (amountOnText > 0) {
            text = "+" + text;
        }
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        anim();
    }

    private void anim() {
        transform.DOMove(target.transform.position, animTime);
        Destroy(this.gameObject, animTime + (float)0.1);
        DOTween.Play(this);
    }
}
