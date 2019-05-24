using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTogether : MonoBehaviour
{
    public GameObject TogetherObj;

    public GameObject ARCamera;

    public GameObject Canvas_Model;
    public GameObject Complete_Model;

    public bool Button_status = false;
    public bool GetIn = false;
    public bool Already_attach = false;


    public bool PreventFinishDup;

    public GameObject MemorizeButtonCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        MemorizeButtonCanvas = GameObject.Find("Canvas");

        Button_status = ARCamera.GetComponent<DetectTrigger>().Button_status;
        if (GetIn == true && Button_status != true)
        {
            PutObjTogether(TogetherObj);
            Already_attach = true;

            if (PreventFinishDup != true)
            {
                SetCompleteCanvasActive();
            }

        }
    }



    private void PutObjTogether(GameObject Obj)
    {
        Obj.transform.position = transform.position;
        Obj.transform.rotation = transform.rotation;
        Obj.GetComponent<Rigidbody>().isKinematic = true;
        Obj.transform.parent = this.transform;


    }


    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Item") && Button_status != true)
        {
            GetIn = true;

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") && Button_status == true)
        {
            GetIn = false;
            Already_attach = false;
            Debug.Log("1");
        }

    }

    public void SpawnCanvas()
    {
        //////////////////////////Spawn Canvas/////////////////////////////
        Instantiate(Canvas_Model, new Vector2(0, 0), Quaternion.identity);
        MemorizeButtonCanvas.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void SetCompleteCanvasActive()
    {
        Complete_Model.gameObject.SetActive(true);
        PreventFinishDup = true;
    }
}
