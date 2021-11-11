using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    bool climbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Climbable")
        {
            climbing = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Climbable")
        {
            climbing = false;
        }
    }

     // Update is called once per frame
    void Update()
    {
        if (climbing == true)
        {
            movement = new Vector3(0, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal")).normalized;
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
