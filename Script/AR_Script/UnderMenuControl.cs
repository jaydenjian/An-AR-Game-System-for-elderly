using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WhetherAnim(bool GetDown)
    {
        if (GetDown == true)
        {
            transform.GetComponent<Animator>().SetBool("ChangeScene", true);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("ChangeScene", false);
        }
    }
}
