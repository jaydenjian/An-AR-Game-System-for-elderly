using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateUse : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
