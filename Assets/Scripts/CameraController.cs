using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void ZoomCamera(float _zoom)
    {
        FollowPoint.transform.localPosition += new Vector3(0, 0, _zoom * ZoomSpeed);
    }

}
