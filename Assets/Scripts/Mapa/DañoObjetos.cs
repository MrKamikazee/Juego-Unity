using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

public class DañoObjetos : MonoBehaviour
{
    public AudioSource clipDaño;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<RespawnPersonaje>().PlayerDamaged();
            other.transform.GetComponent<RespawnPersonaje>().TPCheckPoint();
            clipDaño.Play();
        }
    }
}
