using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public bool useOffset;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffset)
        {
            offset = player.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        player.Rotate(-vertical, 0, 0);

        float xAngle = player.eulerAngles.x;
        float yAngle = player.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = player.position - (rotation * offset);
       
        transform.LookAt(player);
    }
}
