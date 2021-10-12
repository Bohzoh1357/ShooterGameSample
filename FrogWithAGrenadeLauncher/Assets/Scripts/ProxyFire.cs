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

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        fly = transform.gameObject;
        speedAway = fly.GetComponent<MoverAway>();
        speedTowards = fly.GetComponent<Mover>();
        Debug.Log("Speed Towards has value " + speedTowards.MaxSpeed);
        speedTowards.setSpeed(UsualSpeed);
        speedAway.setSpeed(0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter trigger");
        if (other.gameObject.tag.Equals("ProxFrog"))
        {
            Debug.Log("Player hiton enter!");
            speedTowards.setSpeed(0f);
            speedAway.setSpeed(UsualSpeed);
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
            Debug.Log("TRIGGERED AND FIRING");
            foreach (Transform T in TurretTransforms)
            {
                EnemyAmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            Invoke("EnableFire", reloadDelay);

        }
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("exit trigger");
        if (other.gameObject.tag.Equals("ProxFrog"))
        {
            Debug.Log("Player hiton exit");
            speedAway.setSpeed(0f);
            // START SHOOTING
            triggered = true;
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }

}

