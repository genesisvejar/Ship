using UnityEngine;
using System.Collections.Generic;

public class FishCollector : MonoBehaviour
{
    public GameObject fish; //public so you can attach the prefab

    public List<GameObject> fishList= new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //this is to check if a the right click is pressed, and if so, we add fish
        if(Input.GetMouseButton(1))

        {
            AddFish();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void AddFish()
    {   
        //get mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z =-Camera.main.transform.position.z;
        //then transform them to world coordinate
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        //create aFish from the prefab
        GameObject aFish =Instantiate<GameObject>(fish);


        fish.transform.position = worldPosition;
        
        //add it to the list
        fishList.Add(aFish);

    }
}
