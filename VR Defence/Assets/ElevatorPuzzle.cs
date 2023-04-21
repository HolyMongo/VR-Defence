using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPuzzle : MonoBehaviour
{
    private float maxCount;
    private float count = 0;


    [SerializeField] private float startDelay = 5;
    private float delay = 0;
    //Reference to the obj target
    [SerializeField] private GameObject obj;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 speed;

    private void Awake()
    {
        foreach (var child in transform)
        {
            maxCount++;
        }
      
    }
    private void Start()
    {
        Debug.Log(maxCount);
        Debug.Log("In maxCount");
    }
    void Update()
    {
       
        if(count >= maxCount)
        {
            Invoke("MoveUp", startDelay);
          
               
            

          if(obj.transform.position.y >= endPos.y)
            {                        
                obj.transform.position = endPos;
                foreach (Transform child in transform)
                {
                    //GameObject.Destroy(child.gameObject);
                   
                    child.transform.localPosition = new Vector3(0, 2, 2);

                }
             
            }
          
        }
        else if(count <= maxCount)
        {
           
                Invoke("MoveDown", startDelay);
            
              

            if (obj.transform.position.y <= startPos.y)
            {

                obj.transform.position = startPos;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Puzzle"))
        {
            count++;
            Debug.Log("Count increased");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Puzzle"))
        {
            count--;
            Debug.Log("Count decreased");
        }
    }



    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5); 
    }

    public void MoveUp()
    {
        if (obj.transform.position.y != endPos.y)
        {
            obj.transform.position += speed * Time.deltaTime;
        }
        
    }
    public void MoveDown()
    {
        if (obj.transform.position.y != startPos.y)
        {
            obj.transform.position -= speed * Time.deltaTime;
        }
      
    }

}
