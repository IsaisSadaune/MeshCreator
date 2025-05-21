using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private Transform cameraPos;
    
    void FixedUpdate()
    {
        transform.position = cameraPos.position; 
    }
}
