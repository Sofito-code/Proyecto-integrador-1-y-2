using UnityEngine;

public class SecureForm
{
    private WWWForm form = null;
    private const string CONNECTION_PASSWORD = "lxHOojxlag";
    private const string WIN_PASSWORD = "t9gRSZcWKx";

    public WWWForm secureForm { get { return form; } }

    public SecureForm(){
        form = new WWWForm();
        form.AddField("connectionPass", CONNECTION_PASSWORD);
        /* #if UNITY_STANDALONE_WIN */
            form.AddField("os", "WIN");
            form.AddField("platformPass", WIN_PASSWORD);
        /* #endif */
    }    
}
