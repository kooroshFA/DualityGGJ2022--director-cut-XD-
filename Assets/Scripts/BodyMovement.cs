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
    bool facingRight;
    private Animator anim;
    private bool isJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        // float Vertical = Input.GetAxis("VerticalBody");
        
        move = new Vector2(Horizontal * Time.deltaTime * HorizontalSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
        {
            rb.AddForce(new Vector2(0, jumpSpeed* Time.deltaTime));
            isJumped = true;
            StartCoroutine(WasteTime());
        }

        if(Horizontal == 0)
        {
            anim.SetBool("IsWalking", false);
            //transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }else
        {
            anim.SetBool("IsWalking", true);
            //transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
        }
        
        if(Horizontal<0)
        {
            facingRight = false;
        }else
        {
            facingRight = true;
        }
    }
    void FixedUpdate() {
        rb.velocity = move;
    }
    private void LateUpdate()
    {
        if((facingRight && transform.localScale.x<0)||(!facingRight && transform.localScale.x>0))
        {
            transform.localScale = new Vector3(-1*transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }
    IEnumerator WasteTime()
    {
        if (isJumped)
        {
            yield return new WaitForSeconds(1);
            isJumped = false;
        }
    }
}
