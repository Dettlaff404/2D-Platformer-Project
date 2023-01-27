using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemyHealthBarSlider;
    public Image enemyFillImage;

    // Start is called before the first frame update
    void Awake()
    {
        //getting slider componet to the healthbar slider
        enemyHealthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //remove the fill layer from the slider when its at its minimum value
        if (enemyHealthBarSlider.value <= enemyHealthBarSlider.minValue)
        {
            enemyFillImage.enabled = false;
        }

        //resetting the fill value of the image to show itself if the value is not at the minimum value
        if ((enemyHealthBarSlider.value > enemyHealthBarSlider.minValue) && (!enemyFillImage.enabled))
        {
            enemyFillImage.enabled = true;
        }

        //assigning the value to the slider component to show taking reference of the current health with the player max health from the GameManager script
        float fillValue = EnemyController.enemyControllerScript.enemyCurrentHealth / EnemyController.enemyControllerScript.enemyMaxHealth;
        enemyHealthBarSlider.value = fillValue;
    }
}
