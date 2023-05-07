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
    [SerializeField] private float newSpeed = 0.1f;



    //Reference timer text
    [SerializeField] private TMP_Text timerText;
    private float timer;
    private float timer2 = 0;

    //Reference count text
    [SerializeField] private TMP_Text countText;
    private float countNumber = 0;

    private List<Vector3> ballsTransform = new List<Vector3>();

    private void Awake()
    {
        timer = startDelay;
        foreach (var child in transform)
        {
            maxCount++;
            ballsTransform.Add(((Transform)child).localPosition);
        }
       
    }
    private void Start()
    {
        Debug.Log(maxCount);
        Debug.Log("In maxCount");
        timerText.text = timer.ToString();
        countText.text = countNumber + "/" + maxCount;
    }
    void FixedUpdate()
    {
       
        if(count >= maxCount)
        {
           
            if (timer2 != startDelay)
            {
                Invoke("StartDelay", 1);
            }
            if(timer2 >= startDelay)
            {
                MoveUp();
            }
          
          
               
            

          if(obj.transform.position.y >= endPos.y)
            {                        
                obj.transform.position = endPos;
                BallsStartPoint();

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
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, endPos, newSpeed);

    }
    public void MoveDown()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, startPos, newSpeed);
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

   public void BallsStartPoint()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.localPosition = ballsTransform[i];
        }
    }
}
