using System.Collections;
using UnityEngine;

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
            Animator.SetBool("Dispara", true);
            yield return new WaitForSeconds(0.5f);
            GameObject bolaGo = Instantiate(bola, bocaJefe.position, bocaJefe.rotation);
            yield return new WaitForSeconds(0.5f);
            Animator.SetBool("Dispara", false);
            yield return new WaitForSeconds(3 - (GameManager.instance.semillas * 0.5f));
        }
        controlador = true;
    }
}
