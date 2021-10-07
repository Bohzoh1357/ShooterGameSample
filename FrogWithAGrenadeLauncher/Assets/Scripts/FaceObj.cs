using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObj : MonoBehaviour
{

    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;

    private void Awake()
    {
        if (!FollowPlayer)
        {
            return;
        }
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if(PlayerObj != null)
        {
            ObjToFollow = PlayerObj.transform;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (ObjToFollow == null)
        {
            return;
        }

        // get direction to follow obj
        Vector3 DirToObject = ObjToFollow.position - transform.position;
        if(DirToObject != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(DirToObject.normalized, Vector3.up);
        }
    }
}
