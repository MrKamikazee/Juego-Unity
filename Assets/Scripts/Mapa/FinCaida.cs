using UnityEngine;

public class FinCaida : MonoBehaviour
{
    public RespawnPersonaje tpPersonaje;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            tpPersonaje.FinCaida();
        }
    }
}
