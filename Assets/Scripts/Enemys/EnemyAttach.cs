using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.VirtualTexturing;

public class EnemyAttach : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject playerObject;
    private Transform player;
    public GameObject bulletPrefab;
    private Animator animator;
    public ParticleSystem gunShotSmoke;
    private GameObject shootZoneCol;
    public GameObject revolver;
    public int enemyAmmoNumber;
    void Start()
    {
        shootZoneCol = GameObject.Find("ShootZoneBackward");
        playerObject = GameObject.Find("Player");
        player = playerObject.transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAmmoNumber = Random.Range(3, 6);
        revolver.SetActive(false);
    }

    private void EnemyAttackPlayer()
    {
        navMeshAgent.speed=0;       
        animator.SetBool("isReady", true);
        revolver.SetActive(true);
        gunShotSmoke.Stop();
        transform.LookAt(player);

        if (enemyAmmoNumber >= 0) 
        {                   
            StartCoroutine(Shooting());
        }                              
    }

    private IEnumerator ShootStartTimer()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        EnemyAttackPlayer();
    }

    public IEnumerator Shooting()
    {                       
        while (enemyAmmoNumber != 0)
        {         
            yield return new WaitForSeconds(3);
            animator.SetBool("isShootIdle", true);
            transform.LookAt(player);
            yield return new WaitForSeconds(3);
            animator.SetBool("isShoot", true);        
            Shoot();          
        }
        animator.SetBool("isShootIdle", false);
        animator.SetBool("isShoot", false);
        animator.SetBool("isReady", false);     
        yield return new WaitForSeconds(3f);
        revolver.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        navMeshAgent.speed = 2;

    }

    void OnCollisionEnter(Collision col)
    {     
        if (gameObject.tag == "Enemy" && col.gameObject == shootZoneCol)
        {
            Debug.Log("Be�rt");
            StartCoroutine(ShootStartTimer());
            
        }
    }
    void Shoot()
    {        
        gunShotSmoke.Play();
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.rotation);
        Destroy(bullet, 5);
        enemyAmmoNumber -= 1;
        animator.SetBool("isShootIdle", false);
    }
}