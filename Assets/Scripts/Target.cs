using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class definition for each set of simultaneous targets(target nodes) in the song sequence
public class Target : TargetUtilities //inherit interactable class
{
    //list of targets
    [SerializeField]
    protected List<TargetNode> targets = new List<TargetNode>();

    //public TargetUtilities tU;

    //time to wait until spawned (waitforseconds)
    //[SerializeField]
    private float beatTime = 0.6125f; //SongData.GetSpeed();

    [SerializeField]
    private SongData song;

    [SerializeField]
    protected int beatCount;

    //spawn next after this float time
    public float delayTime;

    public float DelayTime
    {
        get { return beatTime*beatCount; }
        set { delayTime = value; }
    }

    protected new void Awake()
    {
        beatTime = song.beatTime;
        delayTime = beatTime * beatCount;

        #region
        //LoadResources();

        ////create test nodes
        //TargetNode strike1 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.SE, true);
        ////add test nodes to list
        //targets.Add(strike1);

        //TargetNode strike2 = new TargetNode(ControllerType.L, TargetType.LStrike, TargetLocation.SW, true);
        //targets.Add(strike2);

        //TargetNode strike3 = new TargetNode(ControllerType.None, TargetType.Squat, TargetLocation.None, true);
        //targets.Add(strike3);

        //TargetNode strike4 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.SE, 1.2f, true);
        //targets.Add(strike4);

        //TargetNode strike5 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.S, 1.2f, true);
        //targets.Add(strike5);

        //TargetNode strike6 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.SW, 1.2f, true);
        //targets.Add(strike6);

        //TargetNode strike7 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.W, 1.2f, true);
        //targets.Add(strike7);

        //TargetNode strike8 = new TargetNode(ControllerType.R, TargetType.RStrike, TargetLocation.NW, 1.2f, true);
        //targets.Add(strike8);

        #endregion

    }

    private void Start()
    {
        //SpawnTarget();
    }

    private void Update()
    {

    }

    //spawn target at position/rotation specified by node
    public void SpawnTarget() 
    {
        //position and instantiate each object in targets array
        for (int i = 0; i < targets.Count; i++)
        {
            //pull vector direction info from TargetRotation function based on enum input from editor
            Vector3 targetDirection = TargetRotation(targets[i].targetLocation);

            //converts vector to Quaternion
            Quaternion targetOrientation = Quaternion.Euler(targetDirection);

            //add starting position vector (startPlane) to enum-based position (TargetPosition)
            Vector3 targetBasePoint = TargetPosition(targets[i].targetType, targets[i].sameSide); ;

            //create compass vectors emanating from strikebase point 
            Vector3 rotationVector;
            Vector3 targetPosition;

            if (targets[i].targetType == TargetType.LStrike || targets[i].targetType == TargetType.RStrike)
            {
                rotationVector = targetOrientation * Vector3.forward * Z_Ext;
                targetPosition = targetBasePoint + rotationVector;
                //Debug.Log(DelayTime);
            }
            else
            {
                targetPosition = targetBasePoint;
            }

            Instantiate(targets[i].targetModel, targetPosition, targetOrientation);
            
        }
    }

    private void IsSquat(TargetType move)
    {
        //if()
        //{ }
    }
    

    

    //conditional evaluation to pre
    //if (targets[i].TargetType == TargetType.Squat || targets[i].TargetType == TargetType.Stand)
    //{
    //    //then calculate y
    //}
    //else if (targets[i].TargetType == TargetType.LLunge || targets[i].TargetType == TargetType.RLunge)
    //{
    //    //then calculate y & z
    //}
    //else
    //{
    //    //calculate y & z
    //    //calculate rotation of this vector based on enum input for target direction
    //}

}
