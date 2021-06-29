using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPandFuelSliders : MonoBehaviour {
    public Text TuretsLeft;
    public Text HPnumber;
    public Text Fuelnumber;
    public Stats StarshipStats;
    public Slider HPslider;
    public Slider FuelSlider;

    // Use this for initialization
    void Start () {
        int MaxHP = StarshipStats.MaxHP;
        float MaxFuel = StarshipStats.MaxFuel;
        HPslider.maxValue = MaxHP;
        FuelSlider.maxValue = MaxFuel;
    }
	
	// Update is called once per frame
	void Update () {

        float Fuel = StarshipStats.Fuel;
        int HP = StarshipStats.HP;
        int MaxHP = StarshipStats.MaxHP;
        float MaxFuel =StarshipStats.MaxFuel;

        HPnumber.text = HP.ToString() + "/" + MaxHP.ToString();
        Fuelnumber.text = Fuel.ToString() + "/" + MaxFuel.ToString();
        TuretsLeft.text = "Turets Left: " + GameObject.FindGameObjectsWithTag("Turet").Length.ToString();

        FuelSlider.maxValue = MaxFuel;
        FuelSlider.value = Fuel;
        
        HPslider.value = HP;


    }
}
