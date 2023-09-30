using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image fillBar;

    [SerializeField]
    private int characterHealth; //value of this character, wont move

    [SerializeField]
    private int totalHealth; // dynamic health, this one moves

    [SerializeField]
    private Color green;
    [SerializeField]
    private Color yellow;
    [SerializeField]
    private Color red;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(25);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            HealUp(15);
        }
    }

    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;
        
        
        totalHealth -= damage;
        if (totalHealth < 0)
        {
            totalHealth = 0;
        }
        CheckColors();
    }

    public void HealUp(int value)
    {
        healthBar.value += value;
        totalHealth += value;
        if (totalHealth > characterHealth)
        {
            totalHealth = characterHealth;
        }
        CheckColors();
    }

    public void ResetHealth()
    {
        totalHealth = characterHealth;
        healthBar.value = characterHealth;
        fillBar.color = green;
    }

    private void CheckColors()
    {
        if (healthBar.value >= 75)
        {
            fillBar.color = green;
        }
        else if (healthBar.value >= 50 && healthBar.value <= 74)            
        {
            fillBar.color = yellow;
        }
        else if (healthBar.value > 0 && healthBar.value <= 49)
        {
            fillBar.color = red;
        }
    }
}
