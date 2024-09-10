using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuzyou : MonoBehaviour
{
    public GameObject kyabetu;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kyabetu_1());
    }
    IEnumerator kyabetu_1()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        while (true)
        {
            float y = Random.Range(-4.5f, 4.5f); //-4.5‚©‚ç4.5‚ÌŠÔ‚Åƒ‰ƒ“ƒ_ƒ€
            int direction = Random.Range(0, 2);//0‚©1‚©ƒ‰ƒ“ƒ_ƒ€
            if (direction == 0)
           
            {   //¶‚©‚çoŒ»
                kyabetu.transform.position = new Vector3(-3.0f, y, 0);
            }
            Instantiate(kyabetu);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
