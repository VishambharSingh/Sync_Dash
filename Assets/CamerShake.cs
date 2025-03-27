using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{ 
    private Vector3 originalPosition;
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.5f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }
    private void OnEnable()
    {
        MyEvents.HitMainObstacle += TriggerShake;
    }

    private void OnDisable()
    {
        MyEvents.HitMainObstacle -= TriggerShake;
    }
    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;
            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}

