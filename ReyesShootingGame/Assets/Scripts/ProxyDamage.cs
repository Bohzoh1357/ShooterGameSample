using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{

    //  VARIABLES  //
    public float DamageRate = 10f; // The rate of damage per second.

    private void OnTriggerStay(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();

        if (H == null) { return; }
        H.HealthPoints -= DamageRate * Time.deltaTime;
    }
}
