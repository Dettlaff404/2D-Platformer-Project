using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public int coinScore = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerScript.thisGameManagerScript.scoreValue += 50;
            Destroy(this.gameObject);
        }
    }
}
