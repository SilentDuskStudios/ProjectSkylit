using UnityEngine;
using UnityEngine.UI;

public class Beast : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public bool canAttack;

    private float attackCooldown;

    private float attackTimer;

    [SerializeField]
    private int maxHealth, damage;

    private int currentHealth;


    public MovementSpeedEnum movementSpeed;

    private Transform target;

    [SerializeField]
    private BeastHealthBar beastHealthBar;

    [SerializeField]
    public BeastTypeEnum beastType;

    [SerializeField]
    private int currencyValue;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        canAttack = false;
        attackTimer = 0f;
        attackCooldown = 1f;
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

        beastHealthBar.UpdateHealthBar(currentHealth, maxHealth);

    }

    private void Die() {

        WaveManager.waveManager.currentBeastCount--;

        WaveManager.waveManager.CheckNextWave();

        Currency.currency.Add(currencyValue);

        CanvasManager.canvasManager.UpdateCurrencyPanel(Currency.currency.GetCurrentCurrency());

        Destroy(this.gameObject);

    }

    #endregion //Methods

}