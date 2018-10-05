using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShip : MonoBehaviour
{
    public SpriteRenderer rend;
    public Transform other;
    public Color ColorA;
    public Color ColorD;

    [Range (-720, 720)]
    public float rotationSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, - rotationSpeed * Time.deltaTime);
        }
    }
}
