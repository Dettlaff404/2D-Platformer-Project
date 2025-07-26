using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    [SerializeField] private AudioSource playerDyingSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerScript.thisGameManagerScript.GameOver();
            playerDyingSound.Play();
        }
    }
}
