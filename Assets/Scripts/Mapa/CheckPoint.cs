using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RespawnPersonaje>().ReachedCheckPonit(transform.position.x, transform.position.y);
            GameObject checkpointActive = Instantiate(checkpoint, transform.position, transform.rotation);
            if (other.GetComponent<RespawnPersonaje>().life < (other.GetComponent<RespawnPersonaje>().vida.Length + 1))
            {
                other.GetComponent<RespawnPersonaje>().SumarVida();
            }
            gameObject.SetActive(false);
        }
    }
}
