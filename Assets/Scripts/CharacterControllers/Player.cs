using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Toon
{
    private Vector2 movement;
    

    void Awake()
    {
        moveSpeed = 5.0f;
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        skillPointer = GameObject.Find("SkillPointer");
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MovementAnimatorControl(movement);
        DirectionAdjustment();
        SkillUsage();
        ConditionControl();
    }

    void FixedUpdate()
    {
        Move(movement);
    }


    void DirectionAdjustment()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            ChangeDirection("up");
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            ChangeDirection("left");
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            ChangeDirection("down");
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            ChangeDirection("right");        
    }

    void SkillUsage()
    {
        if ( Input.GetButtonDown("Fire2")) //Shield
            UseSkill(0);
        else if ( Input.GetButtonDown("Fire1")) // Normal ATK
            UseSkill(1);
        else if ( Input.GetKeyDown(KeyCode.Q)) // Especial Skill 1
            UseSkill(2);
        else if ( Input.GetKeyDown(KeyCode.E)) // Especial Skill 2
            UseSkill(3);

    }
}
