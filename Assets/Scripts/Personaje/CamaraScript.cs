using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject target;
    public Vector2 minCamPos, maxCamPos, jefeFinalCamPos;
    public float suavizado, tamañoCamaraJefeFinal;
    private Vector2 velocidad;
    public bool jefeFinal = false;
    public Camera camSize;

    private void FixedUpdate()
    {
        if (!jefeFinal)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocidad.x, suavizado);
            float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocidad.y, suavizado);
            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), 
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), 
                transform.position.z);
        }
        else
        {
            float posX = Mathf.SmoothDamp(transform.position.x, jefeFinalCamPos.x, ref velocidad.x, suavizado);
            float posY = Mathf.SmoothDamp(transform.position.y, jefeFinalCamPos.y, ref velocidad.y, suavizado);
            camSize.orthographicSize = Mathf.Lerp(camSize.orthographicSize, tamañoCamaraJefeFinal, suavizado);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

    public void DevolverSizeCamara()
    {
        camSize.orthographicSize = 7;
    }
}
