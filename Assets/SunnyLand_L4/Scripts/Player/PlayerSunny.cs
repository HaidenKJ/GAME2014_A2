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
        
    }
}
