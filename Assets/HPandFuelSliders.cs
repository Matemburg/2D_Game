using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPandFuelSliders : MonoBehaviour {

    public Text HPnumber;
    public Text Fuelnumber;
    public GameObject Starship;
    public Slider HPslider;
    public Slider FuelSlider;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int Fuel = Starship.GetComponent<Stats>().Fuel;
        int HP = Starship.GetComponent<Stats>().HP;
        int MaxHP = Starship.GetComponent<Stats>().MaxHP;
        int MaxFuel = Starship.GetComponent<Stats>().MaxFuel;

        HPnumber.text = HP.ToString() + "/" + MaxHP.ToString();
        Fuelnumber.text = Fuel.ToString() + "/" + MaxFuel.ToString();

        FuelSlider.maxValue = MaxFuel;
        FuelSlider.value = Fuel;
        HPslider.maxValue = MaxHP;
        HPslider.value = HP;


    }
}
