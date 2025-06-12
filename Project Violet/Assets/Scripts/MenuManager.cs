using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Intro");
    }

 
    public void VerCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

   
    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo... tchê!");
        Application.Quit();
    }
}
