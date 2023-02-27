using System;
using System.Collections;
using System.Collections.Generic;
using FIMSpace;
using UnityEngine;
using UnityEngine.UI;

namespace Berkay
{ 
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Image healthFill;
        public static float health = 100;
        private static float startHealingTimer;


        private void Update()
        {
            ControlHealthUI();
            HealInTime();
        }

        public static void TakeDamage(float damage)
        {
            if (health <= 0)
            {
                health = 0;
                return;
            }

            startHealingTimer = 0;
            health -= damage;
        }

        public static void RespawnHealth()
        {
            health = 100;
        }

        private void HealInTime()
        {
            if (startHealingTimer <= 2)
            {
                startHealingTimer += Time.deltaTime;
            }
            
            if (startHealingTimer >= 2 && health < 100)
            {

                health ++;
            }
        }

        private void ControlHealthUI()
        {
            var h = Mathf.Lerp(.35f, 1f, health / 100);
            healthFill.fillAmount = h;
        }

    }
}