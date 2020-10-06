using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    Level01Controller levelController;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHieght = 3f;
    public int health = 100;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public ParticleSystem particleEmitter;

    public Slider healthBar;

    [SerializeField] GameObject deathPannel;


    // Start is called before the first frame update
    void Start()
    {
        deathPannel.SetActive(false);
        particleEmitter.Emit(0);
        healthBar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18f;
        }
        else
        {
            speed = 12f;
        }

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            particleEmitter.Emit(50);
            Debug.Log("Pressed primary button.");
        }
        
        if(health <= 0)
        {
            deathPannel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
    }

    public void HealthLoss() 
    {
        health -= 10;
        healthBar.value -= .1f;
        Debug.Log(health);
    }

    
}

