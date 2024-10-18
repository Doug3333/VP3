using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichFireCast : MonoBehaviour
{

    
    [SerializeField] GameObject LichFireBallPrefab;
    public float LichFireBallSpeed;

    //[SerializeField] float LichFireBallDamage;
    [SerializeField] float LichFireBallPerSec;
    
    float LichFireBallTime;
    public float destroyAfter;

    StateMachine stateMachine;
    GameObject TargetPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > LichFireBallTime)
        {
            if (GamesManager.Instance.IsState<PauseState>())
            {
                return;
            }
            LichFireBallTime = Time.time + LichFireBallPerSec;

            Vector2 bulletDirection = TargetPlayer.transform.position - (Vector3)transform.position;

            bulletDirection.Normalize();

            GameObject LichFireBall = Instantiate(LichFireBallPrefab, transform.position, Quaternion.identity);
            LichFireBall.transform.up = bulletDirection.normalized;
            
            StartCoroutine(DestroyLichFireBallAfterSeconds(destroyAfter, LichFireBall));

            Rigidbody2D Rig = LichFireBall.GetComponent<Rigidbody2D>();
            if (Rig)
            {
                Rig.velocity = LichFireBall.transform.up * LichFireBallSpeed;
            }

        }

    }

    IEnumerator DestroyLichFireBallAfterSeconds(float seconds, GameObject theLichFireBall)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(theLichFireBall);

    }
}

