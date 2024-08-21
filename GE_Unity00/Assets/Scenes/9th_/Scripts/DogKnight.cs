using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    IDLE,
    WALK,
    ATTACK,
    DIE,
}


public class DogKnight : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] float fSpeed;
    [SerializeField] bool bDead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = State.IDLE;
        fSpeed = 4f;
        bDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        switch (state)
        {
            case State.IDLE:
                State_Idle();
                break;

            case State.WALK:
                State_Walk();
                break;

            case State.ATTACK:
                State_Attack();
                break;

            case State.DIE:
                State_Die();
                break;
        }
    }

    public void State_Idle()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttack", false);
        Debug.Log($"IDle");
    }

    public void State_Walk()
    {
        animator.SetBool("isMoving", true);

        Debug.Log($"Walk");
    }

    public void State_Attack()
    {
        animator.SetBool("isAttack", true);
        Debug.Log($"Attack");
    }

    public void State_Die()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttack", false);
        animator.Play("Die");
        Debug.Log($"Die");
    }

    #region
    private void OnTriggerEnter(Collider other)
    {
        //�浹�� �Ͼ�� �� ȣ��Ǵ� �̺�Ʈ �Լ�
        Debug.Log($"OnTriggerEnter");
    }

    private void OnTriggerStay(Collider other)
    {
        //�浹�� �������� �� ȣ��Ǵ� �̺�Ʈ �Լ�
        Debug.Log($"OnTriggerStay");
    }

    private void OnTriggerExit(Collider other)
    {
        //�浹�� ������ �� ȣ��Ǵ� �̺�Ʈ �Լ�

        if (other.gameObject.CompareTag("Enemy"))
        {
            state = State.DIE;
            bDead = true;
        }
        Debug.Log($"OnTriggerExit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� �浹�� �Ͼ�� �� ȣ��Ǵ� �̺�Ʈ �Լ�
        Debug.Log($"OnCollisionEnter");
    }

    private void OnCollisionStay(Collision collision)
    {
        // �������� �浹�� �������� �� ȣ��Ǵ� �̺�Ʈ �Լ�
        Debug.Log($"OnCollisionStay");
    }

    private void OnCollisionExit(Collision collision)
    {
        // �������� �浹�� ������ �� ȣ��Ǵ� �̺�Ʈ �Լ�
        Debug.Log($"OnCollisionExit");
    }
    #endregion

    public void Move()
    {
        if (bDead == true)
        {
            return;
        }

        int iAttack = 0;
        float fMoveZ = 0;

        if (Input.GetKey(KeyCode.D))
        {
            fMoveZ += fSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            fMoveZ -= fSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fMoveZ = 0;
            iAttack = 1;
        }

        if (iAttack > 0)
        {
            state = State.ATTACK;

        }
        else if (fMoveZ != 0)
        {
            state = State.WALK;
        }
        else
        {
            state = State.IDLE;
        }

        transform.Translate(new Vector3(0, 0, fMoveZ * Time.deltaTime));
    }
}
