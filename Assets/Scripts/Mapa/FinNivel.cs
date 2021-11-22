using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNivel : MonoBehaviour
{
    public int nivel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (nivel == 1 && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Nivel 2");
        }
        else if (nivel == 2 && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Nivel 3");
        }
    }
}
