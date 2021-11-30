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
    public Animator Animator;

    public void IniciarCorrutina()
    {
        StartCoroutine(AtaqueJefe());
    }
    
    IEnumerator AtaqueJefe()
    {
        while (controlador)
        {
            yield return new WaitForSeconds(2 - (GameManager.instance.semillas * 0.5f));
            GameObject bolaGo = Instantiate(bola, bocaJefe.position, bocaJefe.rotation);
            Animator.SetBool("Dispara", true);
            yield return new WaitForSeconds(2 - (GameManager.instance.semillas * 0.5f));
        }
        controlador = true;
        Animator.SetBool("Dispara", false);
    }
}
