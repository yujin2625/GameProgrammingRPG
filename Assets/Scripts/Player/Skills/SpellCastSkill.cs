using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastSkill : SkillInfo
{
    public float m_damage = 10;


    private void Start()
    {
        SetDamage(m_damage);
        Destroy(gameObject, 4f);
    }
}
