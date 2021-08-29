using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimlarObjectsCheck : MonoBehaviour
{
    public GameObject activeObject1;
    public GameObject activeObject2;
    public GameObject pos1;
    public GameObject pos2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (activeObject1.gameObject.tag!="trash")
        {
            
            if (activeObject2.gameObject.tag != "trash")
            {
                if (activeObject1.GetComponent<playableObjects>().id == activeObject2.GetComponent<playableObjects>().id)
                {
                    Destroy(activeObject1);
                    Destroy(activeObject2);
                    Debug.Log("similar");
                    activeObject1 = pos1;
                    activeObject2 = pos2;
                    Debug.Log(activeObject1.tag);
                    Debug.Log(activeObject2.tag);
                }
            }
        }
    }
}
