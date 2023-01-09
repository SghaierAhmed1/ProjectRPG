using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private string authent = "http://127.0.0.1:13756/account";
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TMP_InputField Message;
    [SerializeField] private TMP_InputField SignUser;
    [SerializeField] private TMP_InputField SignPass;
    public GameObject pop;
    public GameObject MainLogin;
    public GameObject MainSignUp;
    public GameObject cancel;
    public GameObject complete;
    public GameObject MainMenu;

    public void OnClickPlay()
    {
      SceneManager.LoadScene(0);
    }
    public void OnSignForum()
    {
      MainSignUp.SetActive(false);
      complete.SetActive(true);
      StartCoroutine(TrySignup());
    }
    public void OnMainSignUpClick()
    {
      MainLogin.SetActive(false);
      MainSignUp.SetActive(true);
    }

    public void OnBackClick ()
    {
      complete.SetActive(false);
      MainSignUp.SetActive(false);
      MainLogin.SetActive(true);
    }

    public void OnCancelClick ()
    {
      cancel.SetActive(false);
      pop.SetActive(false);
      MainMenu.SetActive(false);
      MainLogin.SetActive(true);
    }
    public void OnLoginClick()
    {
      complete.SetActive(false);
      MainLogin.SetActive(false);
      StartCoroutine(TryLogin());
    }

    private IEnumerator TryLogin()
    {
      string username = usernameInputField.text;
      string password = passwordInputField.text;
      Message.text = "Connecting ...";
      pop.SetActive(true);
      UnityWebRequest request =  UnityWebRequest.Get($"{authent}?rUsername={username}&rPassword={password}");
      var handler = request.SendWebRequest();
      float startTime = 0.0f;
      while(!handler.isDone)
      {
        startTime += Time.deltaTime;
        if (startTime > 10.0f)
        {
          break;
        }
        yield return null;

      }
      if (request.isNetworkError || request.isHttpError)
      {
        Debug.Log("Unable to connect to server");
        Message.text = ("Connection Lost");
        cancel.SetActive(true);
      }

      else
      {
        Debug.Log(request.downloadHandler.text);
          if (request.downloadHandler.text == "Invalid Credentials")
          {
            StartCoroutine (cred());

          }
          else
          {
            StartCoroutine ("Success");
          }
      }

      yield return null;
    }

    IEnumerator cred ()
    {
      yield return new WaitForSeconds (2f);
      Message.text = "Invalid Credentials";
      cancel.SetActive(true);

    }

    IEnumerator Success ()
    {
      yield return new WaitForSeconds (2f);
      Message.text = "Authentification ..." ;
      yield return new WaitForSeconds (2f);
      Message.text = "Success!";
      yield return new WaitForSeconds (1f);
      pop.SetActive(false);
      MainMenu.SetActive(true);
    }

    IEnumerator TrySignup()
    {
      string username = SignUser.text;
      string password = SignPass.text;
      UnityWebRequest request =  UnityWebRequest.Get($"{authent}?rUsername={username}&rPassword={password}");
      var handler = request.SendWebRequest();
      float startTime = 0.0f;
      while(!handler.isDone)
      {
        startTime += Time.deltaTime;
        if (startTime > 10.0f)
        {
          break;
        }
        yield return null;

      }
      if (request.isNetworkError || request.isHttpError)
      {
        Debug.Log("Unable to connect to server");
      }

      else
      {
        Debug.Log(request.downloadHandler.text);
      }

      yield return null;
    }



}
