using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour {
    public GameObject Missile_Emitter;
    public GameObject Missile;
    public float Missile_Forward_Force;

    public KeyCode Ctrl;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(Ctrl))
        {
            GameObject Temp_Missile_Handler;

            Temp_Missile_Handler = Instantiate(Missile, Missile_Emitter.transform.position, Missile_Emitter.transform.rotation) as GameObject;

            Temp_Missile_Handler.transform.Rotate(Vector3.left * 180);
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Missile_Handler.GetComponent<Rigidbody>();

            Temp_RigidBody.AddForce(transform.forward*-1 * Missile_Forward_Force);

            Destroy(Temp_Missile_Handler, 10.0f);
        }
		
	}
}
