using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosAnimalesEncastre : MonoBehaviour {
	
	//Script Principal del Encastre e IndexG para los Arreglos.
    [Header("Script Principal Funciones Encastre.")]
	public List<MoverAnimal> MA_Script;

	//Lista similar a un arreglo, contiene posiciones predefinidas.
	[Header("Lista de Posiciones Predefinidas.")]
	public List<Vector3> PosAnimalesColor;
	public List<Vector3> PosAnimalesBlancos;
	public List<Vector3> PosAnimalesColorRes;
	public List<Vector3> PosAnimalesBlancosRes;	
	public int RandomInt;
	public int i;

	//Lista de Sprites de Animales Color-Blanco a seleccionar.
	[Header("Lista de Sprites Color-Blanco a seleccionar.")]
	public List<Sprite> AnimalesColor;
	public List<Sprite> AnimalesBlanco;
	public List<Sprite> AnimalesColorRes;
	public List<Sprite> AnimalesBlancoRes;
	public List<Image> AnimalesColorSel;
	public List<Image> AnimalesBlancoSel;
	
	//Arreglo Posiciones RectTransform de Animales Blancos y Color.
	[Header("Arreglo de Animales Blancos y Color (RectTransform).")]
	public List<RectTransform> RecTAnimalesColor;
	public List<RectTransform> RecTAnimalesBlancos;

	//Arreglos de AnimatorControllers.
	[Header("Arreglo de Animators Color-Blancos.")]
	public Animator[] AnimalesColorAnim;
	public Animator[] AnimalesBlancosAnim;
	
//*****************************************************************
//*************************** FUNCIONES ***************************
//*****************************************************************		
	
	public void AsignarAnimalesCBP(){
		//Escogemos de manera aleatoria 5 animales de los 41 posibles.
		for(i = 0; i < AnimalesColorSel.Count; i++){
			RandomInt = Random.Range(0, AnimalesColor.Count);
			AnimalesColorSel[i].sprite = AnimalesColor[RandomInt];
			AnimalesBlancoSel[i].sprite = AnimalesBlanco[RandomInt];
			AnimalesColor.RemoveAt(RandomInt);
			AnimalesBlanco.RemoveAt(RandomInt);
		}	
		
		//Limpiamos y volvemos a llenar todos los Sprites AnimalesColor y AnimalesBlancos. Evita que se repita un animal.
		AnimalesColor.Clear(); AnimalesBlanco.Clear();
		AnimalesColor.AddRange(AnimalesColorRes); 
		AnimalesBlanco.AddRange(AnimalesBlancoRes);

		//Asignamos las posiciones predefinidas a Animales Color.
		for(i = 0; i < RecTAnimalesColor.Count; i++){
			RandomInt = Random.Range(0, PosAnimalesColor.Count);
			RecTAnimalesColor[i].localPosition = PosAnimalesColor[RandomInt];
			PosAnimalesColor.RemoveAt(RandomInt);
		}

		//Asignamos las posiciones predefinidas a Animales Blancos.
		for(i = 0; i < RecTAnimalesBlancos.Count; i++){
			RandomInt = Random.Range(0, PosAnimalesBlancos.Count);
			RecTAnimalesBlancos[i].localPosition = PosAnimalesBlancos[RandomInt];
			PosAnimalesBlancos.RemoveAt(RandomInt);
		}

		//Reestablecemos las posiciones eliminadas de PosAnimalesColor y PosAnimalesBlancos.
		for(i = 0; i < PosAnimalesColorRes.Count; i++){
			PosAnimalesColor.Add(PosAnimalesColorRes[i]);
			PosAnimalesBlancos.Add(PosAnimalesBlancosRes[i]);
		}

		//Reestrablecemos los Animators de los Animales Color-Blanco.
		for(i = 0; i < AnimalesColorAnim.Length; i++){
			AnimalesColorAnim[i].SetBool("RemoverEncastrado", false);
			AnimalesBlancosAnim[i].SetBool("RemoverEncastrado", false);
		}

		//Asignacion de Posiciones Originales y Destino para los Animales. Requeridas por el Script MoverAnimal.
		for(i = 0; i < MA_Script.Count; i++){
			MA_Script[i].AsigPosAnimales();
		}
	}

//*****************************************************************	
}
