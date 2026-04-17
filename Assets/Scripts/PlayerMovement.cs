using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    AudioSource audio;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio  = GetComponent<AudioSource>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameController.Init();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FixedUpdate()
    {
        if (GameController.gameOver) return;
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
        rb.MovePosition(rb.position +  movement.normalized * speed * Time.fixedDeltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
            {
                audio.Play();
                GameController.Collect();
                Destroy(other.gameObject);
            } 
    }

}
