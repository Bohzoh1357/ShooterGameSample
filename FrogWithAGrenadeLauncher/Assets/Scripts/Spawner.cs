using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float MaxRadius = 5f;
    public float Interval = 2f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    public float intensify = 15;
    public int lvl = 0;

    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    void Spawn()
    {
        if(Origin == null)
        {
            return;
        }

        lvl = (int)Time.timeSinceLevelLoad/(int)intensify;
        Debug.Log(lvl);
        for (int x = 0; x < lvl+1; x++){
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
        }
        
    }
}
