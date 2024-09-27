using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject ui_obj;
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    new Rigidbody2D rigidbody2D;

    [Header("Move_Input")]
    [SerializeField] float fMoveSpeed;
    [SerializeField] float fDirection;
    [SerializeField] float maxVelocityX, maxVelocityY;

    void LoadComponent()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Awake()
    {
        LoadComponent();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            Debug.Log($"체력 감소 {collision.gameObject.name}");
        }
    }

    public void SetBullet(float s, float d)
    {
        //fMoveSpeed = s;
        //fDirection = d;

        //transform.Rotate(0f, 0f, d);
    }

    public void OnMove()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        float randomForce = Random.Range(3, 7);

        rigidbody2D.AddForce(randomDirection * randomForce, ForceMode2D.Impulse);

       // CheckSpeedLimit();
    }

    public void CheckSpeedLimit()
    {
        if (rigidbody2D.velocity.x > maxVelocityX)
        {
            rigidbody2D.velocity = new Vector2(maxVelocityX, rigidbody2D.velocity.y);
        }
        if (rigidbody2D.velocity.x < (maxVelocityX * -1))
        {
            rigidbody2D.velocity = new Vector2((maxVelocityX * -1), rigidbody2D.velocity.y);
        }
    }
}
