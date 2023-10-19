using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer renderer;
    void Start()
    {
        renderer= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var color = renderer.color;
        color.a -= Time.deltaTime;

        renderer.color = color;
    }
}
