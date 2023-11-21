using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCounter : MonoBehaviour
{
    public GameObject[] Numbers;
    public GameObject enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdownDisable();
        StartCoroutine(Counter());
    }
    //Hide all counter gameobject.
    void StartCountdownDisable()
    {
        foreach (GameObject i in Numbers)
        {
            i.SetActive(false);
        }
    }
    //Counter befor the game is started.
    public IEnumerator Counter()
    {
        yield return new WaitForSeconds(2f);
        Numbers[4].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Numbers[4].SetActive(false);
        Numbers[3].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Numbers[3].SetActive(false);
        Numbers[2].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Numbers[2].SetActive(false);
        Numbers[1].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Numbers[1].SetActive(false);
        Numbers[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Numbers[0].SetActive(false);
        yield return null;

        enemySpawn.SetActive(true);
    }
}
