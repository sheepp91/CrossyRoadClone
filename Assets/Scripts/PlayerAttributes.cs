using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car")
        {
            print("Died");
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        StartCoroutine(GameController.Instance.ReloadScene());
    }
}
