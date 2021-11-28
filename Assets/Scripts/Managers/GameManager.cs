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
    public TextMeshProUGUI textoSemillas;
    private Scene escenaActiva;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textoSemillas.text = "= " + semillas.ToString();
    }
}
