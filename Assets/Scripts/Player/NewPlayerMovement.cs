using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float horizontalInput, verticalInput, speed, jumpspeed, JumpDistance;
    private bool OnGround;
    [SerializeField] Transform cam;
    [SerializeField] PlayerAttriibues playerattributes;
    private Rigidbody rb;
    private Vector3 moveDir;

    private void GroundCheck()
    {
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(transform.position, direction);
        Debug.DrawRay(transform.position, direction * JumpDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, JumpDistance))
        {
            if (hit.collider.CompareTag("ground"))
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }
        else
        {
            OnGround = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerattributes = GetComponent<PlayerAttriibues>();
    }

    void FixedUpdate()
    {
        if (!playerattributes.PlayerDiedMethod())
        {
            GroundCheck();

            // Get camera directions
            Vector3 camFoward = cam.forward;
            Vector3 camRight = cam.right;
            camFoward.y = 0;
            camRight.y = 0;
            camFoward.Normalize();
            camRight.Normalize();

            moveDir = Vector3.zero;

            // Process one movement key at a time (in order: W > S > D > A)
            if (Input.GetKey(KeyCode.W))
            {
                moveDir = camFoward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDir = -camFoward;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDir = camRight;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveDir = -camRight;
            }

            // Move player if any key pressed
            if (moveDir != Vector3.zero)
            {
                Vector3 newPosition = rb.position + moveDir * speed * Time.fixedDeltaTime;
                rb.MovePosition(newPosition);
            }

            // Jump
            if (Input.GetKey(KeyCode.Space) && OnGround)
            {
                rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
                OnGround = false;
            }
        }
    }
}




