using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
   public Slider HealthSlider;
   PlayerAttriibues playerhealth;
   
   void Start()
   {
    playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttriibues>();
   }
   void Update()
   {
        HealthSlider.value = playerhealth.Health;

   }
}
