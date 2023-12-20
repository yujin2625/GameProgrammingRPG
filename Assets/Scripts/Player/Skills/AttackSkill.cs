using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : SkillInfo
{
    public float m_damage = 20;
    public float speed = 0.5f;
    private void Awake()
    {
        Destroy(gameObject, 0.5f);
        SetDamage(m_damage);
    }
    private void Update()
    {
        transform.localPosition += new Vector3(0, 0, speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
