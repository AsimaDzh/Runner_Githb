using System;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)] public float speed = 0.2f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", Vector3.left * distance);
    }
}
