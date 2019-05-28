using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPandFuelSliders : MonoBehaviour {
    public Text TuretsLeft;
    public Text HPnumber;
    public Text Fuelnumber;
    public GameObject Starship;
    public Slider HPslider;
    public Slider FuelSlider;

    // Use this for initialization
    void Start () {
        int MaxHP = Starship.GetComponent<Stats>().MaxHP;
        float MaxFuel = Starship.GetComponent<Stats>().MaxFuel;
        HPslider.maxValue = MaxHP;
        FuelSlider.maxValue = MaxFuel;
    }
	
	// Update is called once per frame
	void Update () {

        float Fuel = Starship.GetComponent<Stats>().Fuel;
        int HP = Starship.GetComponent<Stats>().HP;
        int MaxHP = Starship.GetComponent<Stats>().MaxHP;
        float MaxFuel =Starship.GetComponent<Stats>().MaxFuel;

        HPnumber.text = HP.ToString() + "/" + MaxHP.ToString();
        Fuelnumber.text = Fuel.ToString() + "/" + MaxFuel.ToString();
        TuretsLeft.text = "Turets Left: " + GameObject.FindGameObjectsWithTag("Turet").Length.ToString();

        FuelSlider.maxValue = MaxFuel;
        FuelSlider.value = Fuel;
        
        HPslider.value = HP;


    }
}
