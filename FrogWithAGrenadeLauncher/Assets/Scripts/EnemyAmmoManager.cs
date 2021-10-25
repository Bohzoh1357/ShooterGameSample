using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoManager : MonoBehaviour
{
    public static EnemyAmmoManager AmmoManagerSingleton = null;
    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] AmmoArray;

    private void Awake()
    {
        if (AmmoManagerSingleton != null)
        {
            Destroy(GetComponent<EnemyAmmoManager>());
            return;
        }
        AmmoManagerSingleton = this;

        AmmoArray = new GameObject[PoolSize];
        for (int i = 0; i < PoolSize; ++i)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform ObjTransform = AmmoArray[i].transform;
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;
        // added this to keep object from taking velocity of parent
        SpawnedAmmo.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    }
}