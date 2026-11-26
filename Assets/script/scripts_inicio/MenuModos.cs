using System.Collections;
using UnityEngine;

public class MenuModos : MonoBehaviour
{
    [SerializeField] private MenuIntro menuIntro;
    [SerializeField] private MenuPrincipal menuPrincipal;
    [SerializeField] private RectTransform cadenaModos;
    [SerializeField] private CanvasGroup cadenaModosGrupo;

    private Vector2 posModos;
    private bool ocupado = false;

    void Awake()
    {
        posModos = cadenaModos.anchoredPosition;
        cadenaModos.gameObject.SetActive(false);
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

    public void ElegirArcade()
    {
        ModoJuego.Actual = ModoJuego.Modo.Arcade;
        menuPrincipal.CargarEscena("Arcade");
    }

    public void ElegirInfinito()
    {
        ModoJuego.Actual = ModoJuego.Modo.Infinito;
        menuPrincipal.CargarEscena("Infinito");
    }

    private IEnumerator RutinaAbrir()
    {
        ocupado = true;
        yield return StartCoroutine(menuIntro.EsconderCadena(220f, 0.45f));

        cadenaModos.gameObject.SetActive(true);
        cadenaModosGrupo.blocksRaycasts = false;
        yield return StartCoroutine(Animar.Mover(cadenaModos, posModos + Vector2.up * 220f, posModos, 0.8f, Easing.OutBack));
        cadenaModosGrupo.blocksRaycasts = true;
        ocupado = false;
    }

    private IEnumerator RutinaCerrar()
    {
        ocupado = true;
        cadenaModosGrupo.blocksRaycasts = false;
        yield return StartCoroutine(Animar.Mover(cadenaModos, posModos, posModos + Vector2.up * 220f, 0.45f, Easing.InBack));
        cadenaModos.gameObject.SetActive(false);

        yield return StartCoroutine(menuIntro.MostrarCadena(0.8f));
        ocupado = false;
    }
}
