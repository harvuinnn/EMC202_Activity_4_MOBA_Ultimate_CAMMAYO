using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    public LineRenderer healLine;
    public Transform healerPos;
    public Transform characterPos;

    public float healAmount = 15f;
    public float healDuration = 5f;

    private bool isHealingActive = false;

    void Start()
    {
        healLine.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!isHealingActive)
            {
                StartCoroutine(ActivateHeal());
            }
            else
            {
                healLine.SetPosition(0, healerPos.position);
                healLine.SetPosition(1, characterPos.position);
            }
        }
    }

    private IEnumerator ActivateHeal()
    {
        isHealingActive = true;

        float timer = 0f;

        while (timer < healDuration)
        {
            healLine.SetPosition(0, healerPos.position);
            healLine.SetPosition(1, characterPos.position);

            timer += Time.deltaTime;
            yield return null;
        }

        healLine.SetPosition(0, healerPos.position);
        healLine.SetPosition(1, healerPos.position);
        isHealingActive = false;
    }
}
