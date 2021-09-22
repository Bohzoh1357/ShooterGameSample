using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField] private float _HealthPoints = 5f;

    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {

            Debug.Log("We are setting numbers~");
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
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HealthPoints = 0;
        }
    }
}
