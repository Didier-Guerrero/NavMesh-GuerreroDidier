using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene el tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Destruir el objeto actual
            Destroy(gameObject);
        }
    }
}
