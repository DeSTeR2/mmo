using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject expPrefab;
    [SerializeField] private float prefabOffset;
    [SerializeField] private int expNumber, healNumber, offsetNumber;
    [SerializeField] private float expAmound, healAmound, offsetAmound;
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
            Instantiate(newExp, this.transform.position + new Vector3(Random.Range(-prefabOffset, prefabOffset), this.transform.position.y + 0.5f, Random.Range(-prefabOffset, prefabOffset)), Quaternion.identity);
        }
    }
}
