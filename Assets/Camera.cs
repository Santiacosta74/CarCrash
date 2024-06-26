using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (en este caso, el veh�culo)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Offset de la posici�n de la c�mara respecto al objetivo

    void LateUpdate()
    {
        if (target != null)
        {
            // Actualiza la posici�n de la c�mara bas�ndose en la posici�n del objetivo y el offset
            transform.position = target.position + offset;

            // Mantiene la rotaci�n de la c�mara mirando hacia el objetivo
            transform.LookAt(target);
        }
    }
}
