using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollows : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speed;
    public PlayerController pcontrol;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "soul" && (pcontrol == null || pcontrol.isSoul))
        {
            Time.timeScale = 0;
            menu.gameObject.SetActive(true);
        }
        if(collision.tag == "interactable" &&(pcontrol == null || pcontrol.isSoul))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            if(collision.GetComponent<CircleCollider2D>())
                collision.GetComponent<CircleCollider2D>().isTrigger = false;
            if (collision.GetComponent<BoxCollider2D>())
                collision.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Untagged" &&(pcontrol == null || pcontrol.isSoul))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}