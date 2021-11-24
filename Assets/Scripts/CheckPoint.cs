using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RespawnPersonaje>().ReachedCheckPonit(transform.position.x, transform.position.y);
            GameObject checkpointOn = Instantiate(checkpoint, transform.position, transform.rotation);
        }
    }
}
