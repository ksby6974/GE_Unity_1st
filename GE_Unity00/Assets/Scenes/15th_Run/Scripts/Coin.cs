using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float fRotation;
    [SerializeField] GameObject rotationObject;
    [SerializeField] float fScore;
    [SerializeField] ParticleSystem myParticle;

    private void Awake()
    {
        fRotation = 120f;
        fScore = 100f;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log($"Play");
            myParticle.Play();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (this.GetComponent<MeshRenderer>().enabled == true & c.gameObject.CompareTag("Player"))
        {
            Debug.Log($"C {fScore}");
            this.GetComponent<MeshRenderer>().enabled = false;
            myParticle.Play();
        }
    }

    public interface IHitalbe
    {
        public void Activate();
    }

    public interface ICollider
    {

    }

    public void Activate()
    {
        //myParticle.Play();
        //gameObject.GetComponent<BoxCollider>().enabled = false;
       // gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
