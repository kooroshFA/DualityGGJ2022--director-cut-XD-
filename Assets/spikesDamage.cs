using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesDamage : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public PlayerController pcontrol;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            menu.gameObject.SetActive(true);
        }
    }
}