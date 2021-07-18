using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Rob;

namespace Rob
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public float oldCurrentHealth;
        public float newCurrentHealth;

        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        
        public void SetHealth(float health)
        {
            newCurrentHealth = health;
            DOTween.To(Getter, Setter, newCurrentHealth, 2f);
            slider.value = health;
        }
        
        private float Getter()
        {
            return oldCurrentHealth;
        }

        private void Setter(float newValue)
        {
            oldCurrentHealth = newValue;

            GetComponent<Slider>().value = oldCurrentHealth;
        }
    }
}