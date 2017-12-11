using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameObject powerBlock;//passar o prefab do power block como parâmetro no inspector

	void OnTriggerEnter2D(Collider2D other){//esse código destrói a caixa e instancia o power block quando o jogador encosta na caixa
		if (other.transform.name == "Body"){
			Destroy (gameObject);
			Instantiate (powerBlock, transform.position, Quaternion.identity);
		}
	}
}
