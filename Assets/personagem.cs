using UnityEngine;

public class personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade = 3f;
    private bool piso = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(movimentoHorizontal * velocidade * Time.deltaTime, 0,0);

        if (( Input.GetKeyDown(KeyCode.Space)  || Input.GetButtonDown ("Jump"))  ){
            if(piso){ 
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6.0f);
                piso = false;
            }


        }
    }

    void OnCollisionEnter2D(Collision2D collition) {
        if (collition.gameObject.CompareTag("Ground")){
            piso = true;
            Debug.Log("Colidiu com o piso");
        }

        if (collition.gameObject.CompareTag("Spike")){
            Destroy(gameObject);
        }

        if (collition.gameObject.CompareTag("bola de fogo")){
            Destroy(gameObject);
        }
    }
        
    }

