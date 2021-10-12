using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField] private float _HealthPoints = 5f;
    public GameObject HurtParticlesPrefab = null;
    private float hurtSpaceTimer = 0.5f;
    private float hurtSpaceMax = 0.2f;

    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            if(HurtParticlesPrefab != null)
            {
                Instantiate(HurtParticlesPrefab, transform.position, transform.rotation);
                hurtSpaceTimer = 0f;
            }
            //Debug.Log("We are setting numbers~");
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if(DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
                }
                if (ShouldDestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }

            hurtSpaceTimer += Time.deltaTime;
            Debug.Log("HurtsPace Timer " + hurtSpaceTimer);
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        HealthPoints = 0;
    //    }
    //}
}
