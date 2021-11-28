using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
using UnityEngine.Audio;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    public int nroCheckpoint;
    public AudioSource CheckpointClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RespawnPersonaje>().ReachedCheckPonit(transform.position.x, transform.position.y);
            GameObject checkpointActive = Instantiate(checkpoint, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
