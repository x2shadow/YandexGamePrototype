using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator animator;

    float oldMousePositionX;
    float eulerY;

    public float speed = 3f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            oldMousePositionX = Input.mousePosition.x;
            animator.SetBool("Run", true);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;
            newPosition.x = Math.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;
                
            float deltaX = Input.mousePosition.x - oldMousePositionX;
            oldMousePositionX = Input.mousePosition.x;
            
            eulerY += deltaX;
            eulerY = Math.Clamp(eulerY, -70f, 70f);
            
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }

        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Run", false);
        }
    }
}
