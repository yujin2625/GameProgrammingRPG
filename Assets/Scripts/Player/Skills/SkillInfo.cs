using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInfo : MonoBehaviour
{
    public float Damage { get; private set; }
    public void SetDamage(float _damage)
    {
        Damage = _damage;
    }
}
