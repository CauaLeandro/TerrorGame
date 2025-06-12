using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class TVTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera tvCam;
    public GameObject fadeScreen;
    public Transform teleportPoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tvCam.Priority = 20;
            StartCoroutine(TransitionToOtherWorld());
        }
    }

    IEnumerator TransitionToOtherWorld()
    {
        yield return new WaitForSeconds(3f); // tempo pra ver a TV
        fadeScreen.SetActive(true); // ativa tela preta
        yield return new WaitForSeconds(1f);
        player.transform.position = teleportPoint.position;
        tvCam.Priority = 5; // volta pro normal
        fadeScreen.SetActive(false);
    }
}
