using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        
        if(playerModifier != null)
        {
            playerModifier.HitBarrier();
            Destroy(gameObject);
        }
    }
}
