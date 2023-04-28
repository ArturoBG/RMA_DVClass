using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.PlayerScripts
{

    public class HealthScript : MonoBehaviour
    {
        [Header("Health settings")]
        public float maxHealth = 100f;
        public float health;
        [SerializeField]
        private Slider healthBar;
        [SerializeField]
        private Image fillBar;
        [SerializeField]
        Color critical;
        [SerializeField]
        Color middle;
        [SerializeField]
        Color full;

        float mid;
        float crit;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            healthBar.GetComponent<Slider>();
            healthBar.maxValue = maxHealth;
            health = maxHealth;
            mid = maxHealth / 2;
            crit = maxHealth / 3;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                DamageTaken(15);
            }
            if(Input.GetKeyDown(KeyCode.J))
            {
                RegenHealth(30);
            }
        }

        public void DamageTaken(float damage)
        {          
            health -= damage;  
            if (health <= 0)
            {
                Debug.Log("Killed in action!");
                healthBar.value = 0f;
            }
            else if (health < mid && health > crit)
            {
                fillBar.color = middle;
                
            }
            else if (health < crit)
            {
                fillBar.color = critical;
                
            }
            else if (health > mid)
            {
                fillBar.color = full;
                
            }
            healthBar.value = health;
            Debug.Log($"Health remaining = {health}");
        }


        public void RegenHealth(float medpack)
        {
            health += medpack;

            if (health >= maxHealth)
            {
                health = maxHealth;
                healthBar.value = maxHealth;
                fillBar.color = full; 
            }
            else if (health > mid)
            {
                fillBar.color = middle;              
            }
             else if (health < crit)
            {
                fillBar.color = critical;              
            }
              healthBar.value = health;
        }
    }


}



