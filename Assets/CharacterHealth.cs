using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public HealScript healScript;
    public float healAmount = 10f;
    public TextMeshProUGUI healingText;

    private Coroutine healingCoroutine;

    void Start()
    {
        currentHealth = 10f;
        UpdateHealthText();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X) && healScript.healLine.gameObject.activeSelf)
        {
            if (healingCoroutine == null)
            {
                healingCoroutine = StartCoroutine(HealOverTime());
            }
        }
        else if (healingCoroutine != null && !healScript.healLine.gameObject.activeSelf)
        {
            StopCoroutine(healingCoroutine);
            healingCoroutine = null;
        }
    }

    private IEnumerator HealOverTime()
    {
        float timer = 0f;
        float healRate = healAmount / healScript.healDuration;

        while (timer < healScript.healDuration && healScript.healLine.gameObject.activeSelf)
        {
            currentHealth = Mathf.Min(currentHealth + healRate * Time.deltaTime, maxHealth);
            UpdateHealthText();

            timer += Time.deltaTime;
            yield return null;
        }

        healingCoroutine = null;
    }

    private void UpdateHealthText()
    {
        healingText.text = $"{currentHealth:F1}/{maxHealth}";
    }
}
