using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceCharacter() //when ground plane stage reposition,monster should be reposition too
    {

        transform.localPosition = new Vector3(0, 0.5f, 0);

    }
}
