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
    [SerializeField] int positionX;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        roadLine = RoadLine.MIDDLE;
        fMove = 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunnerMove();
    }

    private void FixedUpdate()
    {
        //rigidbody.position = new Vector3(positionX * (int)roadLine, rigidbody.position.y, rigidbody.position.z);
    }

    void SetPosition(float value)
    {
        //rigidbody.position이 transform.position보다 연산이 더 빠름
        rigidbody.position = new Vector3(rigidbody.position.x + value, rigidbody.position.y, rigidbody.position.z);

        //this.transform.position = new Vector3(this.transform.position.x + value, this.transform.position.y, this.transform.position.z);
    }

    void RunnerMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
                SetPosition(-fMove);
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
                SetPosition(fMove);
            }
        }

    }
}
