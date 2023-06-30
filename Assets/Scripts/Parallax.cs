using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{//�V��`�����ʭI���A�s�y�V�e�������H
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
