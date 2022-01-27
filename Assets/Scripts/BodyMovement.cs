using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BodyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float jumpSpeed;
    // [SerializeField]private float VerticalSpeed;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        // float Vertical = Input.GetAxis("VerticalBody");
        
        move = new Vector2(Horizontal * Time.deltaTime * HorizontalSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpSpeed*Time.smoothDeltaTime));
        }
    }
    void FixedUpdate() {
        rb.velocity = move;
    }
}
