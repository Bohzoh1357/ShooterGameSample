using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyFire : MonoBehaviour
{
    private GameObject fly;
    private Mover speed;
    private float originalSpeed;
    private void Start()
    {
        fly = GetComponent<GameObject>();
        speed = fly.GetComponent<Mover>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            originalSpeed = speed.MaxSpeed;
            speed.MaxSpeed = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            // Add firing mechanism for firing
            // make fire rate every 0.2 seconds (shotTime += Time.deltaTime; if (shotTime > 0.2) {shotTime = 0; fireBullet();}

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            speed.MaxSpeed = originalSpeed;
        }
    }

}

