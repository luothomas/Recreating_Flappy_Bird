using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{//向後循環移動背景，製造向前飛的假象
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    // Start is called before the first frame update
    private void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update() 
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0);
    }
}
