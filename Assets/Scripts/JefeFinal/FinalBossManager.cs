using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class FinalBossManager : MonoBehaviour
{
    public bool controlador = true;
    public GameObject bola;
    public Transform bocaJefe;

    public void IniciarCorrutina()
    {
        StartCoroutine(AtaqueJefe());
    }
    
    IEnumerator AtaqueJefe()
    {
        while (controlador)
        {
            GameObject bolaGo = Instantiate(bola, bocaJefe.position, bocaJefe.rotation);
            yield return new WaitForSeconds(4 - (GameManager.instance.semillas * 0.5f));
        }
        controlador = true;
    }
}
