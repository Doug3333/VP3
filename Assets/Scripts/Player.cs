using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : Damageble
{

  
    [SerializeField] public float MoveSpeed;
    [SerializeField] float OrbitRadius;
    public float Orbitspeed;


    [SerializeField] GameObject SwordTransform;
    [SerializeField] Transform Orbiter;
    [SerializeField] Transform BowTransform;
    [SerializeField] GameObject BowGameObject;
    [SerializeField] GameObject AxeGameObject;
    [SerializeField] Transform AxeTransform;
    static StateMachine stateMachine;

    public HealthBar healthBar;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(Health, MaxHealth);
        Health = MaxHealth;
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

            body.velocity = Vector3.zero;
        }
    }

    //currentHealth = maxHealth;
    //healthBar.SetMaxHealth(maxHealth);


    //private int Health;

    /*
    [SerializeField] private TextMeshPro damageTaken;
    [SerializeField] public float damageDelay = 1f;
    [SerializeField] private float damageTimer;
    [SerializeField] private int MaxHealth;
    */

    float xAxis, yAxis = 0;
    //float footstepDelay = 0;
    //[SerializeField] GameObject PlayerFootPrints;


    public void UpdatePlayer()
    {
        OrbiterMovement();

        Movement();

        PointSword();

        healthBar.SetHealth((int)Health);
        healthBar.SetHealthText(Health, MaxHealth);

        /*if (Time.time > footstepDelay)
        {
            footstepDelay = Time.time + 1;
            GameObject footstepInstance = Instantiate(PlayerFootPrints, transform.position, Quaternion.identity);
            footstepInstance.transform.up = body.velocity.normalized;

        }*/

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.CompareTag("BrokenSword"))
        {
            Debug.Log("SwordUpGraded");
            if (SwordTransform.TryGetComponent(out WeaponSword FD))
            {
                FD.UpDamage(1);
                Destroy(collider.gameObject);

            }


        }

        if (collider.gameObject.CompareTag("BrokenBow"))
        {
            Debug.Log("BowUpGraded");
            if (BowGameObject.TryGetComponent(out WeaponBow DF))
            {
                DF.UpDamage(1);

                Destroy(collider.gameObject);

            }


        }


        if (collider.gameObject.CompareTag("BrokenAxe"))
        {
            Debug.Log("AxeUpGraded");
            if (AxeGameObject.TryGetComponent(out WeaponOrbitAxe FDE))
            {
                FDE.UpDamage(1);
                Orbitspeed++;
                Destroy(collider.gameObject);

            }


        }

        if (collider.gameObject.CompareTag("PickupAxe"))
        {
            WeaponOrbitAxe axe = collider.gameObject.GetComponent<WeaponOrbitAxe>();
            if (axe != null)
            {
                axe.pickup = true;
                axe.transform.parent = AxeTransform.transform;
                axe.transform.localPosition = Vector3.zero;
                //axe.PickupTrigger.enabled = false;
            }
        }

        if (collider.gameObject.CompareTag("PickupBow"))
        {
            WeaponBow bow = collider.gameObject.GetComponent<WeaponBow>();
            if (bow != null)
            {
                bow.pickup = true;
                bow.transform.parent = BowTransform;
                bow.transform.localPosition = Vector3.zero;
                bow.PickupTrigger.enabled = false;
            }
        }



        /*
        if (collider.gameObject.CompareTag("PickupXpOrb"))
        {
            XpOrbs = collider.gameObject.GetComponent<XpOrbs>();
            if (XpOrbs != null)
            {
                XpOrbs.pickup = true;
                XpOrbs.transform.parent = XpOrbsTransform;
                XpOrbs.transform.localPosition = Vector3.zero;
                
            }
        }
        */


        /*if (collision.gameObject.CompareTag("Upgrade"))
        {

        }
        */
    }








    void PointSword()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 swordDirection = mousePos - (Vector2)transform.position;

        SwordTransform.transform.up = swordDirection.normalized;

    }



    void Movement()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        Vector3 Velocity = Vector2.ClampMagnitude(new Vector2(xAxis, yAxis), 1);
        body.velocity = Velocity * (MoveSpeed);

    }

    
    public void SpeedUpgrade()
    {
        MoveSpeed += 0.2f;    //MovementSpeed Upgrade, needst ot be linked to Choice Buttons!
    }

    void OrbiterMovement()
    {
        Vector3 orbitPos = new Vector3(Mathf.Cos(Time.time * Orbitspeed), Mathf.Sin(Time.time * Orbitspeed), 0) * OrbitRadius;
        Orbiter.localPosition = orbitPos;
    }

    public override void Death()
    {

       
        //GamesManager.Instance.SwitchState<PauseState>();
        //Debug.Log("Player died");
    }

}