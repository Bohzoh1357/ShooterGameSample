using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float backgroundSpeed = 0.2f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad < 45f)
        {
            transform.position -= transform.forward * backgroundSpeed * Time.deltaTime;
        }
    }
}
