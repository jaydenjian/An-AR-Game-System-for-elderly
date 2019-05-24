using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Outline>().enabled = true ;
        }
        else if(Input.GetKeyUp("space"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
