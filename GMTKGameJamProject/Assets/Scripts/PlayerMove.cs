using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject playerInputObject;
    PlayerInput playerInput;
    public float speed;
    [HideInInspector] public Vector3 target;
    [HideInInspector] public bool isJumping;
    public float jumpAnimationTime; // This is dependent on the time the jump animation takes!

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerInput = playerInputObject.GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerInput.keyObject != null)
        {
            target = playerInput.keyObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackSpace")) // Player performs jump!
        {
            Debug.Log("Jumps!");
            animator.SetTrigger("Jump");
            StartCoroutine(jumpCoolDown(jumpAnimationTime));
        }

        if (collision.gameObject.CompareTag("Log"))
        {
            if (!isJumping)
            {
                Debug.Log("Hit");
            }
        }
    }

    IEnumerator jumpCoolDown(float jumpTime)
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpTime);
        isJumping = false;
    }
}
