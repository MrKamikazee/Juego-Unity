using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
using UnityEngine.Audio;
public class clipCheckpoint : MonoBehaviour
{
    public AudioSource clipCheck;
    public GameObject clipCheckP;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clipCheck.Play();
            Destroy(gameObject,1);
        }
    }
}
