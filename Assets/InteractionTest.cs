using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour {

    [SerializeField]
    Transform handPos;



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("book"))
        {
            if (Input.GetMouseButton(0))
            {
                other.transform.position = handPos.position;
                other.transform.rotation = handPos.rotation;
            }

        }
    }


}
