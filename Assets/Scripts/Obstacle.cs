using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Camera maincamera;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < maincamera.gameObject.transform.position.z) 
        {
            ObstaclesSpawner.Instance.ChangeObstaclePos(gameObject,true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MyEvents.HitMainObstacle?.Invoke();
            Invoke("Gameover", 0.5f);
        }
    }

    void Gameover() 
    {
        UIManager.Instance.gamePlay.SetActive(false);
        UIManager.Instance.gameOver.SetActive(true);
    }
}
