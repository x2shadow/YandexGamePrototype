using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        if(target) transform.position = target.position;
    }
}
