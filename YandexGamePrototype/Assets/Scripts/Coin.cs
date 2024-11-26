using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject coinEffectPrefab;
    [SerializeField] float rotationSpeed = 80f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(coinEffectPrefab, transform.position, transform.rotation);
    }
}
