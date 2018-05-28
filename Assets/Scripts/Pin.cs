using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour
{
    public float standingThreshold = 3.0f;
   
    public bool isStanding()
    {
        float eulerAngleX = transform.eulerAngles.x;
        float eulerAngleZ = transform.eulerAngles.z;
        bool standInX = (eulerAngleX < standingThreshold || 360f - eulerAngleX < standingThreshold);
        bool standInZ = (eulerAngleZ < standingThreshold || 360f - eulerAngleZ < standingThreshold);
        if (standInX && standInZ)
            return true;
        else
            return false;
    }
}
