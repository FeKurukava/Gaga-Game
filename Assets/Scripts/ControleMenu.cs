using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleMenu : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("SelecaoFase");
    }
}