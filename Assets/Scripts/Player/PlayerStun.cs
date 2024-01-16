using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour, IStun
{
    private Player Controller;
    private PlayerMovement playerMovement;
    private DamageController damageController;
    private PlayerVariableHandler playerVariableHandler;


    [SerializeField] GameObject stunBar;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        damageController = GetComponent<DamageController>();
        playerVariableHandler = GetComponent<PlayerVariableHandler>();
        Controller = GetComponent<Player>();
    }

    public void Stun(float duration) {
        Debug.Log("player stunned for " + duration);

        StartCoroutine(StunController(duration));
    }

    public IEnumerator StunController(float duration) {
        playerMovement.enabled = false;
        playerVariableHandler.enabled = false;



        yield return new WaitForSeconds(duration);
        playerMovement.enabled = true;
        playerVariableHandler.enabled = true;
    }
}
