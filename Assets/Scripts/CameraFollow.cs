using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 camFollow;
    public Transform Cube;
    float offset;
    float smoothSpeed=1f;
    // Start is called before the first frame update
    void Start()
    {
        offset = Cube.transform.position.z - transform.position.z;
    }

    // Using Late Update for updating camera's position slighlty after player
    private void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(transform.position.x,transform.position.y, Cube.position.z - offset);
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
