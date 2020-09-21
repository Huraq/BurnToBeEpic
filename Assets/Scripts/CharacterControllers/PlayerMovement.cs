using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement, direction;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        CheckDirection();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    void CheckDirection()
    {
        if (Input.GetKeyUp(KeyCode.W))
            direction = new Vector2(0.0f, 1.0f);
        else if (Input.GetKeyUp(KeyCode.A))
            direction = new Vector2(-1.0f, 0.0f);
        else if (Input.GetKeyUp(KeyCode.S))
            direction = new Vector2(0.0f, -1.0f);
        else if (Input.GetKeyUp(KeyCode.D))
            direction = new Vector2(1.0f, 0.0f);

        animator.SetFloat("IdleHorizontal", direction.x);
        animator.SetFloat("IdleVertical", direction.y);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.GetComponent<TilemapRenderer>().sortingLayerName);
    }
}
