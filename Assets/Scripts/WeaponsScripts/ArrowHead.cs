using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{
    public float damageAmount = 2;
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
        
        rb = GetComponent<Rigidbody2D>();

    }

   
    public void OnStateChange(State currentState)
    {
        if (stateMachine.IsState<PlayingState>())
        {
            if (!rb) return;
            rb.velocity = oldVelocity;
        }
        else if (stateMachine.IsState<PauseState>())
        {
            if (!rb) return;
            oldVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out Enemy e))
            {
                e.EnemyTakeDamage(damageAmount);
                Destroy(gameObject);
            }

        }
        if (collision.CompareTag("StaticGameObject"))
        {
            Destroy(gameObject);
        }

    }

    public void UpDamage(float DFI)
    {

        damageAmount += DFI;

    }

}
