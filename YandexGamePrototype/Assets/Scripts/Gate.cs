using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] GateApperaence gateApperaence;
    [SerializeField] DeformationType deformationType;
    [SerializeField] int value;

    void OnValidate()
    {
        gateApperaence.UpdateVisual(deformationType, value);  
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>(); 
        
        if(playerModifier != null)
        {
            if(deformationType == DeformationType.Width)  playerModifier.AddWidth(value);
            if(deformationType == DeformationType.Height) playerModifier.AddHeight(value);
        }       

        Destroy(gameObject);
    }
}
