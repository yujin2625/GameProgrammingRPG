using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    //public Vector3 GetDestination()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out RaycastHit hit, 100, LayerMask.NameToLayer("Plane")))
    //    {
    //        Vector3 mouse = hit.point;
    //        return mouse;
    //    }
    //    return Vector3.zero;
    //}
    public Vector3 GetAimByMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, LayerMask.NameToLayer("Plane")))
        {
            Vector3 mouse = hit.point;
            return mouse;
        }
        return Vector3.zero;

    }
}
