using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Fabric.DropItem;

public class DeadLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject expPrefab, healPrefab;
    [SerializeField] private float prefabOffset;
    [SerializeField] private int expNumber, healNumber, offsetNumber;
    [SerializeField] private int expAmound, healAmound, offsetAmound;

    private int random(int offset) {
        return Random.Range(-offset, offset);
    }
    private float random(float offset) {
        return Random.Range(-offset, offset);
    }

    void Start()
    {
        expNumber += Random.Range(-offsetNumber, offsetNumber);
        healNumber += Random.Range(-offsetNumber, offsetNumber);

        expAmound += Random.Range(-offsetAmound, offsetAmound);
        healAmound += Random.Range(-offsetAmound, offsetAmound);
    }


    public void dead() {
        while (expNumber > 0) {
            expNumber--;

            GameObject newExp = expPrefab;
            DropItem exp = new DropItem("Exp", expAmound + random(offsetAmound));
            newExp.GetComponent<DropItemLogic>().setDropItem(exp);
            Instantiate(newExp, this.transform.position + new Vector3(random(prefabOffset), this.transform.position.y + 0.5f, random(prefabOffset)), Quaternion.identity);
        }

        while (healNumber > 0) {
            healNumber--;

            GameObject newHeal = healPrefab;
            DropItem heal = new DropItem("Health", healAmound + random(offsetAmound));
            newHeal.GetComponent<DropItemLogic>().setDropItem(heal);
            Instantiate(newHeal, this.transform.position + new Vector3(random(prefabOffset), this.transform.position.y + 0.5f, random(prefabOffset)), Quaternion.Euler(0, 0, -180));
        }


        Destroy(this.gameObject);
    }
}
