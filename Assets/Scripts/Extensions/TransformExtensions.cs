using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Transform GetClosestObject(this Transform transform, ref List<GameObject> scaryObjects) // ref points to the actual data. not making a copy. 
    {
        if(scaryObjects.Count <= 0)
        {
            return null;
        }
        
        Transform closestObject = null;
        float currentClosesetDistance = float.MaxValue; // Mathf.Infinity

        foreach(GameObject item in scaryObjects)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if(distance < currentClosesetDistance)
            {
                currentClosesetDistance = distance;
                closestObject = item.transform;
            }
        }

        return closestObject;
    }
}