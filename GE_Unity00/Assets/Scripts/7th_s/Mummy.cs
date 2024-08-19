using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mummy_hp))]

public class Mummy : MonoBehaviour
{
    [SerializeField] Mummy_hp health;

    void Awake()
    {
        health = GetComponent<Mummy_hp>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
