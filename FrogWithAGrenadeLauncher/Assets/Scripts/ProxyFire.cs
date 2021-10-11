using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyFire : MonoBehaviour
{
    private GameObject fly;
    private MoverAway speedAway;
    private Mover speedTowards;
    public float UsualSpeed = 3f;
    private bool triggered = false;
    public Transform[] TurretTransforms;
    private bool CanFire = true;
    public float reloadDelay = 0.3f;

    private void Start()
    {
        fly = GetComponent<GameObject>();
        speedAway = fly.GetComponent<MoverAway>();
        speedTowards = fly.GetComponent<Mover>();
        speedTowards.MaxSpeed = UsualSpeed;
        speedAway.MaxSpeed = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            speedTowards.MaxSpeed = 0;
            speedAway.MaxSpeed = UsualSpeed;
            triggered = false;
            // STOP SHOOTING
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            // Add firing mechanism for firing
            // make fire rate every 0.2 seconds (shotTime += Time.deltaTime; if (shotTime > 0.2) {shotTime = 0; fireBullet();}

        }
    }
    */

    private void Update()
    {
        if (triggered && CanFire)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            Invoke("EnableFire", reloadDelay);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            speedAway.MaxSpeed = 0f;

            // START SHOOTING
            triggered = true;
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }

}

