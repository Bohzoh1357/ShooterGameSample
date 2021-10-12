using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleMvt : MonoBehaviour
{
    private bool FollowMouse = true;
    private float timer = 0f;
    private GameObject PlayerObj;
    private bool starttimer = false;

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        //PlayerObj = GameObject.FindGameObjectWithTag("Player");

        if (FollowMouse)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                               Input.mousePosition.y,
                                                                               0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
            transform.position = MousePosWorld;
        }

        //Debug.Log(Input.GetButtonDown("Fire1"));
        if (Input.GetButtonDown("Fire1") && PlayerObj.GetComponent<PlayerController>().CanFire)
        {
            Debug.Log("IN reticle lock");
            FollowMouse = false;
            starttimer = true;
        }
        if (starttimer)
        {
            timer += Time.deltaTime;
            if(timer > 6f)
            {
                starttimer = false;
                timer = 0f;
                FollowMouse = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT BY GRENADE");
        if (other.gameObject.tag.Equals("Grenade"))
        {
            FollowMouse = true;
            starttimer = false;
            timer = 0;
        }
    }
}
