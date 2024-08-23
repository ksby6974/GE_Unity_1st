using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swarm : MonoBehaviour
{
    public enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        DIE,
    }

    [SerializeField] State state;
    [SerializeField] AudioClip attackSound;
    [SerializeField] Animator animator;
    [SerializeField] float fSpeed;
    [SerializeField] bool bDead;
    [SerializeField] bool bAttack;
    private int fLimit = 5;
    private int iAttackCount = 0;
    private float fTime = 0;
    private float fDisapper = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = State.IDLE;
        animator = GetComponent<Animator>();
        fSpeed = 2f;
        bDead = false;
        bAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDead == true)
        {
            fDisapper += 1f * Time.deltaTime;
        }
        else
        {
            fTime += 1f * Time.deltaTime;
        }

        if ((bDead == true) && (fDisapper > 3))
        {
            Destroy(gameObject);
        }

        Debug.Log($"Time : {fTime}");
        if ((bDead == false) && (fTime > 1.5))
        {
            fTime = 0;
            state = State.ATTACK;
        }

        switch (state)
        {
            case State.IDLE:
                State_Idle();
                break;

            case State.MOVE:
                State_Move();
                break;

            case State.ATTACK:
                State_Attack();
                break;

            case State.DIE:
                State_Die();
                break;
        }

        if (iAttackCount >= fLimit)
        {
            state = State.DIE;
        }
    }

    public void State_Idle()
    {
        if ((bDead == true) || (bAttack == true))
        {
            return;
        }

        animator.SetBool("isAttack", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.MOVE;
        }
    }

    public void State_Move()
    {
        float fMoveZ = fSpeed;
        transform.Translate(new Vector3(0, 0, fMoveZ * Time.deltaTime));
    }

    public void State_Die()
    {
        animator.SetBool("isAttack", false);

        bDead = true;
        animator.SetBool("isDead", true);
    }

    public void State_Attack()
    {
        iAttackCount++;
        Debug.Log($"Attack : {iAttackCount}");
        animator.SetBool("isAttack", true);
        state = State.IDLE;
    }

    public void OnDamage()
    {
        SoundManager.Instance.Sound(attackSound);
    }
}
