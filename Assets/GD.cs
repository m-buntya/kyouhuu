using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GD : MonoBehaviour
{
    GameObject Gauge;
    // Start is called before the first frame update
    void Start()
    {
        this.Gauge = GameObject.Find("Gauge");
    }
    public void DecreaseHP()
    {
        this.Gauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
