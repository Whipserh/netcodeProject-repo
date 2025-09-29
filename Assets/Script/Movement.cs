using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 direction;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float acceleration = 1;
    [SerializeField] private float drag = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        float x, y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        direction = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        
        if(direction.magnitude != 0)
        movePlayer();
        else
        slowDownPlayer();


        rb.linearVelocity = rb.linearVelocity.normalized * Mathf.Clamp(rb.linearVelocity.magnitude, 0, maxSpeed);

    }

    private void movePlayer()
    {
        rb.linearVelocity = rb.linearVelocity + acceleration * Time.fixedDeltaTime * direction;
        
    }

    private void slowDownPlayer()
    {
        float newVelocity = rb.linearVelocity.magnitude - drag * Time.fixedDeltaTime;
        rb.linearVelocity = rb.linearVelocity.normalized * newVelocity;
    }
}
