using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour
{

    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;
  
    void Start()
    {
      

    }
    
    void Update()
    {
        if(Input.GetKey(pressUp))//****IMPORTANT****Inside the GetKey() you can use "KeyCode.letter" like this GetKey(KeyCode.W) in order to define what key on the keyboard to use.
        {
            transform.position -= transform.forward * 30 * Time.deltaTime;
            //Later on I need to divide the animation in different segmenets and execute them depending on how long the player holds the up key.
            //walk.Play("Walking");
        }

        if (Input.GetKey(pressDown))
        {
            //Moves character backwards at certain speed
            transform.position -= -transform.forward * 30 * Time.deltaTime;
            
            //walk.Play("WalkingBackwards");
        }

        if (Input.GetKey(pressLeft))
        {
             //Moves character left at certain speed.
            transform.position -= -transform.right * 30 * Time.deltaTime;
        }

        if (Input.GetKey(pressRight))
        {   
              //Moves character Right at certain speed.
            transform.position -= transform.right * 30 * Time.deltaTime;
        }
     
    }
}