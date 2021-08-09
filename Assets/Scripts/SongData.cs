using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SongData", menuName = "Targets/SongData")]
public class SongData:ScriptableObject
{
    //beat length
    //8-count length
    //segment lengths
    //[SerializeField]
    public float beatTime;// = 0.6f;
    //[SerializeField]
    public float beatPM;// = 1.667f;

    public string songName;

    public float startTime;
    
    //private float measureTime;
    
    //private float segmentTime;
    

    //beat length(time) in seconds
    public float BeatTime
    {
        get { return beatTime; }
    }

    public float StartTime
    {
        get { return startTime; }
    }

    ////length in time(seconds) for 8 beats
    //public float MeasureTime
    //{
    //    get 
    //    {
    //        measureTime = beatTime * 8;
    //        return (measureTime); 
    //    }
    //}


    //public float SegmentTime
    //{
    //    get
    //    {
    //        segmentTime = measureTime * 4;
    //        return segmentTime;
    //    }
    //}


    public static float GetBPM()
    {
        float bpm = 1.667f*3;
        return bpm; 
    }
}
