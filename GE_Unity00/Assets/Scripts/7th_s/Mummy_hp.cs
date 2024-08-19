using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mummy_hp : MonoBehaviour
{
    private float iHealth = 100;
    private float iInitHealth;

    [SerializeField] Slider healthSlider;
    [SerializeField] Image fillImage;
    [SerializeField] int[] stateHealths;
    [SerializeField] Color[] stateColors;

    void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        iInitHealth = iHealth;
        healthSlider.value = iHealth / iInitHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDamage(10);
        }

        OnState();
    }

    public void OnDamage(float damage)
    {
        iHealth = iHealth - damage;
        healthSlider.value = iHealth / iInitHealth;
    }

    public void OnState()
    {
        if (iHealth >= stateHealths[0])
        {
            fillImage.color = new Color(0,1,0);
        }
        else if (iHealth >= stateHealths[1])
        {
            fillImage.color = new Color(1, 1, 0);
        }
        else
        {
            fillImage.color = new Color(1, 0, 0);
        }
    }
}
