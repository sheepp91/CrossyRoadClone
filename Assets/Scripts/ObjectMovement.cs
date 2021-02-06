using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5;
    private float maxDistanceToDeath = -10;

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.z < maxDistanceToDeath)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            // Move
            pos.z -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
