using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput = 0;
    private float verticalInput = 0;
    [SerializeField] private float speed;
    private Rigidbody rb;

    private Vector3 direction;
    [SerializeField]private Transform orientation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.MovePosition(rb.transform.position + direction * speed * Time.deltaTime);
    }
}
