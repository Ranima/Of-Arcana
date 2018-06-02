using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveMod = 3;
    public float jumpMod = 1;
    public float stopMod = 0.8f;
    public float fallSpeed = 10;
    public float surface = 60;

    private Vector3 move;
    private bool grounded;
    private float maxFallSpeed;

	// Use this for initialization
	void Awake () {
        maxFallSpeed = fallSpeed;
        fallSpeed = 0;
        grounded = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        
	}

    void Movement()
    {
        move.x = Input.GetAxis("Horizontal") * moveMod;
        move.z = Input.GetAxis("Vertical") * moveMod;

        gameObject.transform.Translate(move);
        Gravity(grounded);

        move = move * stopMod;
    }

    void Gravity(bool t)
    {
        if(!t)
        {
            fallSpeed += maxFallSpeed * Time.deltaTime;
            if(fallSpeed > maxFallSpeed)
            {
                fallSpeed = maxFallSpeed;
            }
            gameObject.transform.Translate(0, -fallSpeed, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        RaycastHit hit;
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = -Vector3.up;

        if(Physics.Raycast(ray, out hit) && hit.normal.magnitude < surface &&col.collider == hit.collider)
        {
            fallSpeed = 0;
            grounded = true;
        }
    }

    void OnCollisionExit()
    {
        grounded = false;
    }
}
