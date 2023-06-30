using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public float gravity = -9.8f;
    public float jumpForce = 5f;
    public Sprite[] sprites;
    private int index;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() 
    {//Reset the bird's position
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        //call Animatesprite per 0.15 sec
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up * jumpForce;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;//since gravity was an acceleration, square the time
    }
    private void AnimateSprite()
    {
        index++;
        if(index >= sprites.Length)
        {
            index = 0;
        }
        if (index < sprites.Length && index >= 0) {
            spriteRenderer.sprite = sprites[index];
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
    
}
