using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int nroCheckPoint = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RespawnPersonaje>().ReachedCheckPonit(transform.position.x, transform.position.y);
            switch (nroCheckPoint)
            {
                case 1:
                    ActivarYDesactivarCheckPoint(0, other);
                    break;
                case 2:
                    ActivarYDesactivarCheckPoint(2, other);
                    break;
                case 3:
                    ActivarYDesactivarCheckPoint(4, other);
                    break;
                case 4:
                    ActivarYDesactivarCheckPoint(6, other);
                    break;
            }
        }
    }

    private void ActivarYDesactivarCheckPoint(int i, Collider2D other)
    {
        other.GetComponent<RespawnPersonaje>().checkpoint[i].SetActive(false);
        other.GetComponent<RespawnPersonaje>().checkpoint[i + 1].SetActive(true);
    }
}
