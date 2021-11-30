using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCanvasFinal : MonoBehaviour
{
    public CanvasGroup panelGanaste, panelGracias;

    private void Start()
    {
        StartCoroutine(Mensajes());
    }

    IEnumerator Mensajes()
    {
        yield return new WaitForSeconds(1);
        panelGanaste.DOFade(1, 0.5f);
        yield return new WaitForSeconds(4);
        panelGanaste.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        panelGracias.DOFade(1, 0.5f);
        yield return new WaitForSeconds(4);
        panelGracias.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}

