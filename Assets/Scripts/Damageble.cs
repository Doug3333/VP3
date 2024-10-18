using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Damageble : MonoBehaviour
{
    [SerializeField] public float MaxHealth;
    public float Health;
    protected Rigidbody2D body;
   

    //[SerializeField] public TextMeshProUGUI DamageNrs;
    [SerializeField] public TextMeshPro DamageIndicator;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float someDamage)
    {
        Health -= someDamage;
        if (Health <= 0) Death();
        TextMeshPro damageObject = Instantiate(DamageIndicator, transform.position, Quaternion.identity, null);
        DamageIndicator.color = Color.red;
        DamageIndicator.text = "- " + someDamage.ToString();
        Destroy(damageObject.gameObject, 0.3f);
        //StartCoroutine(showIndicator(0.3f, someDamage)); 
    }

    public void EnemyTakeDamage(float someDamage)
    {
        Health -= someDamage;
        if (Health <= 0) Death();

        //StartCoroutine(showEnemyIndicator(0.3f, someDamage));
        TextMeshPro damageObject = Instantiate(DamageIndicator, transform.position, Quaternion.identity, null);
        DamageIndicator.text = "- " + someDamage.ToString();
        Destroy(damageObject.gameObject, 0.3f);
    }

    public virtual void Death()
    {
        Destroy(gameObject);

    }

    public void IncresseMaxHealth()
    {
        MaxHealth += 2;
        Health += 2;   //MaxHealthz Upgrade, needst ot be linked to Choice Buttons!

    }

    /*IEnumerator showIndicator(float amount, float num)
    {
        DamageNrs.text = "- " + num.ToString();
        DamageNrs.color = Color.red;
        yield return new WaitForSeconds(amount);
        DamageNrs.text = "";
        DamageNrs.color = Color.white;
    }
    IEnumerator showEnemyIndicator(float amount, float num)
    {
        DamageNrs.text = "- " + num.ToString();
        yield return new WaitForSeconds(amount);
        DamageNrs.text = "";
    }*/
    public void SetVelToCero()
    {
        body.velocity = Vector3.zero;
        //Debug.Log(this.gameObject.name);
    }
}
