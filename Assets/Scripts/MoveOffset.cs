using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	// Variaveis
	private	Material		currentMaterial;	//Determina o material sendo usado
	public	float			speed;				//Velocidade que o material irá rotacionar
	private float			offset;				//Utilizado para calculo

	// Use this for initialization
	void Start () {
	
		// inicializando o material
		currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
		// calculo do offset
		// multiplica pelo deltaTime, pois se o frameRate da máquina estiver baixa,
		// iguala a sensação ao jogador
		offset += speed * Time.deltaTime;

		// seta o offset no currentMaterial
		// primeiro parametro:	[string] nome da textura,
		// 						aparentemente é obrigatório ser _MainTex
		// segundo parametro:	[vector2] x = offset, y = 0 (não movinta verticalmente)
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
