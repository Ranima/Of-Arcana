using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveMod = 3;
    public float jumpMod = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * moveMod, 0, Input.GetAxis("Vertical") * moveMod));
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Input.GetAxis("Jump") * jumpMod, 0));
	}
}
