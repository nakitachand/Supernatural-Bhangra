using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//specifies which controller is intended for the interaction
public enum ControllerType
{
    R,      //right
    L,      //left
    Both,   //both
    None    //for lunges/squats
}

//specifies which type of gameobject will get instantiated and also which coordinates for instantiation
public enum TargetType
{
    RStrike,    //bubble-cone
    LStrike,
    LLunge,     //right triangle
    RLunge,
    Squat,      //short equilateral triangle
    Stand       //tall equilateral triangle
}

//specifies which direction the target will be locally rotated to based on compass direction system
public enum TargetLocation
{
    N,  //up strike
    NE, //up-out strike
    E,  //out strike
    SE, //down-out strike
    S,  //down strike
    SW, //down-in strike
    W,  //in strike
    NW,  //up-in strike
    None //no direction
}

public class TargetUtilities : MonoBehaviour
{
    //user-defined values for z component of targets position
    //default is extension from center for strike target circle centerpoint
    private float zDefault = 0.5f;

    //user-defined values for z component of targets position
    //default is height for strike targets
    private float yDefault = 0.5f;

    //user-defined values for z component of targets position
    //default is scalar offset for strike targets (to be rotated by direction vector)
    private float y_Ext = 0.25f;
    private float z_Ext = 0.25f;

    public float YExt
    {
        get { return y_Ext; }
        private set { y_Ext = value; }
    }

    public float Z_Ext
    {
        get { return z_Ext; }
        private set { z_Ext = value; }
    }

    protected void Awake()
    {

    }



    //returns local rotation of target based on targetlocation parameter given
    public Vector3 TargetRotation(TargetLocation direction)
    {
        float x = 0f;

        switch (direction)
        {
            case TargetLocation.N:
                x = -90f;
                break;

            case TargetLocation.NE:
                x = -45f;
                break;

            case TargetLocation.E:
                x = 0f;
                break;

            case TargetLocation.SE:
                x = 45f;
                break;

            case TargetLocation.S:
                x = 90f;
                break;

            case TargetLocation.SW:
                x = 135f;
                break;

            case TargetLocation.W:
                x = 180f;
                break;

            case TargetLocation.NW:
                x = -135f;
                break;

            case TargetLocation.None:
                x = 0f;
                break;

            default:
                Debug.Log("Target placement direction is unknown.");
                break;
        }
        return new Vector3(x, 0f, 0f);
    }

    //returns position to pass global coordinates based on target type and controller side
    public Vector3 TargetPosition(TargetType move, bool side)//, TargetLocation direction) //might not need interactor
    {
        float x = GetStartPosition().x; //(constant)
        float y = GetY(move);
        float z = GetZ(move,side);

        Vector3 position = new Vector3(x, y, z);

        return position;
    }

    //returns start position of targets based on position of portal gameobject
    public Vector3 GetStartPosition()
    {
        GameObject portal = GameObject.FindGameObjectWithTag("Portal");
        float x = portal.transform.position.x;
        float y = portal.transform.position.y;
        float z = portal.transform.position.z;

        float x_offset = 1.0f;

        float x_pos = x + x_offset;

        Vector3 startPosition = new Vector3(x_pos, y, z);

        return startPosition;
    }

    //returns float value for z coordinate based on target type
    public float GetZ(TargetType move, bool side)
    {
        //if controllerType is R
        //if SameSide == true
        //z is positive sign
        //else
        //z is negative
        //elseif target is LStrike
        //if Sameside == true
        //z is negative
        //else
        //z is positive

        //z is also affected by sameSide bool, sign should flip

        float z_value = 0f;

        //for strike targets, z = pivot + extension, pivot = 1(constant), extension = variable amt based on TargetRotation horizontal
        //float z = 0f;
        //float z_Ext = 0f;

        switch (move)
        {
            case TargetType.Squat:
                z_value = 0f;
                break;
            case TargetType.Stand:
                z_value = 0f;
                break;
            case TargetType.RStrike:
                z_value = zDefault;
                break;
            case TargetType.LStrike:
                z_value = -zDefault;
                break;
            case TargetType.RLunge:
                z_value = -z_Ext*2;
                break;
            case TargetType.LLunge:
                z_value = z_Ext*2;
                break;
            default:
                Debug.Log("Target type is invalid.");
                break;
        }

        if(!side)
        {
            z_value *= -.20f;
        }

        return z_value;
    }

    //returns float value for z coordinate based on target type
    public float GetY(TargetType move)//, TargetLocation direction)
    {
        float y_value = 0f;

        switch (move)
        {
            case TargetType.Squat:
                y_value = yDefault*.5f;
                break;
            case TargetType.Stand:
                y_value = yDefault;
                break;
            case TargetType.RStrike:
                y_value = yDefault;
                break;
            case TargetType.LStrike:
                y_value = yDefault;
                break;
            case TargetType.RLunge:
                y_value = -yDefault * .5f;
                break;
            case TargetType.LLunge:
                y_value = -yDefault * .5f;
                break;
            default:
                Debug.Log("Target type is invalid.");
                break;
        }

        return y_value;
    }


    //public bool IsStrike(TargetType move)
    //{
    //    if (move.Equals("Squat") || move.Equals("Stand") || IsLunge(move))
    //    {
    //        return false;
    //    }
    //    else
    //    { return true; }
    //}

    //public bool IsLunge(TargetType move)
    //{
    //    if (move.Equals("Squat") || move.Equals("Stand") || IsStrike(move))
    //    {
    //        return false;
    //    }
    //    else
    //    { return true; }
    //}
}



