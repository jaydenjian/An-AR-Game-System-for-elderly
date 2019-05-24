using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class ControlAllChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.AddComponent<Outline>();
            this.transform.GetChild(i).gameObject.AddComponent<OutlineControl>();
        }


    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
        {
            return;
        }
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
        {
            return;
        }

        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Outline>().enabled = false;
        }
    }
}
