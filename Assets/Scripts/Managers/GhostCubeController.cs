using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCubeController : MonoBehaviour
{
    public ParticleSystem orbsParticleEffect;
    public ParticleSystem blastEffect;
    float previousZPosition; 
    float ghostScore; 

    private void OnEnable()
    {
        MyEvents.HitGhostOrbs += PlayParticleEffect;
        MyEvents.HitGhostObstacle += Gameover;
    }

    private void Start()
    {
        StartCoroutine(CalculateDistanceTrvaelled());
    }
    private void OnDisable()
    {
        MyEvents.HitGhostOrbs -= PlayParticleEffect;
        MyEvents.HitGhostObstacle -= Gameover;
    }

    

    IEnumerator CalculateDistanceTrvaelled()
    {
        yield return new WaitForSeconds(0.1f);
        float currentZPosition = transform.position.z;

        // Calculate distance traveled since last frame
        float distanceThisFrame = currentZPosition - previousZPosition;
        previousZPosition = currentZPosition;

        ghostScore = distanceThisFrame;// Update score based on distance
        MyEvents.UpdateGhostScore?.Invoke(ghostScore);
        StartCoroutine(CalculateDistanceTrvaelled());
    }

    private void PlayParticleEffect()
    {
        orbsParticleEffect.Play();
    }

    void Gameover()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        blastEffect.Play();
    }
}
