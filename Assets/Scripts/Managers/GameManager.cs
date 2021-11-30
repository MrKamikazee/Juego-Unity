using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public GameObject player;
    public CanvasGroup fondoNegro;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textoSemillas.text = "= " + semillas.ToString();
        if (semillas == 6)
        {
            StartCoroutine(Fin());
        }
    }

    IEnumerator Fin()
    {
        fondoNegro.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("FinalFeliz");
    }
}
