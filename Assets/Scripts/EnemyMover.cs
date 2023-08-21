using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;


    void Start()
    {
        StartCoroutine(FollowingPath());
    }

    IEnumerator FollowingPath()
    {
        foreach(Waypoint waypoint in path)
        {
            // transform.position = waypoint.transform.position; -> It is just point to point ↓make it smooth.
            // Vector3.LERP(startPosition, endPosition, travelPercent) travelPercent -> 0 to 1.0

            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
