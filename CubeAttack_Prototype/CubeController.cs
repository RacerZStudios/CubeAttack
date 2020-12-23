using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bullet;
    public Transform FirePosL;
    public Transform FirePosR;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        rb.velocity += Vector3.forward * 10;

        if (Input.GetKey(KeyCode.A))
            rb.velocity += Vector3.left * 10;

        if (Input.GetKey(KeyCode.S))
            rb.velocity += Vector3.back * 10;

        if (Input.GetKey(KeyCode.D))
            rb.velocity += Vector3.right * 10;

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, FirePosL.transform.position, FirePosL.transform.rotation);
            Instantiate(bullet, FirePosR.transform.position, FirePosR.transform.rotation);
        }
    }
}
