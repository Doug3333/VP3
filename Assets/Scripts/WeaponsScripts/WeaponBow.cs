using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] public float ArrowSpeed;
    
    //[SerializeField] float ArrowDamage;
    [SerializeField] float arrowPerSec;
    public BoxCollider2D PickupTrigger;
    float ArrowTime;
    public bool pickup;
    StateMachine stateMachine;
    [SerializeField] public float DamageIncrease;
    
    [SerializeField] float arrowLifeTime;


    private void Start()
    {
        stateMachine = FindObjectOfType<StateMachine>();
    }

    public void UpDamage(float DFI)
    {
        DamageIncrease += DFI;
        ArrowSpeed += (DFI);  
        arrowPerSec += -(DFI-0.905f);
        Debug.Log("speed increase: " + -(DFI - 0.95f));
        

    }

    void Update()
    {
        
                                                                               //  Move to UppgradeState??
        if (pickup)
        {
            Vector3 bowPositon = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 BowDirection = mousePos - (Vector2)transform.position;

            transform.up = BowDirection.normalized;
                                                                                    // Moved to Damageble??
            if (Time.time > ArrowTime && stateMachine.IsState<PlayingState>() == true)
            {

                ArrowTime = Time.time + arrowPerSec;

                Vector2 bulletDirection = mousePos - (Vector2)transform.position;

                bulletDirection.Normalize();

                GameObject Arrow = Instantiate(ArrowPrefab, bowPositon, Quaternion.identity);
                Arrow.transform.up = bulletDirection.normalized;

                StartCoroutine(DestroyArrowAfterSeconds(arrowLifeTime, Arrow));

                if (Arrow.TryGetComponent(out ArrowHead ar))
                {
                    Debug.Log("Fail Damage Incresses" +DamageIncrease);
                    ar.UpDamage(DamageIncrease);
                }
                //Debug.Log(Arrow.transform.position);
                Arrow.GetComponent<Rigidbody2D>().velocity = Arrow.transform.up * ArrowSpeed;


            }
            

        }
     
    }
    IEnumerator DestroyArrowAfterSeconds(float seconds, GameObject theArrow)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(theArrow);

    }
}
