using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    public GameObject AttackObj;
    public GameObject BuffObj;
    public GameObject SpellCastObj;
    public void AttackSkill()
    {
        Invoke(nameof(SetAttackObj), 0.5f);
    }
    public void SetAttackObj()
    {
        Instantiate(AttackObj,SkillParent.transform);
    }
    public void BuffSkill()
    {
        GameObject buffObj = Instantiate(BuffObj,EffectParent.transform);
        Destroy(buffObj, 10f);
    }
    public void SpellCastSkill()
    {
        Invoke(nameof(SetCastObj), 0.5f);
    }
    public void SetCastObj()
    {
        Instantiate(SpellCastObj, SkillParent.transform);
    }
}
