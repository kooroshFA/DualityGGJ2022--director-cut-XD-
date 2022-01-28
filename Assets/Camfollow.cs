using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.activeSelf)
            transform.position = obj.transform.position + new Vector3(5, 2, -10);
        //gameObject.GetComponent<Camera>().orthographicSize = 5;
    }
}
