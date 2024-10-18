using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateSpawner : MonoBehaviour
{
    public EnemyManager EnemyManager { get; set; }
    public BoxCollider2D PickupTrigger;


    private void Awake()
    {
        EnemyManager = FindObjectOfType<EnemyManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemies Have Incresased");

            EnemyManager.UpdateEnemySpawnDelay(+1.5f);
            Destroy(this.gameObject);
            
        }

        //public LogicScript logic;

        // Start is called before the first frame update
        //void Start()
        /* {
             //logic = GameObject.FindGameObjectsWithTag("Logic").GetComponent<LogicScript>();

         }

         // Update is called once per frame
         //void Update()
         {

             public void OnTriggerExit2D(Collider2D collision)
             {
                 if (collision.gameObject.Player)
                 {
                     logic.addScore();
                 }


             }

         }
      */

     } 
    
    
}

