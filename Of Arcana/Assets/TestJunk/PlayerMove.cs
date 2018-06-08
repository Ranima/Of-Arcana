using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveMod = 3;
    public float jumpMod = 1;
    public float stopMod = 0.8f;
    public float fallSpeed = 10;
    public float fallAcceleration = .8f;
    public float surface = 60;

    private CharacterController cc;
    private Vector3 move;
    private bool grounded;
    private float maxFallSpeed;

    // Use this for initialization
    void Awake()
    {
        cc = GetComponent<CharacterController>();
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
        move.x = Input.GetAxis("Horizontal") * moveMod;
        move.z = Input.GetAxis("Vertical") * moveMod;

        //gameObject.transform.Translate(move);
        Grounded();
        Gravity(grounded);
        cc.Move(move);

        move = move * stopMod;
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
        if((cc.collisionFlags & CollisionFlags.Below) != 0)
        {
            grounded = true;
            fallSpeed = 0;
        }
        else
        {
            grounded = false;
        }
    }
}
