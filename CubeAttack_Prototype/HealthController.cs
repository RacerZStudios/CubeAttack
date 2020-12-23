using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Text healthText;
    public int health;
    public GameObject badBullet;

    private void Start()
    {
        if (health <= 9.99999f)
        {
            health = 5;
        }

        healthText.text = GetComponentInChildren<Text>().text;
        healthText.text = health.ToString(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "badBullet(Clone)")
        {
            health--;
            healthText.text = health.ToString(); 
        }
    }
}
