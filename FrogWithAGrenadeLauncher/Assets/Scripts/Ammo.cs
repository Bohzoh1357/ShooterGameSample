using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 10f;
    public float LifeTime = 2f;
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        if(H == null)
        {
            return;
        }
        if (other.gameObject.tag.Equals("Player"))
        {
            H.HealthPoints -= Damage;
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
