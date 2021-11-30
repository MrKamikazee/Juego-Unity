using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BolaController : MonoBehaviour
{
    public float velocidad;
    private Vector2 error;

    private void Start()
    {
        error.x = GameManager.instance.player.transform.position.x + Random.Range(-2f, 2f);
        error.y = GameManager.instance.player.transform.position.y + Random.Range(-2f, 2f);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, error, velocidad * Time.deltaTime);
        if (transform.position.x == error.x && transform.position.y == error.y)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<RespawnPersonaje>().PlayerDamaged();
            other.transform.GetComponent<RespawnPersonaje>().TPCheckPoint();
            Destroy(gameObject);
            // clipDaño.Play();
        }
    }
}
