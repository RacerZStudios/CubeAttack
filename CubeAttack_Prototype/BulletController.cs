using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public HomingBullet hB;
    [SerializeField] public Transform bSpawner; 
  
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        if(hB == null)
        {
            return; 
        }
    }

    void CheckForNull()
    {
        if(hB.isDead == true)
        {
            Instantiate(hB.boss.gameObject, bSpawner.transform.position, Quaternion.identity);
            hB.boss.transform.localScale += new Vector3(0.025f,0.025f,0.025f);
            return; 
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += Vector3.forward * 1;

        Destroy(gameObject, 1); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "target")
        {
            hB.isDead = true;
            Destroy(collision.gameObject);
            if (hB.isDead == true)
            {
                CheckForNull();
                return; 
            }
        }
    }
}
