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
}
