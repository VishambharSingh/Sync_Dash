using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostOrbs : MonoBehaviour
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
        transform.Rotate(new Vector3(0, -0.1f, 0));
        if (transform.position.z < ghostCamera.transform.position.z)
        {
            ObstaclesSpawner.Instance.ChangeOrbsPos(gameObject,false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MyEvents.HitGhostOrbs?.Invoke();
            ObstaclesSpawner.Instance.ChangeOrbsPos(gameObject, false);
        }
    }
}
