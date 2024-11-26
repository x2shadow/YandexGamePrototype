using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;

    PlayerModifier playerModifier;

    void Start()
    {
        playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if(coinManager.numberOfCoins >= 20)
        {
            coinManager.SpendMoney(20);
            Progress.Instance.coins = coinManager.numberOfCoins;
            Progress.Instance.width += 25;
            playerModifier.SetWidth(Progress.Instance.width);
        }
    }

    public void BuyHeight()
    {
        if(coinManager.numberOfCoins >= 20)
        {
            coinManager.SpendMoney(20);
            Progress.Instance.coins = coinManager.numberOfCoins;
            Progress.Instance.height += 25;
            playerModifier.SetHeight(Progress.Instance.height);
        }
    }
}
