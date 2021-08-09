using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choreograpy : DeploySequence
{ 
    [SerializeField]
    private List<DeploySequence> sequences = new List<DeploySequence>();

    [SerializeField]
    private float startAfter;

    [SerializeField]
    private SongData songData;

    private void Awake()
    {
        base.Awake();
        startAfter = songData.StartTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        //time marker
        Debug.Log("Beat Time = "+ songData.BeatTime);

        //IsActive = true;

        //helper function
        //invoke coroutine after 4.8 seconds after song starts

        //startAfter = songData.StartTime;

        //StartCoroutine(WaitFor(startAfter));
        ////check for status
        //if (IsActive)
        //{
        StartCoroutine(LaunchSequence(startAfter));
            //load sequence of targets
        //}
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    //private IEnumerator WaitFor(float time)
    //{
    //    // WaitUntil(() => frame >= 10)
    //    yield return new WaitForSeconds(time);
    //}



    private IEnumerator LaunchSequence(float time)
    {
        yield return new WaitForSeconds(time);

        for (int i = 0; i<sequences.Count; i++)
        //foreach (DeploySequence sequence in sequences)
        {              
                string seqName = sequences[i].gameObject.name;
                //Debug.Log(seqName + " initiated.");
                sequences[i].StartCoroutine(sequences[i].Deploy());
                yield return new WaitForSeconds(sequences[i].seqTime);
                //Debug.Log(seqName + " completed, sequence #" + i);
                //i++;
                ////check for last target
                //if (i == sequences.Count - 1)
                //{
                //    sequences[i].IsActive = false;
                //}
                
                //sequence.IsActive = true;
                //string seqName = sequence.gameObject.name;
                //Debug.Log(seqName + " initiated.");

                //sequence.StartCoroutine(sequence.Deploy());
                //yield return new WaitForSeconds(sequence.SequenceTime());
                //Debug.Log(seqName + " completed, sequence #" + i);
                //sequence.IsActive = false;
                //i++;
            
        }
    }
}
