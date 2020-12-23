using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public Transform target;
    public GameObject badBullet;
    public Transform badBulletSpawn;
    public Transform lookPos; 

    private void Start()
    {
        badBulletSpawn.transform.position = -new Vector3(0,0,1f);
        badBullet.transform.position = badBulletSpawn.transform.position;

        while (this.gameObject != null)
        {
            StartCoroutine(BeginSpawning());
            break;
        }
    }

    IEnumerator BeginSpawning()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnBullet();
        yield return new WaitForSeconds(2.0f);
    }

    private void Update()
    {
        transform.LookAt(target);
        Vector3 pos = lookPos.eulerAngles;

        if(this.gameObject == null)
        {
            StopCoroutine(BeginSpawning()); 
        }
    }

    void SpawnBullet()
    {
        Instantiate(badBullet, badBulletSpawn.transform.position, Quaternion.identity);
    }
}