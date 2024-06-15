using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private int playerScore;
    public Renderer cubeRenderer; // Renderer del cubo que cambia de color

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerScore = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            MoveToClickPoint();
        }
    }

    void MoveToClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("punto"))
        {
            // Incrementa la puntuación del jugador
            playerScore += 1;
            Debug.Log("Puntuación del jugador: " + playerScore);

            // Destruir el objeto con el tag "punto"
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("meta"))
        {
            // Verifica si el jugador tiene al menos 3 puntos
            if (playerScore >= 3)
            {
                // Cambia el color del cubo a verde
                if (cubeRenderer != null)
                {
                    cubeRenderer.material.color = Color.green;
                }

                // Detiene el movimiento del agente
                agent.isStopped = true;
                Debug.Log("¡Has ganado!");
            }
            else
            {
                Debug.Log("No tienes los puntos suficientes");
            }
        }
    }
}
