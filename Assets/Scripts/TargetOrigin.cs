using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetOrigin", menuName = "Targets/TargetOrigin")]
public class TargetOrigin : ScriptableObject
{
    //starting x-position of targets
    //[SerializeField]
    public float x = -4.5f;

    //user-defined values for z component of targets position
    //default is extension from center for strike target circle centerpoint
    //[SerializeField]
    public float zD = 0.75f;

    //user-defined values for z component of targets position
    //default is height for strike targets
    //[SerializeField]
    public float yD = 0.5f;

    //user-defined values for z component of targets position
    //default is scalar offset for strike targets (to be rotated by direction vector)
    //[SerializeField]
    public float yE = 0.25f;

    //[SerializeField]
    public float zE = 0.25f;


    public float X
    {
        get { return x; }
        set { x = value; }
    }

    //returns start position of targets based on position of portal gameobject
    private Vector3 GetStartPosition()
    {
        GameObject portal = GameObject.FindGameObjectWithTag("Portal");
        float x = portal.transform.position.x;
        float y = portal.transform.position.y;
        float z = portal.transform.position.z;

        Vector3 startPosition = new Vector3(x, y, z);

        return startPosition;
    }
}
