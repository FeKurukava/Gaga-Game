using UnityEngine;

public class MovimentoObstaculo0 : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float destruirEmX = -12f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < destruirEmX)
        {
            Destroy(gameObject);
        }
    }
}