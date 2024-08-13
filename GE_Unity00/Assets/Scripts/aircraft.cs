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

        // 벡터의 재구성
        direction.Normalize();

        // P = P0 + vt
        // Time.deltaTime : 마지막 프레임이 완료된 후 경과한 시간을 초단위로 반환
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
