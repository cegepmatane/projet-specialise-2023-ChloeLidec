using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    [Header("Stopwatch")]
    public Text textTime;

    private float startTime;
    private bool finished = false;
    private float t;

    // Start is called before the first frame update
    public void StartSW()
    {
        textTime.gameObject.SetActive(true);
        textTime.text = "0:00.00";
        startTime = Time.time;
        finished = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!finished)
        {
            t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            textTime.text = minutes + ":" + seconds;
        }
    }

    public void Finish()
    {
        finished = true;
        textTime.gameObject.SetActive(false);
    }

}
