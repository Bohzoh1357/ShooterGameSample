using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MaxSpeed = 3f;

    public void setSpeed( float spd)
    {
        MaxSpeed = spd;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("MOVER SPEED = " + MaxSpeed);
        transform.position += transform.forward * MaxSpeed * Time.deltaTime;
    }
}