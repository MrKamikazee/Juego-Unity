using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNivel : MonoBehaviour
{
    public int nivel;

    private void OnTriggerEnter(Collider other)
    {
        if (nivel == 1)
        {
            SceneManager.LoadScene("Nivel 2");
        }
        else if (nivel == 2)
        {
            SceneManager.LoadScene("Nivel 3");
        }
    }
}
