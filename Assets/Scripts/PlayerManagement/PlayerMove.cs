using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    private bool checkDamage = true;
    private SpriteRenderer spriteRend;

    public Rigidbody2D rb;

    private bool inJump= false;

    public bool canMove;
    public int playerOnLadder = 0;

    public AudioSource jumpSound;
    public AudioSource runSound;
    public AudioSource damageSound;

    private Joystick joystick;

    public GameObject canvasStunText;

    public bool facingRight; // Отслеживание поворота персонажа (изначально он смотрит направо)

    public  float speedX; // Текущая скорость персонажа


    public float healthFill;// hp игрока

    private int extraJumps; // Кол-во доступных прыжков в данный момент
    public float verticalImpulse; // Сила прыжка
    public LayerMask whatIsGround; // Поиск объектов на сцене находящихся на слое Ground
    private bool isGrounded; // Находится ли персонаж на земле в данный момент
    public Transform groundCheck; // Точка от которой рисуется окружность для поиска обектов на слое Ground
    public float checkRadius; // Радиус откружности в котором происходит поиск обектов на слое Ground

    private Animator Anim;
    public bool checkAnim = true;

    private void Awake()
    {
        healthFill = 1f;
    }

    void Start()
    {
        facingRight = true;
        canMove = true;
        joystick = GameObject.FindGameObjectWithTag("joystick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround); // Проверка находится ли игрок на земле
        if (canMove)
        {
            transform.Translate(speedX, 0, 0); // Постоянное перемещение персонажа по оси x со скоростью speedX
            if (joystick.Horizontal() > 0.02)
            {
                speedX = joystick.Horizontal();
            }
            else
            {
                speedX = 0;
            }
            if (joystick.Vertical() > 0.3)
            {
                playerOnLadder = 1;

            }
            else if (joystick.Vertical() < -0.3)
            {
                playerOnLadder = -1;

            }
            else
            {
                playerOnLadder = 0;

            }

            if (joystick.Horizontal() >0.02&&!inJump)
            {
                Anim.SetBool("Run", true);
                runSound.mute = false;
            }
            else
            {
                runSound.mute = true;
                Anim.SetBool("Run", false);
            }
        }
        if (!canMove)
        {
            runSound.mute = true;
            Anim.SetBool("Run", false);
        }
    }

    public void Jump() // Функция прыжка при нажатии на клавишу
    {
            if (isGrounded) // Присвоение максимального кол-ва прыжков персонажу, если он находится на земле 
            {
                extraJumps = 1;
            }
            if (extraJumps > 0) // Имитация прыжка персонажа при помощи импульса направленного вверх
            {
                inJump = true;
                Anim.SetBool("Jump", true);
                jumpSound.Play();
                rb.velocity = Vector2.up * verticalImpulse;
                extraJumps--;
                StartCoroutine(MyMethodForJump());
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "FlyingEnemy")
        {
            if (checkDamage)
            {
                damageSound.Play();
                checkDamage = false;
                healthFill -= 0.25f;
                StartCoroutine(Damage());
            }
        }
    }

    IEnumerator Damage()
    {
        for (int i = 0; i < 3; i++) 
        { 
        spriteRend.color = new Color(255f, 255f, 255f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.7f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.3f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.7f);
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = new Color(255f, 255f, 255f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        }
        spriteRend.color = new Color(255f, 255f, 255f, 1f);
        checkDamage = true;
        yield return null;
    }

    IEnumerator MyMethodForJump()
    {
      
        yield return new WaitForSeconds(0.2f);
        Anim.SetBool("Jump", false);
        yield return new WaitForSeconds(0.5f);
        inJump = false;

    }


}
