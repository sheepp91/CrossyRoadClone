using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.z -= speed * Time.deltaTime;
        transform.position = newPos;
    }
}
