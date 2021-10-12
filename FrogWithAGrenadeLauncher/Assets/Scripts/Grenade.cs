using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Damage = 100f;
    public float LifeTime = 20f;
    public GameObject explosion;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    // Check for when grenade has HIT THE SPOT!
    // ONCE it has, run the kill switch.
    // Detonate and destroy object. Create explosion gameobject.

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT SOMETHING");
        if (other.gameObject.tag.Equals("Detonate"))
        {

            Instantiate(explosion, transform.position, transform.rotation);
            Die();
        }
    }
 //   Health H = other.gameObject.GetComponent<Health>();
   //     if (H == null)
     //   {
      //      return;
       // }
        //if (!other.gameObject.tag.Equals("Player"))
       // {/
            //H.HealthPoints -= Damage;
         //   Die();
//}
void Die()
    {
        gameObject.SetActive(false);
    }
}
