using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour

{
    
    [SerializeField] private float stamina;
    [SerializeField] private int maxStamina = 100;
    [SerializeField] private Slider staminaBar;
    private int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static StaminaBar instance;
    
    
    
    
    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >=0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("No Stamina");
            
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }

        regen = null;
    }

    public int staminaLeft()
    {
        return currentStamina;
    }

    
}
