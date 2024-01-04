using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Factory;
using System;
using System.Linq;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.EventSystems;
using System.Security.Cryptography;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public Dictionary<string, int> amound;
    public GameObject buttonPref;
    public GameObject player;

    private AbilityFactory factory;

    void Start()
    {

        amound = new Dictionary<string, int>();
        amound.Add("damage", -11);
        amound.Add("heal", 50);
        amound.Add("addExp", 11);

        factory = new AbilityFactory();
        Dictionary<string, Type> abilities = factory.GetAllNames();

        int i = 0;
        foreach (KeyValuePair<string, Type> keys in abilities) {
            GameObject button = (GameObject)Instantiate(buttonPref);
            button.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = keys.Key;
            Vector3 position = this.transform.position;
            button.transform.parent = this.transform;
            button.name = keys.Key;
            button.transform.GetChild(0).name = keys.Key; 
            button.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            position.y += i * 150;
            button.transform.position = position;
            button.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(abilityClick);
            i++;
        }

    }

    void abilityClick() {
        string clickedButton = EventSystem.current.currentSelectedGameObject.name;
        Ability ability = factory.GetAbility(clickedButton); 
        if( ability == null) {
            print("There is no ability with such name: " + clickedButton);
        }
        else {
            ability.Process(player, amound[clickedButton], player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
