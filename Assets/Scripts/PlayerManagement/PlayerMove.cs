using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool canMove;
    public int playerOnLadder = 0;

    //private Inventory inventory;
    //[SerializeField] private UI_Inventory uiinventory;

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
        //inventory = new Inventory();
        //uiinventory.SetInventory(inventory);
        //ItemWorld.SpawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.Bow, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(-20, 20), new Item { itemType = Item.ItemType.Armor, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(0, 20), new Item { itemType = Item.ItemType.Jacket, amount = 1 });
    }

    void Start()
    {
        facingRight = true;
        canMove = true;
        joystick = GameObject.FindGameObjectWithTag("joystick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
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

            if (joystick.Horizontal() >0.02)
            {
                Anim.SetBool("Run", true);
            }
            else
            {
                Anim.SetBool("Run", false);
            }
        }
        if (!canMove)
        {
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
                
                Anim.SetBool("Jump", true);
                rb.velocity = Vector2.up * verticalImpulse;
                extraJumps--;
                StartCoroutine(MyMethodForJump());
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag=="FlyingEnemy")
        {
            healthFill -= 0.25f;
        }
    }

    IEnumerator MyMethodForJump()
    {
      
        yield return new WaitForSeconds(0.2f);
        Anim.SetBool("Jump", false);

    }


}
