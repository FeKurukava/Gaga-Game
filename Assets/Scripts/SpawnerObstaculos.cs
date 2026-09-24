using System.Collections;
using UnityEngine;

public class SpawnerObstaculos : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject obstaculoTelephone;

    [Header("Espacamento")]
    [SerializeField] private float distanciaEntreObstaculos = 3f;

    [Header("Tempo entre os 3 obstáculos")]
    [SerializeField] private float intervaloEntreObstaculos = 0.4f;

    [Header("Altura")]
    [SerializeField] private float alturaMinima = -1.2f;
    [SerializeField] private float alturaMaxima = 1.2f;

    [Header("Spawn continuo")]
    [SerializeField] private float margemForaDaTela = 1.2f;

    private Camera cam;
    private float limiteDireito;
    private float spawnBaseX;

    private Transform ultimoObstaculo;

    // Impede que vários grupos sejam criados ao mesmo tempo
    private bool gerandoGrupo = false;

    void Start()
    {
        cam = Camera.main;

        float metadeLargura =
            cam.orthographicSize * cam.aspect;

        limiteDireito =
            cam.transform.position.x + metadeLargura;

        spawnBaseX =
            limiteDireito + margemForaDaTela;

        CriarGrupoInicial();
    }

    void Update()
    {
        // Antes do jogador apertar espaço,
        // não cria novos obstáculos.
        if (!GagaVoo.jogoComecou)
            return;

        if (ultimoObstaculo == null)
            return;

        // Não inicia outro grupo enquanto
        // os 3 atuais ainda estão sendo criados.
        if (gerandoGrupo)
            return;

        float pontoNovoGrupo =
            spawnBaseX - distanciaEntreObstaculos;

        if (ultimoObstaculo.position.x <= pontoNovoGrupo)
        {
            StartCoroutine(CriarGrupoForaDaTela());
        }
    }

    void CriarGrupoInicial()
    {
        // Os três primeiros já ficam posicionados
        // na parte da frente da tela.

        float[] posicoesViewport =
        {
            1.00f,
            1.20f,
            1.40f
        };

        for (int i = 0; i < 3; i++)
        {
            Vector3 mundo =
                cam.ViewportToWorldPoint(
                    new Vector3(
                        posicoesViewport[i],
                        0.5f,
                        -cam.transform.position.z
                    )
                );

            GameObject novo =
                CriarObstaculo(mundo.x);

            ultimoObstaculo =
                novo.transform;
        }
    }

    IEnumerator CriarGrupoForaDaTela()
    {
        gerandoGrupo = true;

        for (int i = 0; i < 3; i++)
        {
            // Todos nascem no mesmo ponto da direita.
            // Como os anteriores já estão se movendo,
            // eles ficam naturalmente separados.
            GameObject novo =
                CriarObstaculo(spawnBaseX);

            ultimoObstaculo =
                novo.transform;

            // Espera um pouco antes do próximo.
            yield return new WaitForSeconds(
                intervaloEntreObstaculos
            );
        }

        gerandoGrupo = false;
    }

    GameObject CriarObstaculo(float x)
    {
        float y =
            Random.Range(
                alturaMinima,
                alturaMaxima
            );

        return Instantiate(
            obstaculoTelephone,
            new Vector3(x, y, 0f),
            Quaternion.identity
        );
    }
}