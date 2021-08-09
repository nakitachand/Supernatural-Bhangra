using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text counterText;

    public float minutes, seconds, milli;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        
        //60*1000 milliseconds in a minute
        //1000 milliseconds in a second
        //milli = seconds % 1000f
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        //milli = (int)(Time.time);

        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");// + "." + milli.ToString("000");
    }
}
