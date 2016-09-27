using UnityEngine;
using System.Collections;

public class MovePlayerCommand : ICommand {

	private GameObject _gameObject;

	private float _x;
	private float _z;

	private float _lastX;
	private float _lastZ;

	public MovePlayerCommand(GameObject gameObject, float x, float z){
		_gameObject = gameObject;
		_x = x;
		_z = z;
	}

	public void Execute ()
	{
		_lastX = _gameObject.transform.position.x;
		_lastZ = _gameObject.transform.position.z;

		iTween.MoveTo(_gameObject, new Vector3(_x, _gameObject.transform.position.y, _z), 1.0f);
	}

	public void Undo ()
	{
		iTween.MoveTo(_gameObject, new Vector3(_lastX, _gameObject.transform.position.y, _lastZ), 1.0f);
	}

}
