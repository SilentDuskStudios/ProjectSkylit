using UnityEngine;

public class Beast : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    public bool canAttack;

    private float attackCooldown;
    private float attackTimer;

    [SerializeField]
    private int damage, maxHealth, currentHealth;


    private Transform target;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        canAttack = false;
        attackCooldown = 2f;
        attackTimer = 0f;
        damage = 1;

        target = this.gameObject.GetComponent<BeastNavigator>().target;

        currentHealth = maxHealth;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if((canAttack) && (attackTimer > attackCooldown))
        {
            attackTimer = 0f;

            Attack();
        }
        //TODO: update target too, is that even possible?
    }

    private void Attack()
    {
        target.gameObject.GetComponent<Barricade>().TakeDamage(damage);

    }

    public void TakeDamage(int _damage) {

        currentHealth -= _damage;
        if (currentHealth < 1)
            Die();
    }

    private void Die() {

        Destroy(gameObject);

    }



    #endregion //Methods
}