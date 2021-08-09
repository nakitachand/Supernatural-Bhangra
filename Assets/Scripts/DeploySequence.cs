using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySequence : MonoBehaviour
{
    [SerializeField]
    protected List<Target> targetSequence = new List<Target>();

    //[SerializeField]
    public float seqTime;
    //public float SeqTime
    //{
    //    get
    //    {
    //        SequenceTime();
    //        return seqTime; }
    //    private set { seqTime = value; }
    //}

    [SerializeField]
    private string seqName;

    [SerializeField]
    private bool isActive = false;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value;}
    }

    public void Awake()
    {
        seqTime = SequenceTime();
        seqName = this.gameObject.name;
    }
    
    // Start is called before the first frame update
    void Start()
    {

        //isActive = true;

        ////check for status
        //if(isActive)
        //{
        //    //load sequence of targets
        //    StartCoroutine(Deploy());
        //}

        Debug.Log(seqName + " seqTime = " + seqTime);

    }

    public float SequenceTime()
    {
        float time = 0f;
        foreach(Target go in targetSequence)
        {
            time += go.DelayTime;
        }
        
        return time;
    }

    public IEnumerator Deploy()
    {
        int i = 0;
        foreach (Target go in targetSequence)
        {
            StartCoroutine(SpawnTargetSet(go, go.DelayTime));
            yield return new WaitForSeconds(go.DelayTime);
            
            i++;
            //Debug.Log("Target set " + i + " instantiated");
        }
        //isActive = false;
        //Debug.Log("Is sequence active? " + isActive);
    }

    //spawn an individual target set after specified delay time
    IEnumerator SpawnTargetSet(Target set, float delay)
    {
        set.SpawnTarget();
        yield return new WaitForSeconds(delay);
        //Debug.Log("Target set instantiated");
    }

    // Update is called once per frame
    void Update()
    {
        //check isActive switch
        if(isActive)
        {

        }
    }


}
