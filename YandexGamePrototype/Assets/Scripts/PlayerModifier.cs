using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] new Renderer renderer;
    [SerializeField] Transform colliderTranform;
    [SerializeField] AudioSource pumpSound;
    [SerializeField] AudioSource shrinkSound;

    [SerializeField] Transform topSpine;
    [SerializeField] Transform bottomSpine;

    [SerializeField] int width;
    [SerializeField] int height;

    float widthMultiplier = 0.0005f;
    float heightMultiplier = 0.01f;

    void Start()
    {
        SetWidth(Progress.Instance.playerInfo.width);
        SetHeight(Progress.Instance.playerInfo.height);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) AddWidth(20);
        if(Input.GetKeyDown(KeyCode.D)) AddWidth(-20);

        if(Input.GetKeyDown(KeyCode.W)) AddHeight(20);
        if(Input.GetKeyDown(KeyCode.S)) AddHeight(-20);

        float offsetY = height * heightMultiplier + 0.17f;
        topSpine.position = bottomSpine.position + new Vector3(0, offsetY, 0);
        colliderTranform.localScale = new Vector3(1, 1.84f + height * heightMultiplier, 1);
    }

    public void AddWidth(int value)
    {
        width += value;
        renderer.material.SetFloat("_PushValue", width * widthMultiplier);
        if (value > 0) pumpSound.Play(); else shrinkSound.Play();
        Progress.Instance.playerInfo.width = width;
    }

    public void AddHeight(int value)
    {
        height += value;
        if (value > 0) pumpSound.Play(); else shrinkSound.Play();
        Progress.Instance.playerInfo.height = height;
    }

    public void SetWidth(int value)
    {
        width = value;
        renderer.material.SetFloat("_PushValue", width * widthMultiplier);
    }

    public void SetHeight(int value)
    {
        height = value;
    }

    public void HitBarrier()
    {
        if(height > 0)
        {
            AddHeight(-50);
        }
        else if (width > 0)
        {
            AddWidth(-50);
        }
        else Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
