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
    private static string actualMusic;

    public bool isPlayPiano = false;

    void Awake()
    {            
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("isPlay", isPlayPiano);
    }
    
    void Start()
    {
        FindTarget();
        actualMusicIndex = Random.Range(0, randomPianoMusic.Length);
        actualMusic = randomPianoMusic[actualMusicIndex];
        cigar.SetActive(false);
        cigarSmoke.Stop();
    }

    void Update()
    {      
        //The Pianist sits down for the piano.
        if (isPlayPiano && gameObject.transform.rotation != pianoPoint.transform.rotation)
        {
            gameObject.transform.rotation = pianoPoint.transform.rotation;
        }

        //Stop the music.
        if (animator.GetBool("isDeath") == true || GameManager.gameEnd == true )
        {          
            StopAcutalMusic();        
        }
        
    }
    //When the music is not muted, the pianist play on the piano. When the music is muted, the pianist smoke.
    public void FindTarget()
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
        navMeshAgent.destination = target.transform.position;
    }
    //The piano position and the smoke position.
    void OnCollisionEnter(Collision col)
    {      
        if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint && AudioManagerScript.Instance.mute == false && pianoPoint.name == "PianomanEndPointPiano")
        {          
            isPlayPiano = true;
            animator.SetBool("isPlay", isPlayPiano);
            AudioManagerScript.Instance.PlayMusic(actualMusic);
        }     
        else if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint && AudioManagerScript.Instance.mute == true && pianoPoint.name == "PianomanEndPointSmoke")
        {
            gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
            animator.SetBool("isSmoke", true);
            animator.SetBool("isSmoking", true);
            StartCoroutine(Smoking());
        }
        else
        {
            if(animator.GetBool("isPlay")== false && animator.GetBool("isSmoke") == false && animator.GetBool("isSmoking") == false)
            {
                FindTarget();
            }          
        }
    }
    //The pianists smoke.
    public IEnumerator Smoking()
    {
        yield return new WaitForSeconds(7);
        cigar.SetActive(true);
        yield return new WaitForSeconds(5);
        cigarSmoke.Play();
    }
    //Stop the piano music.
    public static void StopAcutalMusic()
    {
        AudioManagerScript.Instance.StopMusic(actualMusic);
    }

    

}
