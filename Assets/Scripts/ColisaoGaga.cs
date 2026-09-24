using UnityEngine;

public class ColisaoGaga : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Gaga bateu no obstáculo!");
        }
    }
}