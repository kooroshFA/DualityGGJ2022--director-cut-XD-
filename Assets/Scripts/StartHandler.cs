using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartHandler : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image startButton;

    [SerializeField] private Image[] images;
    bool firstTime=true;
    int counter;

    private void Start()
    {
        foreach (var v in images)
        {
            Color c = v.material.color;
            c.a = 0;
            v.material.color = c;
        }
        StartCoroutine("ShowImage", background);
        StartCoroutine("ShowImage", startButton);
    }

    private void Update()
    {
        if (counter == 1)
        {
            StartCoroutine("FadeMenu", images[counter - 1]);
            images[counter - 1].gameObject.SetActive(false);
            StopCoroutine("FadeMenu");
        }
        if (counter == 4)
        {
            for (int i = 0; i < counter; i++)
            {
                StartCoroutine("FadeMenu", images[i]);
                images[i].gameObject.SetActive(false);
                StopCoroutine("FadeMenu");
            }
        }
        if (counter == 6)
        {
            for (int i = 0; i < counter; i++)
            {
                StartCoroutine("WAIT");
                StartCoroutine("FadeMenu", images[i]);
                images[i].gameObject.SetActive(false);
                StopCoroutine("FadeMenu");
            }
        }

    }

    public void OnStartClick()
    {
        StartCoroutine("FadeMenu", background);
        startButton.gameObject.SetActive(false);
        if (firstTime)
        {
            firstTime = false;
            StartCoroutine("CutScene");
            background.gameObject.SetActive(false);
        }else
        {
            //load nextScene
        }
    }

    IEnumerator CutScene()
    {
        foreach (var v in images)
        {
            yield return new WaitForSeconds(1f);
            v.gameObject.SetActive(true);
            StartCoroutine("ShowImage", v);
            yield return new WaitForSeconds(2f);
            StopCoroutine("ShowImage");
            counter++;
        }
        //yield return new WaitForSeconds(1.5f);
        //images[0].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[0]);
        //yield return new WaitForSeconds(2f);
        //StartCoroutine("FadeMenu", images[0]);
        //images[0].gameObject.SetActive(false);
        //yield return new WaitForSeconds(1f);
        //images[1].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[1]);
        //yield return new WaitForSeconds(2f);
        //StopCoroutine("ShowImage");
        //images[2].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[2]);
        //yield return new WaitForSeconds(2f);
        //StopCoroutine("ShowImage");
        //images[3].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[3]);
        //yield return new WaitForSeconds(2f);
        //for(int i = 1; i<4; i++)
        //{
        //    StartCoroutine("FadeMenu", images[i]);
        //    images[i].gameObject.SetActive(false);
        //}
        //yield return new WaitForSeconds(2f);
        //StopCoroutine("ShowImage");
        //images[4].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[4]);
        //yield return new WaitForSeconds(2f);
        //StopCoroutine("ShowImage");
        //images[5].gameObject.SetActive(true);
        //StartCoroutine("ShowImage", images[5]);
        //yield return new WaitForSeconds(2f);
        //for (int i = 4; i < 6; i++)
        //{
        //    StartCoroutine("FadeMenu", images[i]);
        //    images[i].gameObject.SetActive(false);
        //}
    }

    IEnumerator ShowImage(Image image)
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = image.material.color;
            c.a = f;
            image.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        //image.gameObject.SetActive(false);
    }

    IEnumerator FadeMenu(Image image)
    {
        for (float f = 1; f >= 0; f -= 0.05f)
        {
            Color c = image.material.color;
            c.a = f;
            image.material.color = c;
            yield return new WaitForSeconds(0.04f);
        }
        //image.gameObject.SetActive(false);
    }

    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(2f);
    }
}
