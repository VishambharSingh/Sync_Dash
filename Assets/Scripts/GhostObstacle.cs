using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObstacle : MonoBehaviour
{
    public Camera ghostCamera;
    // Start is called before the first frame update
    void Start()
    {
        ghostCamera = ObstaclesSpawner.Instance.ghostCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < ghostCamera.gameObject.transform.position.z)
        {
            ObstaclesSpawner.Instance.ChangeObstaclePos(gameObject,false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MyEvents.HitGhostObstacle?.Invoke();
        }
    }
}
