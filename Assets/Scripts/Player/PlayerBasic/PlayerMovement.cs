using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController
{
    public void MoveTo(Vector3 _destination)
    {
        if (m_navAgent.hasPath)                                 // 이미 이동 중이라면
        {
            StopAllCoroutines();
            m_navAgent.SetDestination(_destination);
        }
        else
        {
            m_navAgent.SetDestination(_destination);            // 네브매쉬 목적지 설정
            SetAnimation("Walk");                                         // 걷기 애니메이션
        }
        StartCoroutine(CheckArrive());
    }
    private void StopMove()
    {
        StopCoroutine(CheckArrive());
        m_navAgent.velocity = Vector3.zero;
        m_navAgent.ResetPath();
        SetAnimation("Idle");
    }
    private IEnumerator CheckArrive()
    {
        while (m_navAgent.pathPending) { yield return null; }            // 경로 계산 대기
        while (m_navAgent.remainingDistance >= 0) { yield return null; }  // 목적지 도착 대기
        StopMove();                                                     // 움직임 멈추기
    }
}
