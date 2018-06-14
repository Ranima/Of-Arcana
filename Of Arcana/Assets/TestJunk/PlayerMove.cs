using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveMod = 3;
    public float jumpforce = 1;
    public float stopMod = 0.8f;
    public float fallSpeed = 10;
    public float fallAcceleration = .8f;
    public float maxSurfaceAngle = 60;
    public float distanceToGround = 1;
    public bool isPlayer = false;

    private Vector3 move;
    public bool grounded;
    private float maxFallSpeed;
    private Ray down;
    private RaycastHit hit;

    // Use this for initialization
    void Awake()
    {
        maxFallSpeed = fallSpeed;
        fallSpeed = 0;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        if (grounded)
        {
            move.x = Input.GetAxis("Horizontal") * moveMod;
            move.z = Input.GetAxis("Vertical") * moveMod;
        }

        //gameObject.transform.Translate(move);
        Grounded();
        Jump(Input.GetAxis("Jump"));
        Gravity(grounded);

        if (grounded)
        {
            move = move * stopMod;
        }
    }

    void Gravity(bool t)
    {
        if (!t)
        {
            fallSpeed += Time.deltaTime * fallAcceleration;
            if (fallSpeed > maxFallSpeed)
            {
                fallSpeed = maxFallSpeed;
            }
            move.y = -fallSpeed;
        }
    }

    void Grounded()
    {
        down.origin = transform.position;
        down.direction = Vector3.down;
        Debug.DrawRay(down.origin, down.direction, Color.magenta);
        if (Physics.Raycast(down, out hit, distanceToGround) && hit.normal.magnitude < maxSurfaceAngle && fallSpeed > -0.01)
        {
            grounded = true;
            fallSpeed = 0;
        }
        else
        {
            grounded = false;
        }
        Debug.Log(grounded);
    }

    void Jump(float i)
    {
        if(i > 0.0 && grounded == true)
        {
            fallSpeed = -jumpforce;
        }
    }
}

