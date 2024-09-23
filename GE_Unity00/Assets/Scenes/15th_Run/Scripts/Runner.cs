using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
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
        roadLine = RoadLine.MIDDLE;
        fMove = 4.0f;
        fSpeed = 25.0f;
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    // Update is called once per frame
    void Update()
    {
       //OnKeyUpdate();
    }

    private void FixedUpdate()
    {
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
        InputManager.Instance.action -= OnKeyUpdate;
    }

    void OnKeyUpdate()
    {
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
                Debug.Log($"좌 {roadLine}");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
                Debug.Log($"우 {roadLine}");
            }
        }
    }
}
