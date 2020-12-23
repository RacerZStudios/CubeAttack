using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObj : MonoBehaviour
{
    public Vector2 pos;
    public Transform other;

    private void Update()
    {
        this.transform.position = other.transform.position;
        pos = new Vector2(other.position.z, 0);
    }
}
