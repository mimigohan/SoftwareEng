using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] AudioClip[] ballSounds;

    //state
    
    Vector2 paddle2BallVector;
    bool shotBall = false;

    //Ccched component references

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        RespawnOnPaddle();
        paddle2BallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!shotBall)
        {
            LockBall2Paddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
            shotBall = true;
        }
    }

    private void LockBall2Paddle()
    {
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, -0.5f);
        transform.position = paddlePos + (Vector3) paddle2BallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        Vector2 velocityTweak = new Vector2(
                                            Random.Range(0f, randomFactor),
                                            Random.Range(0f, randomFactor));

        if(shotBall)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
        
    }

    private void RespawnOnPaddle(){
        shotBall = false;
        transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y + 0.4f, -0.5f);
    }

    public void Reset(){
        RespawnOnPaddle();
    }
}
