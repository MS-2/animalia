using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PosicionesAnimalesMemoTest : MonoBehaviour {

	//Lista similar a un arreglo, contiene posiciones predefinidas.
	[Header("Lista de Posiciones Predefinidas.")]
	public List<Vector3> PosPreAnimales;
	public List<Vector3> PosPreAnimalesRes;
	public int RandomInt;
	
	//Arreglo de Animales Conocidos.
	[Header("Arreglo de Animales Conocidos (RectTransform).")]
	public RectTransform[] RecTAnimalesConocidos;

	//Arreglo de Animales Incognitos.
	[Header("Arreglo de Animales Incognitos (RectTransform).")]
	public RectTransform[] RecTAnimalesIncognitos;
	

	
	public void AsigPosMemoTest(){
		for(int i = 0; i < RecTAnimalesConocidos.Length; i++){
			
			//Asignamos las posiciones predefinidas a los Animales Conocidos de manera aleatoria.
			RandomInt = Random.Range(0, PosPreAnimales.Count);
			RecTAnimalesConocidos[i].localPosition = PosPreAnimales[RandomInt]; 
			PosPreAnimales.RemoveAt(RandomInt);
			
			//Asignamos las posiciones de los botones de Animales Incognitos a las posiciones de Animales Conocidos.
			RecTAnimalesIncognitos[i].localPosition = RecTAnimalesConocidos[i].localPosition;			

		}
		PosPreAnimales.AddRange(PosPreAnimalesRes);
	}
	
	
	
	// Use this for initialization
	void Start () {
		AsigPosMemoTest();
	}
	
}
