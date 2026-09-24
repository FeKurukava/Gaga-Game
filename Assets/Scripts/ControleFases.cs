using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleFases : MonoBehaviour
{
    public void BotaoJogo1()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    public void BotaoJogo2()
    {
        Debug.Log("Fase Telephone ainda bloqueada/em construção!");
    }

    public void BotaoJogo3()
    {
        Debug.Log("Fase Abracadabra ainda bloqueada/em construção!");
    }
}