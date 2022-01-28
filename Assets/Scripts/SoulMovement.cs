using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SoulMovement : MonoBehaviour
{
    [SerializeField] Transform cam;
    private Rigidbody2D rb;
    [SerializeField] private float HorizontalSpeed = 200f;
    [SerializeField] private float VerticalSpeed = 120f;
    private Vector2 move;

    [SerializeField] PrologueManager proMan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        move = new Vector2(Horizontal * Time.deltaTime * HorizontalSpeed,
         Vertical * Time.deltaTime * VerticalSpeed);
    }
    void FixedUpdate()
    {
        rb.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "body" && proMan.isDanger)
        {
            proMan.t2b.gameObject.SetActive(true);
            proMan.end = true;
            //Time.timeScale = 0;
            //gameObject.SetActive(false);
            //load next scene
        }
    }
}