using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEncastre : MonoBehaviour {

	//Script Principal del Encastre e IndexG para los Arreglos.
    [Header("Script Principal Funciones Encastre.")]
	public FuncionesEncastre FE_Script;
		
	//Variable String que debe tener el nombre del animal a encastrar y variable Int que identifica al Animal.
	[Header("Variable String e IndexG del Animal Correcto.")]
	public string AnimalRequerido;
	public int IndexG;


	//Detecta mediante una colision 2D si el animal tocado es el correcto.
	public void OnCollisionEnter2D(Collision2D Colision){
        if(Colision.gameObject.name == AnimalRequerido){
			FE_Script.AnimalesEncastrados[IndexG] = true;
		}
    }

	//Detecta mediante una colision 2D si se ha dejado de tocar el animal correcto.
	public void OnCollisionExit2D(Collision2D Colision){
		if(Colision.gameObject.name == AnimalRequerido){
			FE_Script.AnimalesEncastrados[IndexG] = false;
		}
	}

}
