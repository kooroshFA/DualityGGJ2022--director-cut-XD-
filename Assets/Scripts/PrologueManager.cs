using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] Image t2s;
    [SerializeField] Image t2b;

    [SerializeField] GameObject soul;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            t2s.gameObject.SetActive(false);
            soul.SetActive(true);
        }
    }
}
