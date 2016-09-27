using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

	private Camera _camera;
	private ObjectSelector _objectSelector;

	private Stack<ICommand> commands;

	void Awake(){
		commands = new Stack<ICommand> ();
	}

	// Use this for initialization
	void Start () {
		_camera = Camera.main;
		_objectSelector = _camera.gameObject.GetComponent<ObjectSelector> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
			Ray ray = _camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "Ground") {
					if (_objectSelector.currentSelectedGameObject != null) {
						MovePlayerCommand command = new MovePlayerCommand (_objectSelector.currentSelectedGameObject, hit.point.x, hit.point.z);
						command.Execute ();

						commands.Push (command);
					}
				}
			}
		}

		//Undo Command
		if (Input.GetKeyUp (KeyCode.LeftArrow) && commands.Count > 0) {
			commands.Pop().Undo();
		}

	}
}
