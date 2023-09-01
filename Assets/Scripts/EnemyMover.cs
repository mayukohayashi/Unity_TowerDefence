using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]
    [Range(0f, 10f)]
    float speed = 1f;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowingPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowingPath()
    {
        foreach (Waypoint waypoint in path)
        {
            // transform.position = waypoint.transform.position; -> It is just point to point ↓make it smooth.
            // Vector3.LERP(startPosition, endPosition, travelPercent) travelPercent -> 0 to 1.0

            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            // enemy to face the forward
            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}
