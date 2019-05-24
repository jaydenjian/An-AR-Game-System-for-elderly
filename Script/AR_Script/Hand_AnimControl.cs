using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_AnimControl : MonoBehaviour
{
    public GameObject ARCamera;

    public bool SomethingInRange;
    public bool Grab_State;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grab_State = ARCamera.GetComponent<DetectTrigger>().AlreadyHeld;
        SomethingInRange = ARCamera.GetComponent<DetectTrigger>().SomethingInRange;

        if (Grab_State == true)
        {
            transform.GetComponent<Animator>().SetBool("Grabbed", true);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("Grabbed", false);
        }

        if (SomethingInRange == true)
        {
            transform.GetComponent<Animator>().SetBool("SomethingInRange", true);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("SomethingInRange", false);
        }

    }
}
