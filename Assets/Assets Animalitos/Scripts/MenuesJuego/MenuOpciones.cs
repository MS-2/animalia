using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour {

	//AudioMixers para las Musicas y los Efectos.
	[Header("AudioMixers de la Musica y del Efectos.")]
	public AudioMixer MixerMusica;
	public AudioMixer MixerEfecto;

	//AudioSources en la escena.
	[Header("AudioSources en la escena.")]
	public AudioSource AS_Musica;
	public AudioSource AS_Efecto;
	bool Result, NoResult;

	//Sliders de Volumen Musica y Efecto.
	[Header("Sliders de Volumen Musica y Efecto.")]
	public Slider SliderVolMusica;
	public Slider SliderVolEfecto;

	//Funcion llamada por el SliderVolMusica para controlar el volumen del AudioMixer Musica.
	public void AjustarVolumenMusica(float VolumenMusica){
		MixerMusica.SetFloat("ParametroVolumenMusica", VolumenMusica);
	}

	//Funcion llamada por el SliderVolEfecto para controlar el volumen del AudioMixer Efecto.
	public void AjustarVolumenEfecto(float VolumenEfecto){
		MixerEfecto.SetFloat("ParametroVolumenEfecto", VolumenEfecto);
	}


	//Asignamos el valor de los parametros a los SliderVols
	public float AsigVolMusica(){
		float ActualVolMusica;
		Result = MixerMusica.GetFloat("ParametroVolumenMusica", out ActualVolMusica);
		return ActualVolMusica;
	}

	public float AsigVolEfecto(){
		float ActualVolEfecto;
		Result = MixerEfecto.GetFloat("ParametroVolumenEfecto", out ActualVolEfecto);
		return ActualVolEfecto;
	}

	
	//Use this for initialization.
	void Start(){
		SliderVolMusica.value = AsigVolMusica();
		SliderVolEfecto.value = AsigVolEfecto();
		Result = NoResult; NoResult = true; NoResult = Result;		
	}

}
