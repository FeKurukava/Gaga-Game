using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    [SerializeField] private float velocidade = 4f;
    [SerializeField] private float limiteEsquerda = -12f;

    void Update()
    {
        if (!GagaVoo.jogoComecou)
            return;

        transform.position +=
            Vector3.left *
            velocidade *
            Time.deltaTime;

        if (transform.position.x < limiteEsquerda)
        {
            Destroy(gameObject);
        }
    }
}