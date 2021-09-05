using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimlarObjectsCheck : MonoBehaviour
{
    public GameObject activeObject1;
    public GameObject activeObject2;
    public GameObject pos1;
    public GameObject pos2;
    public Text scoreText;
    public int score;
    public int numberOfObjects;
    public GameObject Win;
    
    // Start is called before the first frame update
    void Start()
    {
        //Win = GameObject.Find("Win");
        Win.SetActive(false);
        score = 0;
        var objects = GameObject.FindGameObjectsWithTag("playableObject");
        numberOfObjects = objects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfObjects == 0)
        {
            Win.SetActive(true);
        }
        scoreText.text = score.ToString();
        if (activeObject1.gameObject.tag!="trash")
        {
            
            if (activeObject2.gameObject.tag != "trash")
            {
                if (activeObject1.GetComponent<playableObjects>().id == activeObject2.GetComponent<playableObjects>().id)
                {
                    Destroy(activeObject1);
                    Destroy(activeObject2);
                    
                    activeObject1 = pos1;
                    activeObject2 = pos2;
                    Debug.Log(activeObject1.tag);
                    Debug.Log(activeObject2.tag);
                    score++;
                    numberOfObjects-=2;
                    
                }
            }
        }
    }
}
