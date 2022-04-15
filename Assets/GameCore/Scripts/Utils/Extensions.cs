using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static Transform[] Children(this Transform transform)
    {
        var res = new Transform[transform.childCount];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = transform.GetChild(i);
        }
        return res;
    }

    public static T Random<T>(this T[] array)
    {
        if (array.Length == 0)
        {
            return default(T);
        }

        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T Random<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            return default(T);
        }

        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static T Random<T>(this IEnumerable<T> ienumerable)
    {
        if (ienumerable.Count() == 0)
        {
            return default(T);
        }
        return ienumerable.ToList().Random();
    }

    public static void Map<T>(this IEnumerable<T> collection, System.Action<T> action)
    {
        if (collection == null)
        {
            return;
        }

        foreach (var item in collection)
        {
            action(item);
        }
    }
}
