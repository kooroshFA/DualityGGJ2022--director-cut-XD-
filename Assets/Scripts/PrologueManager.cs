using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] Image t2s;
    public Image t2b;
    [SerializeField] Image danger;

    [SerializeField] GameObject soul;
    [SerializeField] GameObject enemy;

    bool start = false;
    public bool isDanger = false;
    float timer;
    public bool end=false;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            t2s.gameObject.SetActive(false);
            soul.SetActive(true);
            timer = 7;
            start = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && start && !isDanger)
        {
            enemy.gameObject.SetActive(true);
            enemy.gameObject.transform.position = soul.transform.position + new Vector3(15, 0, 0);
            Time.timeScale = 0;
            danger.gameObject.SetActive(true);
            isDanger = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && isDanger)
        {
            Time.timeScale = 1;
            danger.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && end)
        {
            soul.SetActive(false);
            SceneManager.LoadScene("SampleScene");
        }
    }

}

