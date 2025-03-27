using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject leftMirroredPlayer;
    private Queue<Vector3> positionBuffer = new Queue<Vector3>();
    public ParticleSystem orbsParticleEffect;
    public ParticleSystem blastEffect;
    Vector3 targetPosition = Vector3.zero;
    public float lagTime = 0.5f;
    public float moveSpeed = 10F;
    public float previousZPosition;
    public float distanceTraveled;
    public float score = 0;
    float gameSpeed = 10F;
    float jumpForce = 5F;
    bool isGrounded;
    public float smoothFactor = 0.2f;
    Rigidbody myRigidbody;


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        MyEvents.HitMainOrbs += PlayOrbsHitEffect;
        MyEvents.HitMainObstacle += Gameover;
    }

    private void OnDisable()
    {
        MyEvents.HitMainOrbs -= PlayOrbsHitEffect;
        MyEvents.HitMainObstacle -= Gameover;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myRigidbody.useGravity = true;
        previousZPosition = transform.position.z;
        StartCoroutine(CalculateDistanceTrvaelled());

    }

    //Update is called once per frame
    void Update()
    {
        MoveForward();
        Jump();
        SyncMirroredPlayer();
        IncreaseGameSpeed();
    }

    private void IncreaseGameSpeed()
    {
        gameSpeed += Time.deltaTime * 0.1f;
        moveSpeed = gameSpeed;
    }

    //Checks if the cube is grounded and then jump it on pressing mouse button
    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            Debug.Log(isGrounded);
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void MoveForward()
    {
        myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, moveSpeed);
        positionBuffer.Enqueue(transform.position);


        // Limit the buffer size to maintain performance (simulating network delay)
        if (positionBuffer.Count > Mathf.Ceil(lagTime / Time.deltaTime))
        {
            positionBuffer.Dequeue();
        }
    }

    IEnumerator CalculateDistanceTrvaelled()
    {
        yield return new WaitForSeconds(0.1f);
        float currentZPosition = transform.position.z;

        // Calculate distance traveled since last frame
        float distanceThisFrame = currentZPosition - previousZPosition;
        previousZPosition = currentZPosition;

        score = distanceThisFrame;// Update score based on distance
        MyEvents.UpdateMainScore?.Invoke(score);
        StartCoroutine(CalculateDistanceTrvaelled());
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void SyncMirroredPlayer()
    {
        if (positionBuffer.Count < 2) return;

        // Get the position with simulated lag
        targetPosition = positionBuffer.Peek();
        targetPosition = new Vector3(leftMirroredPlayer.transform.position.x, targetPosition.y, targetPosition.z);

        // Interpolate the left-side player’s position using smoothing
        leftMirroredPlayer.transform.position = Vector3.Lerp(leftMirroredPlayer.transform.position, targetPosition, smoothFactor);
    }

    void PlayOrbsHitEffect()
    {
        orbsParticleEffect.Play();
    }

    void Gameover()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        blastEffect.Play();
    }
}

