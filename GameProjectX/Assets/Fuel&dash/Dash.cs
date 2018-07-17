using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;
    public KeyCode pressShift;

    float Fuel = 0.5f;
    float MaxFuel = 0.5f;
	bool refuelcooldown = false;
    bool resethandleit = false;
	bool stopcou =false;

	[SerializeField]
	float fueltext;
	float t;
	IEnumerator FuelCoolDown;
    Rect DisplayFuel;
    Texture2D Fueltexture;
    int x = 0;

	IEnumerator HandleIt()
	{
		refuelcooldown = false;
		print (Time.time);
        print("entered the couritine");
		yield return new WaitForSeconds(5);
		print (Time.time);

		if (stopcou == true) 
		{
			refuelcooldown = true;
			stopcou = false;
		}
        StopCoroutine(FuelCoolDown);
        FuelCoolDown = HandleIt();
	}
	void startRefuel()
	{
		StartCoroutine (FuelCoolDown);
        print("it should have entered the coroutine");
         x = 1;
	}
	void stopRefuel()
	{
		StopCoroutine (FuelCoolDown);
		FuelCoolDown = HandleIt();
	}

    void Start ()
    {
        DisplayFuel = new Rect(Screen.width/10, Screen.height*9/10,Screen.width/3,Screen.height/50);
        Fueltexture = new Texture2D(1, 1);
        Fueltexture.SetPixel(0, 0, Color.white);
        Fueltexture.Apply();
		FuelCoolDown = HandleIt ();

	}
    

    // Update is called once per frame
    void Update ()
	{
		

        if (Input.GetKey(pressShift) && Input.GetKey(pressDown))
        {
            //Make it dashforward backwards
            transform.Translate(Vector3.forward * 60 * Time.deltaTime);

        }

        if (Input.GetKey(pressShift) && Input.GetKey(pressUp))
        {
            //Make it dashforward forward

            transform.Translate(Vector3.back * 60 * Time.deltaTime);
        }

        if (Input.GetKey(pressShift) && Input.GetKey(pressLeft) && Fuel > 0)
		{
			fueltext = Fuel;
            refuelcooldown = false;
            Fuel -= Time.deltaTime;
            transform.Translate(Vector3.right * 60 * Time.deltaTime);

			if (stopcou == true) 
			{
				stopcou = false;
				stopRefuel ();
				resethandleit = true;

			}
            if (stopcou == false)
            {
                resethandleit = true;
            }

        }
         if (Fuel < MaxFuel && !Input.GetKey(pressShift))//Refuel
        {     
			if (resethandleit == true) 
			{
				print ("Enters 1time");
				stopcou = true;
				resethandleit = false;
                startRefuel ();
               
                print ("Enters 2time");
			}
            if (refuelcooldown == true)
            {
                Fuel += Time.deltaTime;
				fueltext = Fuel;
            }
            
        }
		if (Fuel >= MaxFuel) 
		{
			resethandleit = true;
		}

        if (Input.GetKey(pressShift) && Input.GetKey(pressRight))
        {
            //Dash Right
            transform.Translate(Vector3.left * 60 * Time.deltaTime);

        }  
    }


    void OnGUI()
    {
        float ratio = Fuel / MaxFuel;
        float rectWidth = ratio * Screen.width/6;
        DisplayFuel.width = rectWidth;
        GUI.DrawTexture(DisplayFuel, Fueltexture);
    }
}
