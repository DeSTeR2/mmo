using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersAimation : MonoBehaviour
{
    [SerializeField] private GameObject expUI, healthUI, manaUI;
    [SerializeField] private GameObject exp_target, health_target, mana_target;
    [SerializeField] private Canvas canvas;

    private void instantiate(GameObject go) {
        Instantiate(go, canvas.transform);
    }

    public void showAnim(string name, int amount) {
        GameObject new_;

        switch (name) {
            case "Exp":
                new_ = expUI;
                if (new_ == null) break;
                new_.GetComponent<ShowUI>().target = exp_target;
                break;
            case "Damage":
                new_ = healthUI;
                if (new_ == null) break;
                new_.GetComponent<ShowUI>().target = health_target;
                break;
            case "Mana": 
                new_ = manaUI;
                if (new_ == null) break;
                new_.GetComponent<ShowUI>().target = mana_target;
                break;
            default:
                new_ = null;
                break;
        }

        if (new_ == null) return;
        new_.GetComponent<ShowUI>().amountOnText = amount;
        new_.SetActive(true);
        instantiate(new_);
    }

}
