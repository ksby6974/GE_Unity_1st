using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float fRotation;
    [SerializeField] GameObject rotationObject;

    private void Awake()
    {
        fRotation = 120f;
    }

    void OnEnable()
    {
        rotationObject = GameObject.Find("RotationObject");
        fRotation = rotationObject.GetComponent<RotationObject>().Speed;
        transform.localRotation = rotationObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(this.transform.rotation.x, (fRotation * Time.deltaTime), this.transform.rotation.z);
    }
}
