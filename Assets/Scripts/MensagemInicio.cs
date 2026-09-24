using UnityEngine;

public class MensagemInicio : MonoBehaviour
{
    void Update()
    {
        if (GagaVoo.jogoComecou)
        {
            gameObject.SetActive(false);
        }
    }
}