using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    void Start()
    {
        print("start");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        print("here");
        if (col.gameObject.tag == "Car")
        {
            print("Died");
        }
    }
}
