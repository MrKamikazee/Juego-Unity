using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject target;
    public Vector2 minCamPos, maxCamPos;
    public float suavizado;
    private Vector2 velocidad;

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocidad.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocidad.y, suavizado);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), 
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), 
            transform.position.z);
    }
}
