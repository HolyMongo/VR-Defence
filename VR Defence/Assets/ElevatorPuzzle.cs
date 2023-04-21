using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElevatorPuzzle : MonoBehaviour
{
    private float maxCount;
    private float count = 0;


    [SerializeField] private float startDelay = 5;
  
    //Reference to the obj target
    [SerializeField] private GameObject obj;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 speed;



    //Reference timer text
    [SerializeField] private TMP_Text timerText;
    private float timer;
    private float timer2 = 0;

    //Reference count text
    [SerializeField] private TMP_Text countText;
    private float countNumber = 0;

    private void Awake()
    {
        timer = startDelay;
        foreach (var child in transform)
        {
            maxCount++;     
        }
      
    }
    private void Start()
    {
        Debug.Log(maxCount);
        Debug.Log("In maxCount");
        timerText.text = timer.ToString();
        countText.text = countNumber + "/" + maxCount;
    }
    void Update()
    {
       
        if(count >= maxCount)
        {
           
            if (timer2 != startDelay)
            {
                Invoke("StartDelay", 1);
            }
            if(timer2 >= startDelay)
            {
                Invoke("MoveUp", 1);
            }
          
          
               
            

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
                timerText.text = "0";
                timer2 = 0;
                timer = startDelay;
                obj.transform.position = startPos;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Puzzle"))
        {
            count++;
            countNumber++;
            countText.text = countNumber + "/" + maxCount;
            Debug.Log("Count increased");
            if(count >= maxCount)
            {
                timerText.text = "5";           
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Puzzle"))
        {
            count--;
            countNumber--;
            countText.text = countNumber + "/" + maxCount;
            Debug.Log("Count decreased");
            if (count >= maxCount)
            {
                timerText.text = "0";           
            }
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

    public void StartDelay()
    {
       
        if(timer2 <= startDelay)
        {
            Debug.Log("Increased timer");
            timer -= Time.deltaTime;
            timer2 += Time.deltaTime;
            timerText.text = timer.ToString("F0");
        }
    }

}
