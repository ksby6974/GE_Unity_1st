using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    IDLE = 0,
    LEFT = 1,
    RIGHT = 2
}

public class Player : MonoBehaviour
{
    [Header("Move_Input")]
    [SerializeField] float fMoveSpeed;
    [SerializeField] float fMoveInputX;
    [SerializeField] float fMoveInputY;

    [Header("Flip")]
    private bool facingRight = true;
    private int facingDirection = 1;
    [SerializeField] Sprite currentSprite;
    [SerializeField] Sprite[] sprites;

    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fMoveSpeed = 2.0f;
        currentSprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //OnMove();
        SetFlip();
        GetPlayerMove();
        SetPlayerMove();
    }

    bool CheckMoveLimit()
    {
        if (transform.position.x < Limits.min.x ||
            transform.position.x > Limits.max.x ||
            transform.position.y < Limits.min.y ||
            transform.position.y > Limits.max.y)
        {
            if (transform.position.x < Limits.min.x)
            {
                transform.position = new Vector3(Limits.min.x, transform.position.y);
            }

            if (transform.position.x > Limits.max.x)
            {
                transform.position = new Vector3(Limits.max.x, transform.position.y);
            }

            if (transform.position.y < Limits.min.y)
            {
                transform.position = new Vector3(transform.position.x, Limits.min.y);
            }

            if (transform.position.y > Limits.max.y)
            {
                transform.position = new Vector3(transform.position.x, Limits.max.y);
            }

            return false;
        }

        //Debug.Log($"{transform.position.x}, {transform.position.y} || {Limits.min.x}, {Limits.min.y}");
        return true;
    }

    void GetPlayerMove()
    {
        fMoveInputX = Input.GetAxis("Horizontal");
        fMoveInputY = Input.GetAxis("Vertical");
    }

    void SetPlayerMove()
    {
        float fTemp = fMoveSpeed * Time.deltaTime;

        if (CheckMoveLimit() == true)
        {
            rigidbody2D.velocity = new Vector2(fMoveSpeed * fMoveInputX, fMoveSpeed * fMoveInputY);
        }
    }

    void SetFlip()
    {
        if (fMoveInputX < 0)
        {
            Flip(PlayerState.LEFT);
        }
        else if (fMoveInputX > 0)
        {
            Flip(PlayerState.RIGHT);
        }
        else
        {
            Flip(PlayerState.IDLE);
        }
    }

    private void Flip(PlayerState playerState)
    {
        spriteRenderer.sprite = sprites[(int)playerState];
        currentSprite = spriteRenderer.sprite;
    }
}
