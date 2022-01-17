using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] Vector2 moveSpeed = new Vector2(0, 1);

    Vector2 offset;
    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        material.mainTextureOffset += moveSpeed * Time.deltaTime;
    }
}
