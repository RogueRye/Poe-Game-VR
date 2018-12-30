using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    // Use this for initialization
    void Start () {

        transform.localScale = Vector3.zero;
        StartCoroutine(ScaleWide());

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    IEnumerator ScaleWide()
    {
        while(transform.localScale.x < .98f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, (Vector3.one).Flat(), Time.deltaTime * speed);
            yield return null;
        }

        transform.localScale = Vector3.one.Flat();
        StartCoroutine(ScaleTall());
      
    }

    IEnumerator ScaleTall()
    {
        
        while(transform.localScale.y < .98f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * speed);
            yield return null;
        }

        transform.localScale = Vector3.one;


    }

}
