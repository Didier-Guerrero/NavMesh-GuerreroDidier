using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir�
    public float smoothSpeed = 0.125f; // La velocidad de suavizado de la c�mara
    public Vector3 offset; // La distancia de la c�mara al objeto

    void LateUpdate()
    {
        // Define la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + offset;
        // Interpola suavemente hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Asigna la posici�n suavizada a la c�mara
        transform.position = smoothedPosition;

        // Asegura que la c�mara mire desde arriba y est� rotada 90 grados a la derecha
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
