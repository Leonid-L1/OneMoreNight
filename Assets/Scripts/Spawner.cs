using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public  void Spawn(MonoBehaviour objectToSpawn, Vector2 spawnPoint)
    {
        Instantiate(objectToSpawn.gameObject, spawnPoint, Quaternion.identity);
    }
}
