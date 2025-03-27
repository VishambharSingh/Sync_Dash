using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public static ObstaclesSpawner Instance;
    public GameObject obstaclePrefab, ghostObstaclePrefab;
    public GameObject orbsPrefab, ghostOrbsPrefab;
    public Transform ghostObstacleStartingPoint;
    public int maxObstacleToSpawn = 10;
    public int maxOrbsToSpawn = 10;
    public Camera ghostCamera;
    float lastObstaclePos, lastOrbsPos,positionRefrence;
    //Queue<GameObject> obstacleQueue = new Queue<GameObject>();
    bool isObstacle;

    private void Start()
    {
        Instance = this;
        
        SpawnInitialObstaclesOrOrbs(obstaclePrefab,ghostObstaclePrefab, maxObstacleToSpawn,0,true,20);
        SpawnInitialObstaclesOrOrbs(orbsPrefab, ghostOrbsPrefab,maxOrbsToSpawn,1.5f,false,30);
    }

    // Object Pooling - Instantiating specifc number of obstacles and orbs and keep on re-using it throughtout the game 
    private void SpawnInitialObstaclesOrOrbs(GameObject myPrefab, GameObject ghostPrefab, int maxNumber, float yPos,bool isObstacle,float range)
    {
        positionRefrence = gameObject.transform.position.z;
        for (int i = 0; i < maxNumber; i++)
        {
            positionRefrence = positionRefrence + UnityEngine.Random.Range(10, range);
            GameObject obstacle = Instantiate(myPrefab, gameObject.transform);
            GameObject ghostObstacle = Instantiate(ghostPrefab, gameObject.transform);
            obstacle.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +yPos, positionRefrence);
            ghostObstacle.transform.position = new Vector3(ghostObstacleStartingPoint.position.x, gameObject.transform.position.y +yPos, positionRefrence);
            positionRefrence = obstacle.transform.position.z;
            //obstacleQueue.Enqueue(obstacle);
        }
        if (isObstacle)
        {
            lastObstaclePos = positionRefrence;
        }
        else
        {
            lastOrbsPos = positionRefrence;
        }
    }

    public void ChangeObstaclePos(GameObject myObstacle, bool isLastPosUpdated)
    {
        Debug.Log("Chnage Obstacle Called");
        //obstacleQueue.Dequeue();
        if(isLastPosUpdated)
        lastObstaclePos = lastObstaclePos + UnityEngine.Random.Range(10, 20);
        myObstacle.transform.position = new Vector3(myObstacle.transform.position.x, myObstacle.transform.position.y, lastObstaclePos);
        //obstacleQueue.Enqueue(myObstacle);
    }  
    public void ChangeOrbsPos(GameObject myOrbs, bool isLastPosUpdated)
    {
        Debug.Log("Chnage Obstacle Called");
        //obstacleQueue.Dequeue();
        if(isLastPosUpdated)
        lastOrbsPos = lastOrbsPos + UnityEngine.Random.Range(10, 30);
        myOrbs.transform.position = new Vector3(myOrbs.transform.position.x, myOrbs.transform.position.y, lastOrbsPos);
        //obstacleQueue.Enqueue(myOrbs);
    }
}

