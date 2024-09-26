using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : State
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float fMove;
    [SerializeField] float fSpeed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.speed = 1;
        roadLine = RoadLine.MIDDLE;
        fMove = 4.0f;
        fSpeed = 25.0f;
    }

    private void OnEnable()
    {
        base.OnEnable();

        InputManager.Instance.action += OnKeyUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        //animator.speed = (GetComponent<SpeedManager>().Speed / 10);
       // Debug.Log($"{animator.speed}/ms");
    }

    private void FixedUpdate()
    {
        if (state == false)
        {
            return;
        }

        SetPosition();
    }

    void SetPosition()
    {
        // 부드러운 좌표 이동
        rigidbody.position = Vector3.Lerp
        (
            rigidbody.position,
            new Vector3(fMove * (int)roadLine, rigidbody.position.y, rigidbody.position.z), fSpeed * Time.fixedDeltaTime
        );

        // 그냥 좌표 이동
        //this.transform.position = new Vector3(this.transform.position.x + value, this.transform.position.y, this.transform.position.z);

        //rigidbody.position이 transform.position보다 연산이 더 빠름
        //rigidbody.position = new Vector3(rigidbody.position.x + value, rigidbody.position.y, rigidbody.position.z);
    }

    private void OnDisable()
    {
        base.OnDisable();

        InputManager.Instance.action -= OnKeyUpdate;
    }

    void OnKeyUpdate()
    {
        if (state == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.Play("Sliding");
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
               // Debug.Log($"좌 {roadLine}");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
                //Debug.Log($"우 {roadLine}");
            }
        }
    }
}
