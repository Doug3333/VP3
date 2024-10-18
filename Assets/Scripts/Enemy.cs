using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.VFX;
using TMPro;


public class Enemy : Damageble
{
    //public GameObject DamageNrs;
    [SerializeField] GameObject XpOrb;
    [SerializeField] GameObject BloodSplater;
    StateMachine stateMachine;
    [SerializeField] GameObject FootPrints;
    Vector2 oldVelocity;
    //[SerializeField] float MovementSpeed;

    [HideInInspector] public UnityEvent<Enemy> OnKilled;


    EnemyMovement myMovement;

    //[SerializeField] List<EnemyMovement> enemyMovement = new List<EnemyMovement>();


    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        myMovement = GetComponent<EnemyMovement>();
        if (stateMachine == null)
        {
            stateMachine = FindObjectOfType<StateMachine>();
        }
        stateMachine.stateEvent += OnStateChange;
    }

    private void OnStateChange(State aState)
    {

        if (aState.GetType() == typeof(PauseState))
        {
           // if (!rigidbody) return; //If rigidbody is missing we dont want to do anything

            //body.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    //public void UpdateEnemy(Vector3 aPlayerPos)
    //{
    //    if (!myMovement) return;
    //    transform.position += myMovement.Move(aPlayerPos);
    //}


    float footstepDelay = 0;

    public void UpdateEnemy(Vector3 aPlayerPos)
    {
        if (!body) return;
        if (!myMovement) return;
        body.velocity = myMovement.Move(aPlayerPos);


        if (Time.time > footstepDelay)
        {
            footstepDelay = Time.time + 1;
            GameObject footstepInstance = Instantiate(FootPrints, transform.position, Quaternion.identity);
            footstepInstance.transform.up = body.velocity.normalized;

        }




        //foreach (EnemyMovement e in enemyMovement)
        //{
        //    transform.position += e.Movement(aPlayerPos) * Time.deltaTime;
        //}

        //transform.position = Vector3.MoveTowards(transform.position, aPlayerPos, MovementSpeed * Time.deltaTime);
    }




    //public class EnemyMovement : MonoBehaviour




    //    public virtual Vector3 Movement(Vector3 aPlayerPos)
    //    {
    //      return Vector3.zero;
    //    }
    public override void Death()
    {
        OnKilled?.Invoke(this);

        base.Death();

        Instantiate(XpOrb, transform.position, Quaternion.identity);
        Instantiate(BloodSplater, transform.position, Quaternion.identity);


    }



}