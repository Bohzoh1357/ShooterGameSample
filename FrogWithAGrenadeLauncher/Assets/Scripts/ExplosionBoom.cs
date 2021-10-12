using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBoom : MonoBehaviour
{
    public float Damage = 100f;
    private float rotSpeed = 1080f;
    private float yRotation = 0f;
    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        yRotation += Time.deltaTime * rotSpeed;
        this.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        if(timer > 1.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        if (H == null)
        {
            return;
        }
        if (!other.gameObject.tag.Equals("Player"))
        {
            H.HealthPoints -= Damage;
        }
    }
}
