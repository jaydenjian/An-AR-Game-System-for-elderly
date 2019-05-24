using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class DetectTrigger : MonoBehaviour
{
    public GameObject ButtonR;
    public GameObject ButtonL;

    public bool Button_R_status = false;
    public bool Button_L_status = false;
    public bool Button_status; //total Button status

    public bool SomethingInRange; // use for hand

    private GameObject PickUp_Obj = null;

    public List<GameObject> EnterObjects;

    public bool AlreadyHeld;

    public bool TestButton = false;

    // Start is called before the first frame update
    void Start()
    {

        EnterObjects = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        Button_R_status = ButtonR.GetComponent<ButtonHandler>().ThisBottonState;
        Button_L_status = ButtonL.GetComponent<ButtonHandler>().ThisBottonState;

        if (Button_R_status && Button_L_status == true/*TestButton==true*/)
        {
            Button_status = true;
        }
        else
        {
            Button_status = false;
        }

        if (TestButton == true)
        {
            Button_status = true;
        }
        else
        {
            Button_status = false;
        }

        ////////keyboard test button setting////////////////
        if (Input.GetKeyDown("t"))
        {
            TestButton = true;
        }
        else if (Input.GetKeyUp("t"))
        {
            //Debug.Log("123");
            TestButton = false;
        }

        //movement, move for test

        float Forward = Input.GetAxis("Vertical");
        float Turn = Input.GetAxis("Horizontal");

        transform.position += new Vector3(Turn, 0, Forward);

        //Down

        if (Button_status != false  /* TestButton == true*/ )
        {

            if (EnterObjects.Count <= 0)
            {
                SomethingInRange = false;
                return;
            }
            SomethingInRange = true;
            PickUpObj();

        }

        //Up
        if (Button_status == false /* TestButton != true*/)
        {
            if (EnterObjects.Count <= 0)
            {
                SomethingInRange = false;
                return;
            }
            SomethingInRange = true;
            DropObj();

        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Item"))
        {
            return;
        }
        PickUp_Obj = other.gameObject;
        EnterObjects.Add(PickUp_Obj);

     

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Item"))
        {
            return;
        }

        PickUp_Obj = other.gameObject;
        EnterObjects.Remove(PickUp_Obj);
        PickUp_Obj = null;

    }

    public void PickUpObj()
    {


        //Null Check
        GameObject ReadytoPickup = EnterObjects[EnterObjects.Count - 1];

        if (!ReadytoPickup)
        {
            return;
        }



        //Already held,check

        if (AlreadyHeld)
        {

            return;
        }

        //Position

        ReadytoPickup.GetComponent<Rigidbody>().isKinematic = true;
        ReadytoPickup.transform.parent = this.transform;
        AlreadyHeld = true;


    }

    public void DropObj()
    {
        //Null Check
        GameObject ReadytoDrop = EnterObjects[EnterObjects.Count - 1];

        if (!ReadytoDrop)
            return;

        ReadytoDrop.GetComponent<Rigidbody>().isKinematic = false;
        ReadytoDrop.transform.parent = null;

        AlreadyHeld = false;


    }


}

