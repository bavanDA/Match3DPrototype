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
    private void OnMouseDown()
    {
        transform.Translate(0f, 1f, 0f);
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        zeroPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - getMouseWorldPos();
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
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
