using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private MenuIntro menuIntro;
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private CanvasGroup panelGrupo;
    [SerializeField] private RectTransform cartel;
    [SerializeField] private TMP_Text textoNumeroPagina;
    [SerializeField] private Button botonAnterior;
    [SerializeField] private Button botonSiguiente;
    [SerializeField] private GameObject[] paginas;

    private Vector2 posCartel;
    private int paginaActual = 0;
    private bool ocupado = false;

    void Awake()
    {
        posCartel = cartel.anchoredPosition;
        panelTutorial.SetActive(false);
    }

    public void Abrir()
    {
        if (ocupado || !menuIntro.IntroTerminada) return;
        StartCoroutine(RutinaAbrir());
    }

    public void Cerrar()
    {
        if (ocupado) return;
        StartCoroutine(RutinaCerrar());
    }

    public void Siguiente()
    {
        if (ocupado || paginaActual == paginas.Length - 1) return;
        StartCoroutine(CambiarPagina(paginaActual + 1, 1));
    }

    public void Anterior()
    {
        if (ocupado || paginaActual == 0) return;
        StartCoroutine(CambiarPagina(paginaActual - 1, -1));
    }

    private IEnumerator RutinaAbrir()
    {
        ocupado = true;
        yield return StartCoroutine(menuIntro.EsconderCadena(220f, 0.45f));

        MostrarPagina(0);
        panelTutorial.SetActive(true);
        panelGrupo.blocksRaycasts = false;
        yield return StartCoroutine(Animar.Mover(cartel, posCartel + Vector2.up * 220f, posCartel, 0.8f, Easing.OutBack));
        panelGrupo.blocksRaycasts = true;
        ocupado = false;
    }

    private IEnumerator RutinaCerrar()
    {
        ocupado = true;
        panelGrupo.blocksRaycasts = false;
        yield return StartCoroutine(Animar.Mover(cartel, posCartel, posCartel + Vector2.up * 220f, 0.45f, Easing.InBack));
        panelTutorial.SetActive(false);

        yield return StartCoroutine(menuIntro.MostrarCadena(0.8f));
        ocupado = false;
    }

    private IEnumerator CambiarPagina(int nueva, int lado)
    {
        ocupado = true;
        panelGrupo.blocksRaycasts = false;
        Vector2 fuera = posCartel + Vector2.right * 260f * lado;

        yield return StartCoroutine(Animar.Mover(cartel, posCartel, fuera, 0.35f, Easing.InBack));
        MostrarPagina(nueva);
        yield return StartCoroutine(Animar.Mover(cartel, fuera, posCartel, 0.45f, Easing.OutBack));

        panelGrupo.blocksRaycasts = true;
        ocupado = false;
    }

    private void MostrarPagina(int indice)
    {
        paginaActual = indice;
        for (int i = 0; i < paginas.Length; i++)
            paginas[i].SetActive(i == indice);

        textoNumeroPagina.text = (indice + 1) + " / " + paginas.Length;
        botonAnterior.interactable = indice > 0;
        botonSiguiente.interactable = indice < paginas.Length - 1;
    }
}
