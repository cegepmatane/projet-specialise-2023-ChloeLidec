using UnityEngine;
using UnityEngine.UI;

public class HoeMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject handle;
    public GameObject slider;
    private float sliderValue = 0;
    private int rotation = 1;

    public void Update()
    {
        if (sliderValue != slider.GetComponent<Slider>().value)
        {
            sliderValue = slider.GetComponent<Slider>().value;
            Hoe();
        }
        
    }

    public void Hoe()
    {
        rotation = rotation * -1;
        handle.transform.Rotate(0, 0, rotation * 40);
    }

}
