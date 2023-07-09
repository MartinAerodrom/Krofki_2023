using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text coinText;
    private int coins = 0;
    public GameObject Music;
    public AudioSource coinSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            coins++;
            coinText.text = coins.ToString();
            Destroy(other.gameObject);
            Music.GetComponent<AudioSource>().Play();
        }
    }
}