using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    GameManager GameManager;
    Rigidbody rigid;
    Animator animator;
    CapsuleCollider CapsuleCollider;

    public GameObject gameManager;
    public GameObject LookRotate;
    public GameObject SkillParent;
    public GameObject EffectParent;

    Vector3 m_direction;
    public bool ShiftClicked = false;
    public bool IsJumping = false;
    public bool IsRunning = false;
    public bool IsAttacking = false;
    public float speed = 5;
    [SerializeField] float TurnSpeed = 5f;
    [SerializeField] float JumpPower = 50f;

    public enum PlayerSkills
    {
        Attack, Buff, SpellCast, Last
    }

    private void Start()
    {
        GameManager = gameManager.GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        MoveTo(m_direction);
    }
    public void AddDirection(float _x = 0, float _y = 0, float _z = 0)
    {
        m_direction += new Vector3(_x, _y, _z);
    }
    public void Jump()
    {
        rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    }
    public void SetDirection(Vector3 _direction)
    {
        m_direction = _direction;
    }
    public void MoveTo(Vector3 _direction)
    {
        _direction = _direction.normalized * speed * Time.deltaTime;
        transform.position += (transform.rotation * _direction);
    }
    public void UseSkills(PlayerSkills skill)
    {
        switch (skill)
        {
            case PlayerSkills.Attack:
                AttackSkill();
                StartCoroutine(SkillTimer(1));
                break;
            case PlayerSkills.Buff:
                BuffSkill();
                StartCoroutine(SkillTimer(0.5f));
                break;
            case PlayerSkills.SpellCast:
                SpellCastSkill();
                StartCoroutine(SkillTimer(3f));
                break;
        }
    }
    IEnumerator SkillTimer(float time)
    {
        IsAttacking = true;
        yield return new WaitForSeconds(time);
        IsAttacking = false;
    }

}
