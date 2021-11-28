using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Semilla Mechanichs")]
    public int semillas = 0;
    public GameObject[] semilla;
    public TextMeshProUGUI textoSemillas;
    private Scene escenaActiva;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        escenaActiva = SceneManager.GetActiveScene();
        switch (escenaActiva.name)
        {
            case "Nivel 1":
                if (PlayerPrefs.GetInt("semillas") == 1)
                {
                    semilla[0].SetActive(false);
                }
                if (PlayerPrefs.GetInt("semillas") == 2)
                {
                    semilla[0].SetActive(false);
                    semilla[1].SetActive(false);
                }
                break;
            case "Nivel 2":
                if (PlayerPrefs.GetInt("semillas") == 3)
                {
                    semilla[0].SetActive(false);
                }
                if (PlayerPrefs.GetInt("semillas") == 4)
                {
                    semilla[0].SetActive(false);
                    semilla[1].SetActive(false);
                }
                break;
            case "Nivel 3":
                if (PlayerPrefs.GetInt("semillas") == 5)
                {
                    semilla[0].SetActive(false);
                } 
                if (PlayerPrefs.GetInt("semillas") == 6)
                {
                    semilla[0].SetActive(false);
                    semilla[1].SetActive(false);
                }
                break;
        }
        semillas = PlayerPrefs.GetInt("semillas");
    }

    private void Update()
    {
        textoSemillas.text = "= " + semillas.ToString();
    }
}
