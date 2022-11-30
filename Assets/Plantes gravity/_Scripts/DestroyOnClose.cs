using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClose : MonoBehaviour
{
    public float grow;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameObject.transform.parent.transform.localScale += new Vector3(grow, grow, grow);
        Debug.Log(gameObject.transform.parent.transform.localScale);
    }
}
