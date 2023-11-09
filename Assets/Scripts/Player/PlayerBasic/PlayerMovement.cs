using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController
{
    public void MoveTo(Vector3 _destination)
    {
        if (m_navAgent.hasPath)                                 // �̹� �̵� ���̶��
        {
            StopAllCoroutines();
            m_navAgent.SetDestination(_destination);
        }
        else
        {
            m_navAgent.SetDestination(_destination);            // �׺�Ž� ������ ����
            SetAnimation("Walk");                                         // �ȱ� �ִϸ��̼�
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
        while (m_navAgent.pathPending) { yield return null; }            // ��� ��� ���
        while (m_navAgent.remainingDistance >= 0) { yield return null; }  // ������ ���� ���
        StopMove();                                                     // ������ ���߱�
    }
}
