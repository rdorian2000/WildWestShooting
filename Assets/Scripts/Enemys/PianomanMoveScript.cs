using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PianomanMoveScript : MonoBehaviour
{
    private Animator animator;
    private GameObject pianoPoint;
    private NavMeshAgent navMeshAgent;
    private Transform target;

    private string[] randomPianoMusic = new string[] { "PianoMusic1", "PianoMusic2", "PianoMusic3", "PianoMusic4", "PianoMusic5", "PianoMusic6" };
    private int actualMusicIndex;
    private string actualMusic;

    public bool isPlayPiano = false;

    void Awake()
    {
        pianoPoint = GameObject.Find("PianomanEndPoint");
        target = pianoPoint.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();  
        animator.SetBool("isPlay", isPlayPiano);
    }
    
    void Start()
    {
        navMeshAgent.destination = target.transform.position;
        actualMusicIndex = Random.Range(0, randomPianoMusic.Length);
        actualMusic = randomPianoMusic[actualMusicIndex];
    }

    void Update()
    {
        if (isPlayPiano && gameObject.transform.rotation != pianoPoint.transform.rotation)
        {
            gameObject.transform.rotation = pianoPoint.transform.rotation;
        }

        if (animator.GetBool("isDeath") == true || Time.timeScale == 0 )
        {
            //AudioManagerScript.Instance.StopMusic(actualMusic);           
        }
        
    }
    void OnCollisionEnter(Collision col)
    {      
        if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint)
        {          
            isPlayPiano = true;
            animator.SetBool("isPlay", isPlayPiano);
            AudioManagerScript.Instance.PlayMusic(actualMusic);
        }      
    }

}
