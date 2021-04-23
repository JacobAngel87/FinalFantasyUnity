using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public bool isMoving;

    public LayerMask solidObjectsLayer;
    public LayerMask encountersLayer;
    public LayerMask entryPointsLayer;

    private Vector2 input;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if(input.y == 0)
                {
                    if(input.x > 0)
                    {
                        transform.eulerAngles = new Vector3(0,180,0);
                    } else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                } else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if(IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEntryPoint();
        CheckForEncounter();
    }
    public void Flip()
    {
        Vector3 currentRotation = transform.eulerAngles;
        if(currentRotation.y == 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
    private void CheckForEncounter()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, encountersLayer) != null)
        {
            if(Random.Range(1,101) <= 10)
            {
                print("Random Encounter has started!");
            }
        }
    }
    private void CheckForEntryPoint()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, entryPointsLayer) != null)
        {
            // Get Entry Point info somehow
            GameObject currentTile = Physics2D.OverlapCircle(transform.position, 0.2f, entryPointsLayer).gameObject;
            string name = currentTile.name.Substring(0, 4);
            
        }
    }
}