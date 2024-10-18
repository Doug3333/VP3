using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichFireBall : MonoBehaviour
{
    public int damageAmount = 1;
    static StateMachine stateMachine;
    private Rigidbody2D rb;
    Vector2 oldVelocity;

    private void Start()
    {
        if (stateMachine == null)
        {
            stateMachine = FindObjectOfType<StateMachine>();
        }
        stateMachine.stateEvent += OnStateChange;

        rb = this.GetComponent<Rigidbody2D>();
    }

    public void OnStateChange(State currentState)
    {
        if (stateMachine.IsState<PlayingState>())
        {
            if (!rb) return; //If rigidbody is missing we dont want to do anything
            rb.velocity = oldVelocity;
        }
        else if (stateMachine.IsState<PauseState>())
        {
            if (!rb) return;//If rigidbody is missing we dont want to do anything
            oldVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out Player e))
            {
                e.TakeDamage(damageAmount);
            }

        }
        if (collision.CompareTag("StaticGameObject"))
        {
            Destroy(gameObject);
        }
    }

}
