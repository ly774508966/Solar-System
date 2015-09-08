using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    Dictionary<Planets, GameObject> planets = new Dictionary<Planets, GameObject>();

    public float planetScale = 1f;
    public float distanceScale = 1f;

    private OVRGUI gui;

    private GameObject currentPlanet;
    private GameObject player;

    public enum Planets {
        Sun, Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
    };

	// Use this for initialization
	void Start () {
        gui = new OVRGUI();
        player = GameObject.Find("OVRPlayerController");

        initPlanets();
        positionPlanets();
        currentPlanet = planets[Planets.Sun];
        movePlayerToPlanet(Planets.Sun);
	}

    void OnGUI()
    {
        //string text = "EARTH";
        //gui.StereoBox(.1f, .1f, .2f, .2f, ref text, Color.white);
        
    }

    void initPlanets()
    {
        planets.Add(Planets.Sun, GameObject.Find("SunPrefab"));
        planets.Add(Planets.Mercury, GameObject.Find("MercuryPrefab"));
        planets.Add(Planets.Venus, GameObject.Find("VenusPrefab"));
        planets.Add(Planets.Earth, GameObject.Find("EarthPrefab"));
        planets.Add(Planets.Mars, GameObject.Find("MarsPrefab"));
        planets.Add(Planets.Jupiter, GameObject.Find("JupiterPrefab"));
        planets.Add(Planets.Saturn, GameObject.Find("SaturnPrefab"));
        planets.Add(Planets.Uranus, GameObject.Find("UranusPrefab"));
        planets.Add(Planets.Neptune, GameObject.Find("NeptunePrefab"));

        scalePlanets();
    }

    void positionPlanets()
    {
        planets[Planets.Sun].transform.position = new Vector3(0, 0, 0);
        planets[Planets.Mercury].transform.position = calculateVector3(3.09f, 62.89f);
        planets[Planets.Venus].transform.position = calculateVector3(7.18f, 130.03f);
        planets[Planets.Earth].transform.position = calculateVector3(10.04f, 207.17f);
        planets[Planets.Mars].transform.position = calculateVector3(14.78f, 52.61f);
        planets[Planets.Jupiter].transform.position = calculateVector3(53.53f, 143.12f);
        planets[Planets.Saturn].transform.position = calculateVector3(99.73f, 240.55f);
        planets[Planets.Uranus].transform.position = calculateVector3(199.98f, 16.58f);
        planets[Planets.Neptune].transform.position = calculateVector3(299.66f, 337.57f);
    }

    void scalePlanets()
    {
        foreach(var item in planets) {
            if (item.Key != Planets.Sun)
            {
                item.Value.transform.localScale *= planetScale;
            }
        }
    }

    Vector3 calculateVector3(float distance, float angle)
    {
        return new Vector3(distanceScale * distance * Mathf.Cos(angle * Mathf.Deg2Rad), 0, distanceScale * distance * Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    void movePlayerToPlanet(Planets planet)
    {
        currentPlanet.SetActive(true);
        player.transform.position = planets[planet].transform.position;
        currentPlanet = planets[planet];
        currentPlanet.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
