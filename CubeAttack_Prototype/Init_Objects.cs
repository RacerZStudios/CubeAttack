using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Objects : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    [SerializeField] HealthController hC;

    public void Awake()
    {
        Instantiate(player, player.transform.position, player.transform.rotation);
        Instantiate(boss, boss.transform.position, Quaternion.identity);
    }

    private void Start()
    {
        if (player == null || hC.health <= 0)
        {
            player.gameObject.SetActive(true);
        }
    }
}
