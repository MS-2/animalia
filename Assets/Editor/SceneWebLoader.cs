using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWebLoader {

	private string _assetUriPath;
	private string _scenaname;
	private WWW _wwwrequset;
	private AssetBundle container;
	private bool _descargando;

	public float Progreso
	{
		get{
			if (_descargando)
				return _wwwrequset.progress;
			else
				return 0f;
		}
	}
	public bool Listo
	{
		get{if (_wwwrequset.isDone) {
				return true;
			}
			else
				return false;
		}
	}
		
	public SceneWebLoader(string url)
	{
		_assetUriPath = url;
		_descargando = false;
		_scenaname = null;

	}
	public void IniciarDescarga (ThreadPriority tp)
	{
		_wwwrequset = WWW.LoadFromCacheOrDownload (_assetUriPath, 1);
		_descargando = true;
		_wwwrequset.threadPriority = tp;
	}
	public void ActivarScena ()
	{
		if (!string.IsNullOrEmpty (_wwwrequset.error)) {
			return;
		} else {
			container = _wwwrequset.assetBundle;
			string[] path = container.GetAllScenePaths ();
			_scenaname = System.IO.Path.GetFileNameWithoutExtension (path[0]);
			SceneManager.LoadScene (_scenaname);
		}
	}
	public IEnumerator Esperar ()
	{
		yield return _wwwrequset;
	}
}
