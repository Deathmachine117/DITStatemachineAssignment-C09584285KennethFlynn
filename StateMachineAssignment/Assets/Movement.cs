using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour{

	float horiz, vert;
	public float moveSpeed;

	void Start(){

	}

	void Update()
		{
				float horiz = Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime;
				transform.Translate(transform.right * horiz);

				float vert = Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime;
				transform.Translate(transform.up * vert);
		}
	}
