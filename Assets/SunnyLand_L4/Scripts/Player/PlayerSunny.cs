using UnityEngine;

public class PlayerSunny : MonoBehaviour
{
    [Header("Setup")]
    public Joystick joystick;
    public Transform SpawnPoint;
    public bool isGrounded;
    public bool isJumping;

    [Header("Joystick Sense - Default = Horizontal(0.2) & Vertical(0.15)")]
    [Range(0f,1f)] public float JoystickHorizontalSensitivity = 0.2f;
    [Range(0f,1f)] public float JoystickVerticalSensitivity = 0.15f;

    [Header("Player Movement - Default = Horizontal(500) & Vertical(10000)")]
    [SerializeField] public float HorizontalForce = 500f;
    [SerializeField] public float VerticalForce = 10000f;

    private Rigidbody2D rb2d;
    private Animator Anim;
    private SpriteRenderer sr;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (joystick.Horizontal > JoystickHorizontalSensitivity)
        {
            // Moving Right
            rb2d.AddForce(Vector2.right * HorizontalForce * Time.deltaTime);
            sr.flipX = false;
        }

        else if (joystick.Horizontal < -JoystickHorizontalSensitivity)
        {
            // Moving Left
            rb2d.AddForce(Vector2.left * HorizontalForce * Time.deltaTime);
            sr.flipX = true;
        }

        if (joystick.Vertical > JoystickVerticalSensitivity && isGrounded)
        {
            // Jump
            rb2d.AddForce(Vector2.up * VerticalForce * Time.deltaTime);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        isJumping = false;
    
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }
}
