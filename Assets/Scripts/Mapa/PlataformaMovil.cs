using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject plataformaMovil;
    [Range(0,5)]
    public float velocidadPlataformaMovil;
    public Transform puntoDeInicio, puntoDeLlegada;
    private Vector3 moverHacia;

    private void Start()
    {
        moverHacia = puntoDeLlegada.position;
    }

    private void Update()
    {
        plataformaMovil.transform.position = Vector3.MoveTowards(plataformaMovil.transform.position, moverHacia,
            velocidadPlataformaMovil * Time.deltaTime);
        if (plataformaMovil.transform.position == puntoDeLlegada.position)
        {
            moverHacia = puntoDeInicio.position;
        }
        if (plataformaMovil.transform.position == puntoDeInicio.position)
        {
            moverHacia = puntoDeLlegada.position;
        }
    }
}
