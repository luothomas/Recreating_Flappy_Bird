using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public float gravity = -9.8f;
    public float jumpForce = 5f;
    public Sprite[] sprites;
    private int index;

    private SoundManager soundManager;

    private static Player instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();

        soundManager = SoundManager.Instance;
    }

    public static Player GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void Jump()
    {
        direction = Vector3.up * jumpForce;
        soundManager.PlaySound(soundManager.jumpSound);
    }

    private void AnimateSprite()
    {
        index++;
        if(index >= sprites.Length)
        {
            index = 0;
        }
        if(index < sprites.Length && index >= 0)
        {
            spriteRenderer.sprite = sprites[index];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            soundManager.PlaySound(soundManager.obstacleSound);
            GameManager.GetInstance().GameOver();
        }
        else if(other.gameObject.CompareTag("Scoring"))
        {
            soundManager.PlaySound(soundManager.scoringSound);
            GameManager.GetInstance().IncreaseScore();
        }
    }
}

