using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PreFinishBehaviour preFinishBehaviour;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        playerMovement.enabled = true;
    }

    public void StartPreFinishBehaviour()
    {
        playerMovement.enabled = false;
        preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehaviour()
    {
        preFinishBehaviour.enabled = false;
        animator.SetTrigger("Dance");
    }
}
