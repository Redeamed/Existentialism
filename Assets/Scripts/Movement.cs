using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float maxVelocityChange;
    [SerializeField] private bool grounded;
    public Transform cam;
    public Rigidbody rb;
    [SerializeField] private float distanceToGround;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    void Awake()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        grounded = isGrounded();
        if (horizontal != 0f || vertical != 0f)
        {            
            if (grounded)
            {
                Vector3 targetVelocity = new Vector3(horizontal, 0, vertical);
                targetVelocity = cam.transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;
                Vector3 v = rb.velocity;
                Vector3 velocityChange = (targetVelocity - v);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                rb.AddForce(velocityChange, ForceMode.VelocityChange);
            }
        }
        else
        {
            rb.angularVelocity *= 0;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(transform.up * jumpHeight);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + .1f);
    }
    
}