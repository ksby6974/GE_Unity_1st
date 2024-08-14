using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool bStanding;

    private void Awake()
    {
        bStanding = true;
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.GetCurrentAnimatorStateInfo(0).IsName("Trigger_run") == false

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (bStanding == true)
            {
                Debug.Log("Running start");
                animator.SetTrigger("Trigger_run");
            }
            else
            {
                Debug.Log("Running stop");
                animator.SetTrigger("Trigger_idle");
            }

            bStanding = !bStanding;
        }
    }
}
