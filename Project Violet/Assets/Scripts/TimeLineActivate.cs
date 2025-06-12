using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimeLineActivate : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    Scene inicio;
    Scene jogo;

    private void Start()
    {
        inicio = SceneManager.GetSceneByName("Demo_Scene");
        jogo = SceneManager.GetSceneByName("Actual game");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            director.Play();    
        }
    }

    public void TrocarDeCena()
    {
        SceneManager.LoadScene("Actual game");

    }
}
