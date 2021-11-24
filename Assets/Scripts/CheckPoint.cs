using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    private int i = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RespawnPersonaje>().ReachedCheckPonit(transform.position.x, transform.position.y);
            other.GetComponent<RespawnPersonaje>().checkpoint[i].gameObject.SetActive(false);
            i++;
            other.GetComponent<RespawnPersonaje>().checkpoint[i].gameObject.SetActive(true);
            i++;
        }
    }
}
