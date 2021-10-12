using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAway : MonoBehaviour
{
    public float MaxSpeed;

    public void setSpeed(float spd)
    {
        MaxSpeed = spd;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MOVERAWAY SPEED: " + MaxSpeed);
        transform.position -= transform.forward * MaxSpeed * Time.deltaTime;
    }
}
