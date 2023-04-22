using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSceneManager : MonoBehaviour
{
    [Header("Login")]
    [SerializeField]
    private InputField m_LoginEmailInput            = null;
    [SerializeField]
    private InputField m_LoginPasswordInput         = null;

    [Header("Register")]
    [SerializeField]
    private GameObject m_registerUI            = null;
    [SerializeField]
    private GameObject m_loginUI               = null;
    [SerializeField]
    private Text       m_message               = null;
    [SerializeField]
    private InputField m_nameInput             = null;
    [SerializeField]
    private InputField m_emailInput            = null;
    [SerializeField]
    private InputField m_passwordInput         = null;
    [SerializeField]
    private InputField m_passwordConfirmInput  = null;
    private NetworkManager m_networkManager                     = null;

    private void Awake() {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }


    public void SubmitLogin() {
        if((m_LoginEmailInput.text == "") || (m_LoginPasswordInput.text == "") )
        {
            m_message.text = "Tienes campos vacios, por favor intentalo de nuevo.";
            return;
        }
        m_message.text = "Procesando...";
        m_networkManager.CheckUser(m_LoginEmailInput.text, m_LoginPasswordInput.text, delegate(Response response) {
            m_message.text = response.message;
        });
    }

    public void SubmitRegister() {
        if((m_nameInput.text == "") || (m_emailInput.text == "") || (m_passwordInput.text == "") || (m_passwordConfirmInput.text == ""))
        {
            m_message.text = "Tienes campos vacios, por favor intentalo de nuevo.";
            return;
        }
        if(m_passwordInput.text == m_passwordConfirmInput.text)
        {
            m_message.text = "Procesando...";
            m_networkManager.CreateUser(m_nameInput.text, m_emailInput.text, m_passwordInput.text, delegate(Response response) {
                m_message.text = response.message;
            });
            
        }
        else
        {
            m_message.text = "Las contraseñas no coinciden, por favor intentalo de nuevo.";
        }
    }

    public void ShowLog()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
        m_nameInput.text = "";
        m_emailInput.text = "";
        m_passwordInput.text = "";
        m_passwordConfirmInput.text = "";
    }
    
    public void ShowReg()
    {
        m_loginUI.SetActive(false);
        m_registerUI.SetActive(true);
        m_LoginEmailInput.text = "";
        m_LoginPasswordInput.text = "";
    }
}
