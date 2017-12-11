using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour {

	public Rigidbody2D rb;//passar o power block como parâmetro no inspector
	public Collider2D cd;//passar o power block como parâmetro no inspector
	public Power power;
	private float timer;
	private float initialTime;
	private bool moving;
	private Transform target;

	void Start(){
		transform.position = new Vector3(transform.position.x, transform.position.y, -1);
		power = (Power)Random.Range (1, 3);//isso faz com que o power block armazene um poder especial aleatório entre 2 e 3
		rb.AddForce (new Vector2 (Random.Range (-500, 500), Random.Range (-500, 500)));//isso faz com que o power block "salte" para uma direção aleatória quando for instanciado
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		//initialTime = Time.time;
		timer = 5;
	}

	void Update(){
		while (timer >= 0 && timer <= 4) {
			while (Vector2.Distance (target.position, transform.position) <= 5)
				rb.AddForce (new Vector2(Mathf.Sign(transform.position.x-target.position.x), Mathf.Sign(transform.position.y-target.position.y)));				
			timer -= Time.deltaTime;
		}
		if (timer <= 0)
			Destroy (gameObject);
		timer -= Time.deltaTime;
	}

}
