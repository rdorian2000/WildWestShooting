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
    public GameObject cigar;
    public ParticleSystem cigarSmoke;

    private string[] randomPianoMusic = new string[] { "PianoMusic1", "PianoMusic2", "PianoMusic3", "PianoMusic4", "PianoMusic5", "PianoMusic6" };
    private int actualMusicIndex;
    private string actualMusic;

    public bool isPlayPiano = false;

    void Awake()
    {
        if (AudioManagerScript.Instance.mute == true)
        {
            pianoPoint = GameObject.Find("PianomanEndPointSmoke");
        }
        else
        {
            pianoPoint = GameObject.Find("PianomanEndPointPiano");
        }     
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
        cigar.SetActive(false);
        cigarSmoke.Stop();
    }

    void Update()
    {
        if (isPlayPiano && gameObject.transform.rotation != pianoPoint.transform.rotation)
        {
            gameObject.transform.rotation = pianoPoint.transform.rotation;
        }

        if (animator.GetBool("isDeath") == true || Time.timeScale == 0 )
        {
            AudioManagerScript.Instance.StopMusic(actualMusic);           
        }
        
    }
    void OnCollisionEnter(Collision col)
    {      
        if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint && AudioManagerScript.Instance.mute == false)
        {          
            isPlayPiano = true;
            animator.SetBool("isPlay", isPlayPiano);
            AudioManagerScript.Instance.PlayMusic(actualMusic);
        }
        if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint && AudioManagerScript.Instance.mute == true)
        {
            gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
            animator.SetBool("isSmoke", true);
            animator.SetBool("isSmoking", true);
            StartCoroutine(Smoking());

        }
    }

    public IEnumerator Smoking()
    {
        yield return new WaitForSeconds(7);
        cigar.SetActive(true);
        yield return new WaitForSeconds(5);
        cigarSmoke.Play();
    }

}
