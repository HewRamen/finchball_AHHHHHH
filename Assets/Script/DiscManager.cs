using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscManager : MonoBehaviour
{
    public GameObject discPrefab;
    private GameObject currentDisc;

    void Start()
    {
        SpawnDisc();
    }

    void Update()
    {
        if (currentDisc != null && !currentDisc.GetComponent<DiscMovement>().isMoving)
        {
            ResetDisc();
            SpawnDisc();
        }
    }

    private void SpawnDisc()
    {
        currentDisc = Instantiate(discPrefab);
    }

    private void ResetDisc()
    {
        currentDisc.GetComponent<DiscMovement>().isMoving = false;
    }
}
