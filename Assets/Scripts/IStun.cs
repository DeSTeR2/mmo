using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStun {
    public void Stun(float duration);
    public IEnumerator StunController(float duration);
}