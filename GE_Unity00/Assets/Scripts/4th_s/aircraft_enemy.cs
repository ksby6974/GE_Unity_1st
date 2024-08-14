using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraft_enemy : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 9.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // P = P0 + vt
        // Time.deltaTime : 마지막 프레임이 완료된 후 경과한 시간을 초단위로 반환
        speed += 0.1f;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
    }

    public void ResetSpeed()
    {
        speed = 9.0f;
    }
}
