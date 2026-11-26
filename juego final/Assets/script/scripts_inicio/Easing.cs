using UnityEngine;

public static class Easing
{
    public static float OutCubic(float t)
    {
        return 1f - Mathf.Pow(1f - t, 3f);
    }

    public static float OutBack(float t)
    {
        float c = 1.7f;
        t = t - 1f;
        return 1f + (c + 1f) * t * t * t + c * t * t;
    }

    public static float InBack(float t)
    {
        float c = 1.7f;
        return (c + 1f) * t * t * t - c * t * t;
    }
}
