using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;

    public void ResetPlayer()
    {
        stats.ResetPlayer();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Win !");
        }
        else if (collision.gameObject.CompareTag("Flower"))
        {
            stats.Cottons++;
            Destroy(collision.gameObject);
        }

    }
}
