using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using System;

public partial class GameManager : MonoBehaviour
{
    public GameObject FollowPoint;

    [SerializeField] float ZoomSpeed = 1f;

    ICinemachineCamera virtualCamera;
    private void Awake()
    {
        virtualCamera = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera;
    }
}
