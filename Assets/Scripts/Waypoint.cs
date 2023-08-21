using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;

    void OnMouseDown()
    {
        if(isPlaceable)
        {
        // Debug.Log(transform.name);
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
        }
    }
}
