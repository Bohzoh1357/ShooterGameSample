using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public float MaxRadius = 5f;
    public float Interval = 2f;
    public GameObject ObjToSpawn = null;
    public GameObject ObjToSpawn2 = null;
    private Transform Origin = null;
    public float intensify = 15;
    public int lvl = 0;
    public float gameTime = 0f;

    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
        InvokeRepeating("Spawn2", 0f, Interval / 0.75f);
    }

    void Spawn()
    {
        gameTime += Interval;

        if (Origin == null || gameTime > 45f)
        {
            return;
        }

        lvl = (int)Time.timeSinceLevelLoad / (int)intensify;
        //Debug.Log(lvl);
        for (int x = 0; x < lvl + 1; x++)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
        }

    }

    void Spawn2()
    {
        gameTime += Interval / 0.75f;

        if (Origin == null || gameTime > 45f)
        {
            return;
        }

        lvl = (int)Time.timeSinceLevelLoad / (int)(0.8f*intensify);
        //Debug.Log(lvl);
        for (int x = 0; x < lvl + 1; x++)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn2, SpawnPos, Quaternion.identity);
        }

    }
}
