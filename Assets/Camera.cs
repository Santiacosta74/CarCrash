using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (en este caso, el vehículo)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Offset de la posición de la cámara respecto al objetivo

    void LateUpdate()
    {
        if (target != null)
        {
            // Actualiza la posición de la cámara basándose en la posición del objetivo y el offset
            transform.position = target.position + offset;

            // Mantiene la rotación de la cámara mirando hacia el objetivo
            transform.LookAt(target);
        }
    }
}
