using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController Instance;


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
    public bool CanMove;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!CanMove)
        {
            return;
        }
        
        
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        movementDirection = new Vector2(x, y);
        Animator.SetFloat(YDirection, y);
        Animator.SetFloat(XDirection, x);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player.Instance.SmallLand != null)
            {
                rb.velocity= Vector2.zero;
                Player.Instance.SmallLand.SetLand();
                Player.Instance.SmallLand = null;
                PlayerAnimatorController.Instance.Hit();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!CanMove)
        {
            return;
        }
        rb.velocity = movementDirection * movementSpeed;
    }
}