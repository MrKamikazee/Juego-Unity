using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoObjetos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<RespawnPersonaje>().PlayerDamaged();
            other.transform.GetComponent<RespawnPersonaje>().TPCheckPoint();
        }
    }
}
