using UnityEngine;

public class LoggerTester : MonoBehaviour {
    public string Message = "Hello World!";

    public void DoLog()
    {
        Debug.Log(Message);
    }
    public void DoLog(CharacterController2D character)
    {
        Debug.Log(Message + character.gameObject.name);
    }
}