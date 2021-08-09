using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//defines an individual target object
//[System.Serializable]
[CreateAssetMenu(fileName = "SingleTarget",menuName = "Targets/SingleTarget")]
public class TargetNode: ScriptableObject
{
    //admin/visual variables
    public string targetName;
    public string description;
    public GameObject targetModel;
    public TargetType targetType;
    public TargetLocation targetLocation;
    public ControllerType controllerType;
    public bool sameSide = true;

    //old attempt at S.O. functions - not working
    #region
    ////positioning variables
    //public TargetOrigin origin;
    //[SerializeField]
    //private float x = 0f;
    //private Vector3 targetPosition;
    //private Quaternion targetRotation;


    ////user-defined values for z component of targets position
    ////default is extension from center for strike target circle centerpoint
    //[SerializeField]
    //private float zDefault; 

    ////user-defined values for z component of targets position
    ////default is height for strike targets
    //[SerializeField]
    //private float yDefault;

    ////user-defined values for z component of targets position
    ////default is scalar offset for strike targets (to be rotated by direction vector)
    //[SerializeField]
    //public float y_Ext;

    //[SerializeField]
    //public float z_Ext;

    ////method to pull x float value from scriptable object
    //public void Awake()
    //{
    //    x = origin.X;
    //    yDefault = origin.yD;
    //    zDefault = origin.zD;
    //    y_Ext = origin.yE;
    //    z_Ext = origin.zE;
    //}

    ////method to return z float

    ////method to return y float

    ////method to return vector comprised of x, y, z

    ////returns local rotation of target based on targetlocation parameter given
    //public Vector3 TargetRotation()
    //{
    //    //float x = 0f;

    //    switch (this.targetLocation)
    //    {
    //        case TargetLocation.N:
    //            x = -90f;
    //            break;

    //        case TargetLocation.NE:
    //            x = -45f;
    //            break;

    //        case TargetLocation.E:
    //            x = 0f;
    //            break;

    //        case TargetLocation.SE:
    //            x = 45f;
    //            break;

    //        case TargetLocation.S:
    //            x = 90f;
    //            break;

    //        case TargetLocation.SW:
    //            x = 135f;
    //            break;

    //        case TargetLocation.W:
    //            x = 180f;
    //            break;

    //        case TargetLocation.NW:
    //            x = -135f;
    //            break;

    //        case TargetLocation.None:
    //            x = 0f;
    //            break;

    //        default:
    //            Debug.Log("Target placement direction is unknown.");
    //            break;
    //    }

    //    Vector3 direction = new Vector3(x, 0f, 0f);
    //    return direction;
    //}

    //public Quaternion DirectionToRotation()
    //{
    //    //direction = TargetRotation();
    //    targetRotation = Quaternion.Euler(TargetRotation());
    //    return targetRotation;
    //}

    ////returns position to pass global coordinates based on target type and controller side
    //public Vector3 TargetPosition()//TargetType move)
    //{
    //    float x = -4.5f;//this.x;//GetStartPosition().x; //(constant)
    //    float y = GetY();
    //    float z = GetZ();

    //    targetPosition = new Vector3(x, y, z);
    //    return targetPosition;
    //}



    ////returns float value for z coordinate based on target type
    //public float GetZ()//TargetType move)
    //{
    //    //if controllerType is R
    //    //if SameSide == true
    //    //z is positive sign
    //    //else
    //    //z is negative
    //    //elseif target is LStrike
    //    //if Sameside == true
    //    //z is negative
    //    //else
    //    //z is positive

    //    //z is also affected by sameSide bool, sign should flip

    //    float z_value = 0f;

    //    //for strike targets, z = pivot + extension, pivot = 1(constant), extension = variable amt based on TargetRotation horizontal
    //    //float z = 0f;
    //    //float z_Ext = 0f;

    //    switch (this.targetType)
    //    {
    //        case TargetType.Squat:
    //            z_value = 0f;
    //            break;
    //        case TargetType.Stand:
    //            z_value = 0f;
    //            break;
    //        case TargetType.RStrike:
    //            z_value = zDefault;
    //            break;
    //        case TargetType.LStrike:
    //            z_value = -zDefault;
    //            break;
    //        case TargetType.RLunge:
    //            z_value = z_Ext;
    //            break;
    //        case TargetType.LLunge:
    //            z_value = -z_Ext;
    //            break;
    //        default:
    //            Debug.Log("Target type is invalid.");
    //            break;
    //    }

    //    return z_value;
    //}

    ////returns float value for z coordinate based on target type
    //public float GetY()//, TargetLocation direction)
    //{
    //    float y_value = 0f;

    //    switch (this.targetType)
    //    {
    //        case TargetType.Squat:
    //            y_value = 0f;
    //            break;
    //        case TargetType.Stand:
    //            y_value = 0f;
    //            break;
    //        case TargetType.RStrike:
    //            y_value = yDefault;
    //            break;
    //        case TargetType.LStrike:
    //            y_value = yDefault;
    //            break;
    //        case TargetType.RLunge:
    //            y_value = 0f;
    //            break;
    //        case TargetType.LLunge:
    //            y_value = 0f;
    //            break;
    //        default:
    //            Debug.Log("Target type is invalid.");
    //            break;
    //    }

    //    return y_value;
    //}

    //old TargetNode list-based code
    #endregion
    #region
    //internal TargetNode next;
    //public TargetNode(ControllerType c, TargetType t, TargetLocation d, bool s)
    //{
    //    controllerSide = c;
    //    targetType = t;
    //    spawnPosition = d;
    //    //spawnTime = b;
    //    sameSide = s;
    //    next = null;
    //}



    ////intended controller
    //public ControllerType controllerSide;

    //public ControllerType ControllerSide
    //{
    //    get { return controllerSide; }
    //    private set { controllerSide = value; }
    //}

    ////accessor for target prefab
    //public TargetType targetType;

    //public TargetType TargetType
    //{
    //    get { return targetType; }
    //    private set { targetType = value; }
    //}

    ////spawn global position
    //public TargetLocation spawnPosition;

    //public TargetLocation SpawnPosition
    //{
    //    get { return spawnPosition; }
    //    private set { spawnPosition = value; }
    //}

    ////display side - same or opposite
    //public bool sameSide = true;

    //public bool SameSide
    //{
    //    get { return sameSide; }
    //    set { sameSide = value; }
    //}

    //
    //private void GetController(ControllerType interactor)
    //{
    //    switch (interactor)
    //    {
    //        case ControllerType.Both:
    //            Debug.Log("Instantiate both targets");
    //            break;
    //        case ControllerType.L:
    //            Debug.Log("Instantiate L targets");
    //            break;
    //        case ControllerType.R:
    //            Debug.Log("Instantiate R targets");
    //            break;
    //        case ControllerType.None:
    //            Debug.Log("Instantiate Squat/Lunge target");
    //            break;
    //        default:
    //            Debug.Log("Controller Type: Invalid selection");
    //            break;
    //    }
    //}
    #endregion

}





