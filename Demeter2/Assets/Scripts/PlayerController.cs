using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;


    [SerializeField] private Animator Animator;
    
    
    /*private static readonly int LeftWalk = Animator.StringToHash("Left");
    private static readonly int RightWalk = Animator.StringToHash("Right");
    private static readonly int UpWalk = Animator.StringToHash("Up");
    private static readonly int DownWalk = Animator.StringToHash("Down");*/
    
    
    
    private static readonly int YDirection = Animator.StringToHash("YDirection");
    private static readonly int XDirection = Animator.StringToHash("XDirection");


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        
        movementDirection = new Vector2(x,y);
        Animator.SetFloat(YDirection,y);
        Animator.SetFloat(XDirection,x);


    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    
    
    
    
    
    
    
}
