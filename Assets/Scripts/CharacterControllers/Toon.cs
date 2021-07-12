using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Toon : MonoBehaviour
{
    // Main Attributes
    internal int arc, str, dex, vig;
    // Secondary Attributes - int
    internal int pAtk, mAtk, pDef, mDef, hp;
    // Secondary Attributes - float
    internal float globalCooldown, moveSpeed, critRate, critDmg;
    // Terciary Attributes - int
    internal int shieldAmount, skillCharges;
    // Terciary Attributes - float
    internal float skill1CD, skill2CD, shieldCD, projectileThrust;
    // Terciary Attributes - string
    internal string condition;
    internal bool grounded;

    public Dictionary<string, Vector2> directions;
    internal Dictionary<string, Vector3> rotations;
    
    internal Rigidbody2D rb;
    internal Animator animator;
    internal Vector3 direction3d, rotation;
    internal GameObject skillPointer;
    public GameObject projectile;


    private void Start()
    {
        projectile = Resources.Load("Prefabs/Fireball") as GameObject;
        projectileThrust = 500.0f;
        
        directions = new Dictionary<string, Vector2>();
        rotations = new Dictionary<string, Vector3>();

        directions.Add("up", new Vector2(0.0f, 1.0f));
        directions.Add("left", new Vector2(-1.0f, 0.0f));
        directions.Add("down", new Vector2(0.0f, -1.0f));
        directions.Add("right", new Vector2(1.0f, 0.0f));

        rotations.Add("up", new Vector3(0.0f, 0.0f, 180.0f));
        rotations.Add("left", new Vector3(0.0f, 0.0f, 270.0f));
        rotations.Add("down", new Vector3(0.0f, 0.0f, 0.0f));
        rotations.Add("right", new Vector3(0.0f, 0.0f, 90.0f));
        hp = 100 + 220;

        condition = "";
        
        Debug.Log("Initial life: " + hp);
        Debug.Log(directions.Count);
    }

    internal void ConditionControl()
    {
        // Debug.Log(grounded);
        if (!grounded)
        {
            if (condition != "burn" && GameController.levelEnvironment == "Lava")
            {
                StartCoroutine("Burn");
                condition = "burn";
            }
        }
        
    }

    internal void HPModification(int amount)
    {
        hp += amount;
        Debug.Log("Damage: " + amount);
        Debug.Log("Life now is: "+ hp);
    }

    internal void Move(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    internal void ChangeDirection(string direction)
    {
        animator.SetFloat("IdleHorizontal", directions[direction].x);
        animator.SetFloat("IdleVertical", directions[direction].y);
        skillPointer.transform.localPosition = directions[direction];
        rotation = rotations[direction];
        direction3d = directions[direction];
    }

    internal void MovementAnimatorControl(Vector2 movement)
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    internal void UseSkill(int skillId)
    {
        if (skillId == 0) // Shield
        {
            Debug.Log("Shield not implemented");
        }
        else if (skillId == 1) // Normal ATK
        {
            GameObject skillUsed = Instantiate(projectile, skillPointer.transform.position, Quaternion.Euler(rotation));
            skillUsed.GetComponent<Rigidbody2D>().AddForce(direction3d * projectileThrust);
        }
        else if (skillId == 2) // Especial Skill 1
        {
            Debug.Log("Especial Skill 1 not implemented");
        }
        else if (skillId == 3) // Especial Skill 2
        {
            Debug.Log("Especial Skill 2 not implemented");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Saiu na Lava");
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Entrou na Lava");
        grounded = false;
    }

    IEnumerator Burn()
    {
        int burnCD = 5;
        Debug.Log("iniciou o burn");
        while (burnCD > 0)
        {
            HPModification(-5);
            yield return new WaitForSeconds(1.0f);
            burnCD--;
        }
        Debug.Log("Fim do burn");
        condition = "";
    }

    IEnumerator Wait(float seconds) 
    { 
        yield return new WaitForSeconds(seconds);
    }

}