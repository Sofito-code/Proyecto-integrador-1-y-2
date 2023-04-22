using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string name, string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(name,email,pass,response));
    }

    private IEnumerator CO_CreateUser(string name, string email, string pass, Action<Response> response)
    {
        SecureForm form = new SecureForm();
        form.secureForm.AddField("userName", name);
        form.secureForm.AddField("userEmail", email);
        form.secureForm.AddField("userPass", pass);        
        UnityWebRequest w =  UnityWebRequest.Post("http://localhost/GameLC/createUser.php", form.secureForm);
        yield return w.SendWebRequest();
        response(JsonUtility.FromJson<Response>(w.downloadHandler.text));
    }

    public void CheckUser(string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CheckUser(email,pass,response));
    }

    private IEnumerator CO_CheckUser(string email, string pass, Action<Response> response)
    {
        SecureForm form = new SecureForm();
        form.secureForm.AddField("userEmail", email);
        form.secureForm.AddField("userPass", pass);        
        UnityWebRequest w =  UnityWebRequest.Post("http://localhost/GameLC/checkUser.php", form.secureForm);
        yield return w.SendWebRequest();
        response(JsonUtility.FromJson<Response>(w.downloadHandler.text));
    }
}

[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}
