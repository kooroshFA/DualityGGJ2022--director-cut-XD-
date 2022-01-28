using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Transform soulPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.gameObject.GetComponent<PlayerController>().isSoul)
        {
            transform.position = soulPos.position + new Vector3(0, 2, -10);
            gameObject.GetComponent<Camera>().orthographicSize = 10;
        }
        else
        {
            transform.position = playerPos.position + new Vector3(5, 2, -10);
            gameObject.GetComponent<Camera>().orthographicSize = 5;
        }
    }
}
