using System;
using System.Collections;
using UnityEngine;

public static class Animar
{
    public static IEnumerator Mover(RectTransform rect, Vector2 desde, Vector2 hasta, float duracion, Func<float, float> curva)
    {
        float t = 0f;
        while (t < duracion)
        {
            t += Time.deltaTime;
            rect.anchoredPosition = Vector2.LerpUnclamped(desde, hasta, curva(t / duracion));
            yield return null;
        }
        rect.anchoredPosition = hasta;
    }

    public static IEnumerator Fundir(CanvasGroup grupo, float desde, float hasta, float duracion)
    {
        float t = 0f;
        while (t < duracion)
        {
            t += Time.deltaTime;
            grupo.alpha = Mathf.Lerp(desde, hasta, t / duracion);
            yield return null;
        }
        grupo.alpha = hasta;
    }
}
