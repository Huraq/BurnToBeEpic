using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destroying");
    }

    IEnumerator Destroying()
	{
		yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
	}
}
