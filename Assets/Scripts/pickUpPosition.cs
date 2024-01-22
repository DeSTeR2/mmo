using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickUpPosition : MonoBehaviour {

    public float addAlpha;

    bool fadeBack = false;
    Transform parentTransform;
    Transform transform;
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start() {
        transform = GetComponent<Transform>();
        canvasGroup = GetComponent<CanvasGroup>();

        parentTransform = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update() {
        if (!fadeBack) {
            if (canvasGroup.alpha < 1) {
                canvasGroup.alpha += addAlpha;
            }
        } else {
            if (canvasGroup.alpha > 0) {
                canvasGroup.alpha -= addAlpha;
            } else {
                this.gameObject.active = false;
                fadeBack = false;
            }
        }


        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        transform.localPosition = parentTransform.localPosition + new Vector3(0, 1, 0) * 0.05f;
        //transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }

    public void FadeBack() {
        fadeBack = true;
    }
}
