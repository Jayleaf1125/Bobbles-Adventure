using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            int coinVal = Convert.ToInt32(collision.GetComponent<Coin>().coinValue);
            string currentCoinVal = coinCounter.text;
            int numOfCoins = Convert.ToInt32(currentCoinVal);
            numOfCoins += coinVal;

            coinCounter.text = Convert.ToString(numOfCoins);    

            Destroy(collision.gameObject);
        }
    }
}
