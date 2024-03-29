using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] public Transform respawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard"))
        {
            transform.position = respawn.transform.position;
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            print("Set checkpoint");
            respawn = other.transform;
        }
    }
}
