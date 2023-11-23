using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int PlayerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] GameObject[] ballPositions;

    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;

    [SerializeField] private float xInput;
    [SerializeField] private float forceBall = 10f;
    [SerializeField] private GameObject camera;
    void Start()
    {
        instance = this;

        camera = Camera.main.gameObject;

        //set ball on table
        SetBalls(BallColors.White, 0);
        SetBalls(BallColors.Red, 1);
        SetBalls(BallColors.Yellow, 2) ;
        SetBalls(BallColors.Green, 3) ;
        SetBalls(BallColors.Brown, 4) ;
        SetBalls(BallColors.Blue, 5) ;
        SetBalls(BallColors.Pink, 6) ;
        SetBalls(BallColors.Black, 7) ;
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
    }
    void SetBalls(BallColors color, int pos)
    {
        GameObject ball = Instantiate(ballPrefab, ballPositions[pos].transform.position, Quaternion.identity);
        Ball scriptBall = ball.GetComponent<Ball>();
        scriptBall.SetColorAndPoint(color);
    }

    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
    }

    void ShootBall()
    {
        Rigidbody rigidbody = cueBall.GetComponent<Rigidbody>();
        rigidbody.AddRelativeForce(Vector3.forward*forceBall,ForceMode.Impulse);
        ballLine.SetActive(false);
    }
    
}