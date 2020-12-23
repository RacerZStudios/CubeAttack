using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform playerTarget;
    public bool isDead;
    public GameObject boss;
    public float speed = 1;
    [SerializeField] public HealthController hC;

    private void Update()
    {
        StartCoroutine(Spawner()); 
    }

    IEnumerator Spawner()
    {
        float moveStep = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveStep);
        if(Vector3.Distance(transform.position, playerTarget.transform.position) < 0.1f)
        {
            Vector3 movePos = transform.position;
            movePos -= playerTarget.transform.position;
            transform.position *= -1f; 
        }

        if(boss == null || isDead == true)
        {
            StopCoroutine(Spawner());
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player(Clone)")
        {
            hC.health -= 1;
            if (playerTarget.gameObject.activeInHierarchy.Equals(false) && hC.health <= 0)
            {
                Debug.Log("Try Again");
                hC.health = 5;
                playerTarget.gameObject.SetActive(true);
            }      
        }
    }
}