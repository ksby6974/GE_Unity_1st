using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBullet : MonoBehaviour
{
    // ������Ʈ ���Ŀ� �����
    private void LateUpdate()
    {
        if (transform.position.x < Limits.Bmin.x ||
            transform.position.x > Limits.Bmax.x ||
            transform.position.y < Limits.Bmin.y ||
            transform.position.y > Limits.Bmax.y)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
