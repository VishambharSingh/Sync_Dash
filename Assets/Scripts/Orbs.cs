using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    Camera mainCamera;
    ParticleSystem myParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        myParticleEffect = GetComponentInChildren<ParticleSystem>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, -0.1f, 0));
        if (transform.position.z < mainCamera.transform.position.z)
        {
            ObstaclesSpawner.Instance.ChangeOrbsPos(gameObject,true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MyEvents.HitMainOrbs?.Invoke();
            ObstaclesSpawner.Instance.ChangeOrbsPos(gameObject, true);
        }
    }
}

    

    
