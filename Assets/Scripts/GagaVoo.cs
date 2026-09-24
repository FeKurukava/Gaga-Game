using UnityEngine;
using UnityEngine.InputSystem;

public class GagaVoo : MonoBehaviour
{
    [Header("Voo")]
    [SerializeField] private float forcaVoo = 6f;
    [SerializeField] private float gravidade = 1.8f;

    private Rigidbody2D rb;

    public static bool jogoComecou = false;

    void Awake()
    {
        jogoComecou = false;

        rb = GetComponent<Rigidbody2D>();

        // Gaga começa completamente parada.
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!jogoComecou)
            {
                ComecarJogo();
            }
            else
            {
                Voar();
            }
        }
    }

    void ComecarJogo()
    {
        jogoComecou = true;

        rb.gravityScale = gravidade;

        Voar();
    }

    void Voar()
    {
        rb.linearVelocity = Vector2.zero;

        rb.AddForce(
            Vector2.up * forcaVoo,
            ForceMode2D.Impulse
        );
    }

    void OnGUI()
    {
        if (jogoComecou)
            return;

        GUIStyle estilo = new GUIStyle(GUI.skin.label);

        estilo.alignment = TextAnchor.MiddleCenter;
        estilo.fontSize = 32;
        estilo.fontStyle = FontStyle.Bold;
        estilo.normal.textColor = Color.white;

        float largura = 500f;
        float altura = 80f;

        Rect area = new Rect(
            (Screen.width - largura) / 2f,
            (Screen.height - altura) / 2f + 80f,
            largura,
            altura
        );

        GUI.Label(
            area,
            "APERTE ESPAÇO",
            estilo
        );
    }
}