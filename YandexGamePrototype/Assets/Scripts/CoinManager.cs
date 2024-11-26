using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int numberOfCoinsInLevel;
    [SerializeField] TextMeshProUGUI coinNumberText;
    
    public void AddOne()
    {
        numberOfCoinsInLevel++;
        coinNumberText.text = numberOfCoinsInLevel.ToString();
    }
}
