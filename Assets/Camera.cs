using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (en este caso, el vehículo)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Offset de la posición de la cámara respecto al objetivo

    public float mouseSensitivity = 5f; // Sensibilidad del movimiento del mouse
    public float scrollSpeed = 5f; // Velocidad de zoom con la rueda del mouse
    public float minZoomDistance = 2f; // Distancia mínima de zoom
    public float maxZoomDistance = 15f; // Distancia máxima de zoom

    private float currentZoomDistance = 10f; // Distancia de zoom actual

    private float yaw = 0f; // Ángulo de rotación horizontal de la cámara
    private float pitch = 0f; // Ángulo de rotación vertical de la cámara

    void LateUpdate()
    {
        // Si hay un objetivo asignado (vehículo), sigue al objetivo
        if (target != null)
        {
            // Calcula la posición de la cámara basándose en la posición del objetivo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Aplica el zoom con la rueda del mouse
            currentZoomDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

            // Calcula la rotación de la cámara basándose en la entrada del mouse
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -89f, 89f); // Limita el ángulo vertical de rotación para evitar inversiones

            // Calcula la rotación deseada de la cámara
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

            // Aplica la posición y rotación calculadas a la cámara
            transform.position = desiredPosition - rotation * Vector3.forward * currentZoomDistance;
            transform.LookAt(target.position + Vector3.up * offset.y); // Mantiene la cámara mirando hacia el objetivo
        }
    }
}
