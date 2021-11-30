using UnityEngine;

public class ParedesInvicibles : MonoBehaviour
{
    public CamaraScript camara;
    public FinalBossManager manager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camara.jefeFinal = true;
            manager.IniciarCorrutina();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camara.jefeFinal = false;
            camara.DevolverSizeCamara();
            manager.controlador = false;
        }
    }
}
