using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isSoul = false;
    [SerializeField] private GameObject soul;
    [SerializeField] private GameObject follower;
    [SerializeField] private BoxCollider2D enemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSoul = !isSoul;
            Debug.Log(isSoul);
        }
        if(isSoul)
        {
            soul.SetActive(true);
            gameObject.GetComponent<BodyMovement>().enabled = false;
            follower.GetComponent<EnemyFollows>().enabled = true;
        }
        if(!isSoul)
        {
            soul.transform.position = gameObject.transform.position;
            soul.SetActive(false);
            follower.GetComponent<EnemyFollows>().enabled = false;
            follower.transform.position = gameObject.transform.position + new Vector3(20, 0, 0);
            gameObject.GetComponent<BodyMovement>().enabled = true;
            enemy.isTrigger = true;
        }
    }
}
