using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (en este caso, el veh�culo)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Offset de la posici�n de la c�mara respecto al objetivo

    public float mouseSensitivity = 5f; // Sensibilidad del movimiento del mouse
    public float scrollSpeed = 5f; // Velocidad de zoom con la rueda del mouse
    public float minZoomDistance = 2f; // Distancia m�nima de zoom
    public float maxZoomDistance = 15f; // Distancia m�xima de zoom

    private float currentZoomDistance = 10f; // Distancia de zoom actual

    private float yaw = 0f; // �ngulo de rotaci�n horizontal de la c�mara
    private float pitch = 0f; // �ngulo de rotaci�n vertical de la c�mara

    void LateUpdate()
    {
        // Si hay un objetivo asignado (veh�culo), sigue al objetivo
        if (target != null)
        {
            // Calcula la posici�n de la c�mara bas�ndose en la posici�n del objetivo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Aplica el zoom con la rueda del mouse
            currentZoomDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

            // Calcula la rotaci�n de la c�mara bas�ndose en la entrada del mouse
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -89f, 89f); // Limita el �ngulo vertical de rotaci�n para evitar inversiones

            // Calcula la rotaci�n deseada de la c�mara
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

            // Aplica la posici�n y rotaci�n calculadas a la c�mara
            transform.position = desiredPosition - rotation * Vector3.forward * currentZoomDistance;
            transform.LookAt(target.position + Vector3.up * offset.y); // Mantiene la c�mara mirando hacia el objetivo
        }
    }
}
