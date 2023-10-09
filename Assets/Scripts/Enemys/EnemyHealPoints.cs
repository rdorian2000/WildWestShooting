using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealPoints : MonoBehaviour
{
    public Slider enemyHealPointBar;

    public GameObject bloodSpawnPoint;
    public ParticleSystem bloodDrop;

    private GameManager gameManager;

    public int actualHP;
    public int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bloodDrop.Stop();      
        maxHP = Random.Range(1, 3);
        actualHP = maxHP;
        enemyHealPointBar.maxValue = maxHP;
        enemyHealPointBar.value = actualHP;
        enemyHealPointBar.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealPointBar.fillRect.gameObject.SetActive(true);
        enemyHealPointBar.value = actualHP;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RevolverBullet"))
        {
            if (gameObject.CompareTag("Enemy"))
            {
                gameManager.AddScore(1);
            }
            actualHP -= 1;
            bloodSpawnPoint.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, bloodSpawnPoint.transform.position.z);
            bloodDrop.Play();
            Destroy(other.gameObject);
        }
    }
}
