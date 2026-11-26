using System.Collections;
using UnityEngine;

public class MenuIntro : MonoBehaviour
{
    [SerializeField] private CanvasGroup fundido;
    [SerializeField] private RectTransform titulo;
    [SerializeField] private RectTransform panelBotones;
    [SerializeField] private CanvasGroup panelBotonesGrupo;
    [SerializeField] private RectTransform sombraHomer;

    private Vector2 posTitulo;
    private Vector2 posPanel;
    private Vector2 posHomer;

    private bool introTerminada = false;
    private bool controlarCadena = true;

    public bool IntroTerminada => introTerminada;

    void Awake()
    {
        posTitulo = titulo.anchoredPosition;
        posPanel = panelBotones.anchoredPosition;
        posHomer = sombraHomer.anchoredPosition;

        fundido.alpha = 1f;
        fundido.blocksRaycasts = true;
        titulo.anchoredPosition = posTitulo + Vector2.up * 120f;
        panelBotones.anchoredPosition = posPanel + Vector2.up * 220f;
        sombraHomer.anchoredPosition = posHomer + Vector2.left * 26f;
    }

    void Start()
    {
        StartCoroutine(Entrada());
    }

    private IEnumerator Entrada()
    {
        StartCoroutine(Animar.Fundir(fundido, 1f, 0f, 1.2f));
        yield return new WaitForSeconds(0.6f);

        StartCoroutine(Animar.Mover(titulo, titulo.anchoredPosition, posTitulo, 0.8f, Easing.OutBack));
        yield return new WaitForSeconds(0.6f);

        StartCoroutine(Animar.Mover(sombraHomer, sombraHomer.anchoredPosition, posHomer, 2f, Easing.OutCubic));
        yield return StartCoroutine(Animar.Mover(panelBotones, panelBotones.anchoredPosition, posPanel, 0.8f, Easing.OutBack));

        fundido.blocksRaycasts = false;
        introTerminada = true;
    }

    void Update()
    {
        if (!introTerminada || !controlarCadena) return;

        float angulo = Mathf.Sin(Time.time * 1.3f) * 1.2f;
        panelBotones.localEulerAngles = new Vector3(0f, 0f, angulo);
    }

    public IEnumerator EsconderCadena(float altura, float duracion)
    {
        controlarCadena = false;
        panelBotones.localEulerAngles = Vector3.zero;
        panelBotonesGrupo.blocksRaycasts = false;
        yield return StartCoroutine(Animar.Mover(panelBotones, posPanel, posPanel + Vector2.up * altura, duracion, Easing.InBack));
    }

    public IEnumerator MostrarCadena(float duracion)
    {
        yield return StartCoroutine(Animar.Mover(panelBotones, panelBotones.anchoredPosition, posPanel, duracion, Easing.OutBack));
        panelBotonesGrupo.blocksRaycasts = true;
        controlarCadena = true;
    }
}
