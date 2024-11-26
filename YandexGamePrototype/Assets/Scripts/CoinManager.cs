using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int numberOfCoins;
    [SerializeField] TextMeshProUGUI coinNumberText;
    
    void Start()
    {
        numberOfCoins = Progress.Instance.coins;
        coinNumberText.text = numberOfCoins.ToString();
    }
    
    public void AddOne()
    {
        numberOfCoins++;
        coinNumberText.text = numberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.coins = numberOfCoins;
    }
}
