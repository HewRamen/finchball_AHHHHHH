using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DiscSpawnPoint : MonoBehaviour
{
    public GameObject discPrefab;

    public void SpawnDisc()
    {
        Instantiate(discPrefab, transform.position, transform.rotation);
    }


    internal void NotifyDiscLaunched()
    {
        throw new NotImplementedException();
    }
}
