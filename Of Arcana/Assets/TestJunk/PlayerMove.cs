using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveMod = 3;
    public float jumpMod = 1;
    public float stopMod = 0.8f;

    private Vector3 move;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        
	}

    void Movement()
    {
        move.x = Input.GetAxis("Horizontal") * moveMod;
        move.z = Input.GetAxis("Vertical") * moveMod;
        
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Input.GetAxis("Jump") * jumpMod, 0));

        gameObject.transform.Translate(move);

        move = move * stopMod;
    }
}
