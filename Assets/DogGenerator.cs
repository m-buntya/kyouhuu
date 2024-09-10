using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject dog01;
    public GameObject kyabetu_1;
    public GameObject sinbunsi;
    float span = 2.2f;
    float delta = 0;
    int ratio0 = 4;
    int ratio1 = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta>this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 12);
            if(dice <=this.ratio0)
            {
                item = Instantiate(dog01);
            }
            else if(dice>=this.ratio1)
            {
                item = Instantiate(kyabetu_1);
            }
            else
            {
                item = Instantiate(sinbunsi);
            }
            float y = Random.Range(-4, 3);
            item.transform.position=new Vector3(-11,y,0);
        }
    }
}
