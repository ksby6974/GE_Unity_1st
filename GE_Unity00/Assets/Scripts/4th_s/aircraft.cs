using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraft : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        // ������ �籸��
        direction.Normalize();

        // P = P0 + vt
        // Time.deltaTime : ������ �������� �Ϸ�� �� ����� �ð��� �ʴ����� ��ȯ
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
