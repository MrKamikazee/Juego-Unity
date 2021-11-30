using UnityEngine;

public class Semillas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.semillas++;
            gameObject.SetActive(false);
        }
    }
}
