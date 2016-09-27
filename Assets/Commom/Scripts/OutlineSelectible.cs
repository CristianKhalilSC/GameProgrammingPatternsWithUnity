using UnityEngine;
using System.Collections;

public class OutlineSelectible : MonoBehaviour, ISelectible {

	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	//void Update () {}

	public void OnSelected ()
	{
		_renderer.material.SetFloat("_Outline", .01f);
	}

	public void OnDeselected ()
	{
		_renderer.material.SetFloat("_Outline", 0f);
	}

}
