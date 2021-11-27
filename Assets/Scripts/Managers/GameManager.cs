using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Semilla Mechanichs")]
    public int semillas = 0;
    public TextMeshProUGUI textoSemillas;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("semillas") != 0)
        {
            semillas = PlayerPrefs.GetInt("semillas");
        }
    }

    private void Update()
    {
        textoSemillas.text = "= " + semillas.ToString();
    }
}
