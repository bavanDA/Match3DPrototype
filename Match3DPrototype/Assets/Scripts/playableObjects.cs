using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playableObjects : MonoBehaviour
{
    public int id;
    Vector3 mousePosition;
    Vector3 mouseOffset;
    float zeroPoint;
    public bool Drag;
    public GameObject trash;
    public GameObject targetPosition1;
    public GameObject targetPosition2;
    public bool isAct;
    private void Start()
    {
        Drag = false;
        isAct = false;
        trash = GameObject.Find("trash");
        targetPosition1 = GameObject.Find("TargetPosition1");
        targetPosition2 = GameObject.Find("TargetPosition2");
    }

    private void Update()
    {
        if (Drag == false && !isAct)
        {
            if (transform.position.x > (trash.transform.position.x - 2) && transform.position.x < (trash.transform.position.x + 2))
            {
                if(transform.position.z > trash.transform.position.z - 2 && transform.position.z < trash.transform.position.z + 2)
                {
                    
                    if (trash.GetComponent<SimlarObjectsCheck>().activeObject1.tag=="trash")
                    {
                        trash.GetComponent<SimlarObjectsCheck>().activeObject1 = this.gameObject;
                        
                        isAct = true;
                    }
                    else
                    {
                        trash.GetComponent<SimlarObjectsCheck>().activeObject2 = this.gameObject;
                        this.transform.position = targetPosition2.transform.position;
                    }
                }
            }
        }

        if (isAct)
        {
            this.transform.position = targetPosition1.transform.position;
            Rigidbody rb= this.GetComponent<Rigidbody>();
            rb.drag = 500;
            rb.angularDrag = 500;
            this.transform.rotation = new Quaternion(0f, 0f, 0f,0f);
            //Debug.Log("1:" + trash.GetComponent<SimlarObjectsCheck>().activeObject1.tag);
            //Debug.Log("2:" + trash.GetComponent<SimlarObjectsCheck>().activeObject2.tag);
        }
        else
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.drag = 0.5f;
            rb.angularDrag = 0;
            if (trash.GetComponent<SimlarObjectsCheck>().activeObject1 == this.gameObject)
            {
                trash.GetComponent<SimlarObjectsCheck>().activeObject1 = trash.GetComponent<SimlarObjectsCheck>().pos1;
            }
        }
    }
    private void OnMouseDown()
    {
        Drag = true;
        isAct = false;
        transform.Translate(0f, 1f, 0f);
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        zeroPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - getMouseWorldPos();
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Drag = false;
    }

    private void OnMouseDrag()
    {
        transform.position = getMouseWorldPos() + mouseOffset;
    }

    Vector3 getMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zeroPoint;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
