using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpikesDamge : MonoBehaviour
{
    [SerializeField] private Image gameOver;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject SoulPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.SetActive(false);
            SoulPlayer.SetActive(false);
            //Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            StartCoroutine(StartCounter());
        }
    }
    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Start");
    }
}
