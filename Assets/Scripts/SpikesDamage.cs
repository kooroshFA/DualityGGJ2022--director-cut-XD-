using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpikesDamage : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Image gameOver;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject soulPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.SetActive(false);
            soulPlayer.SetActive(false);
            // gameOver.gameObject.SetActive(true);
            StartCoroutine(StartCounter());
        }
    }
    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Start");
    }
}
