using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HistoriaInicial : MonoBehaviour
{
    public CanvasGroup panelHistoria;
    public GameObject paredesInvicibles;

    private void Start()
    {
        StartCoroutine(TiempoHistoria());
    }

    IEnumerator TiempoHistoria()
    {
        yield return new WaitForSeconds(10);
        panelHistoria.DOFade(0, 0.5f);
        paredesInvicibles.SetActive(false);
    }
}
