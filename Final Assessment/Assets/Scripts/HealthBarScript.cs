using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBarSlider;
    public Image fillImage;

    // Start is called before the first frame update
    void Awake()
    {
        //getting slider componet to the healthbar slider
        healthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //remove the fill layer from the slider when its at its minimum value
        if (healthBarSlider.value <= healthBarSlider.minValue)
        {
            fillImage.enabled = false;
        }

        //resetting the fill value of the image to show itself if the value is not at the minimum value
        if ((healthBarSlider.value > healthBarSlider.minValue) && (!fillImage.enabled))
        {
            fillImage.enabled = true;
        }

        //assigning the value to the slider component to show taking reference of the current health with the player max health from the GameManager script
        float fillValue = GameManagerScript.thisGameManagerScript.currentHealth / GameManagerScript.thisGameManagerScript.maxHealth;
        healthBarSlider.value = fillValue;
    }
}
