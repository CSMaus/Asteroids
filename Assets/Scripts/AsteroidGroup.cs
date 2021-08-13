using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGroup : MonoBehaviour
{
    [SerializeField]
    public string Pattern;

    [SerializeField]
    List<Sprite> sprites;

    public Sprite GetRandom()
    {
        var rnd = (int)Mathf.Floor(Random.value * sprites.Count);
        return sprites[rnd];
    }

}