using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{

    public KeyCode pressUp;
    public KeyCode pressDown;
    public Animator walk;
    

    void Start()
    {
        walk = GetComponent<Animator>();
    }

    void Update()
    {

        //This code segments works as the walking forward and backwards animation. 
        //If you press the key it will move a foot but it will not finish the whole animation. 
        //If you want to finish a complete cycle of the animation you must keep the button pressed  (This is intentional).
        if (Input.GetKey(pressUp))
        {
           
            walk.Play("Walking");
           walk.SetFloat("Direction", 2);
            walk.enabled = true;
        }
        else if (Input.GetKey(pressDown))
        {
            //NOTE**: The following snippet of code plays the animation backwards, but the only way to play it backwards
            //and play it correctly a
            walk.enabled = true;
            walk.SetFloat("Direction", -2);
        }
       
        else
        {  
            walk.enabled = false; //Helper for pausing animation (Very important!)
        }
      
    }
}
