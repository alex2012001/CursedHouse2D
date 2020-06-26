using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Attack : MonoBehaviour
{
    private bool sound=  true;

    public AudioSource attackSound;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool check = false;

    public Transform attackPose;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public float damage;

    private Animator Anim;
    public bool checkAnim = true;

    public void Start()
    {
        Anim = GetComponent<Animator>();
        checkAnim = true;
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (check)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position,attackRange,whatIsEnemy);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].transform.parent.GetComponent<EnemyHealthPoints>().TakeDamage(damage);
                }
                check = false;
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        
        else 
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }

    public void AttackButtonDown()
    {
        check = true;
        if(checkAnim&&check)
        {
            checkAnim = false;
            Anim.SetBool("Atack", true);
            StartCoroutine(MyMethodForAtack());
            if (sound)
            {
                sound = false;
                attackSound.Play();
                StartCoroutine(forSound());
            }
         
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }

    IEnumerator MyMethodForAtack()
    {
        yield return new WaitForSeconds(0.2f);
        Anim.SetBool("Atack", false);
        yield return new WaitForSeconds(0.2f);
        checkAnim = true;
    }

    IEnumerator forSound()
    {
        yield return new WaitForSeconds(0.8f);
        sound = true;
        yield return null;
    }

}
