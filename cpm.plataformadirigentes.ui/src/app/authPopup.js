import * as msal from "@azure/msal-browser";
import AuthConfig from "../app/authConfig";
import store from "../store/index";
import axios from "axios";
import messageConstants from "..//config/messageConstants";
import { config } from "@/config/auth";

// Create the main myMSALObj instance
// configuration parameters are located at authConfig.js
const myMSALObj = new msal.PublicClientApplication(AuthConfig.msalConfig);

let username = "";

function selectAccount() {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */
  debugger
  store.dispatch("user/setMensajeLogin", messageConstants.iniciarSesion);

  const currentAccounts = myMSALObj.getAllAccounts();
  let split_location = window.location.href.split("/");
  let last_location = split_location[split_location.length - 1];

  if (
    ((currentAccounts === null || currentAccounts.length <= 0) &&
      last_location !== "login") ||
    !store.getters["user/getAuthenticated"]
  ) {
    console.debug("No user found");
    window.location.href = "./#/login";
    return;
  } else if (
    currentAccounts.length >= 1 &&
    store.getters["user/getAuthenticated"] == true
  ) {
    username = currentAccounts[0].username;
    console.debug("Account logged in");
    if (last_location === "login") {
      window.location.href = "./#/";
      return;
    }
    getTokenPopup(AuthConfig.tokenRequest, username)
      .then((responseToken) => {
        store.dispatch("user/setToken", responseToken.accessToken);
        getPerfilesUsuario(responseToken);
        getPermisosUsuarios(responseToken);
      })
      .catch((error) => {
        store.dispatch("user/setMensajeLogin", messageConstants.errorRed);
        console.error("weh", error);
      });
  }
}

function handleResponse(response) {
  debugger

  /**
   * To see the full list of response object properties, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#response
   */
  store.dispatch("user/setLoading", true);
  store.dispatch("user/setMensajeLogin", messageConstants.validandoUsuario);
  if (response !== null) {
    username = response.account.username;
    console.debug("Login successful");
    getTokenPopup(AuthConfig.tokenRequest, username)
      .then((responsetoken) => {
        store.dispatch("user/setToken", responsetoken.accessToken);
        store.dispatch(
          "user/setMensajeLogin",
          messageConstants.validandoUsuario
        );
        getPerfilesUsuario(responsetoken);
        getPermisosUsuarios(responsetoken);
      })
      .catch((error) => {
        store.dispatch("user/setMensajeLogin", messageConstants.errorRed);
        window.location.href = "./#/login";
        console.error("weh", error);
      });
  } else {
    selectAccount();
  }
}

function getPerfilesUsuario(responseToken) {
  debugger


  username = responseToken.account.username;
  const parametros = JSON.stringify(username);

  axios
    .post(
      config.auth.server_url_api + "api/Usuarios/UsuarioPerfiles",
      parametros,
      {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + responseToken.accessToken,
        },
      }
    )
    .then((responseApi) => {
      if (responseApi.status == 200) {
        if (responseApi.data.length > 0) {
          if (responseApi.data[0] != null)
            store.dispatch("user/setPerfiles", responseApi.data);
          else {
            store.dispatch(
              "user/setMensajeLogin",
              messageConstants.sinPermisoUsuario
            );
            store.dispatch("user/setLoading", false);
            window.location.href = "./#/login";
          }
        } else {
          store.dispatch(
            "user/setMensajeLogin",
            messageConstants.usuarioNoLocalizado
          );
          store.dispatch("user/setLoading", false);
          window.location.href = "./#/login";
        }
      }
    })
    .catch((error) => {
      store.dispatch("user/setMensajeLogin", messageConstants.errorRed);
      store.dispatch("user/setLoading", false);
      store.dispatch("user/setAutehntication", false);
      console.log(error);
    });
}

function getPermisosUsuarios(responseToken) {
  debugger

  username = responseToken.account.username;
  const parametros = JSON.stringify(username);

  axios
    .post(
      config.auth.server_url_api +
        "api/PerfilCargos/ConsultarPermisobyCorreoAcceso",
      parametros,
      {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + responseToken.accessToken,
        },
      }
    )
    .then((responseApi) => {
      if (responseApi.status == 200) {
        if (responseApi.data.length > 0) {
          store.dispatch("user/setAutehntication", true);
          store.dispatch("permisos/setPermisos", responseApi.data);
          store.dispatch("user/setNombreDirigente", responseToken.account.name);
          store.dispatch(
            "user/setCorreoDirigente",
            responseToken.account.username
          );
          window.location.href = "./#/";
        } else {
          store.dispatch(
            "user/setMensajeLogin",
            messageConstants.usuarioNoLocalizado
          );
          store.dispatch("user/setLoading", false);
          window.location.href = "./#/login";
        }
      }
    })
    .catch((error) => {
      store.dispatch("user/setMensajeLogin", messageConstants.errorRed);
      store.dispatch("user/setLoading", false);
      store.dispatch("user/setAutehntication", false);
      window.location.href = "./#/login";
      console.log(error);
    });
}

function signIn(onOk = null) {
  /**
   * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
   */

  myMSALObj
    .handleRedirectPromise()
    .then((authResult) => {
      myMSALObj
        .loginPopup(AuthConfig.loginRequest)
        .then((resp) => {
          if (resp !== null && onOk !== null) {
            console.debug(authResult);
            username = resp.account.username;
            onOk(username);
          }
          handleResponse(resp);
        })
        .catch((error) => {
          console.error(error);
        });
    })
    .catch((err) => {
      // TODO: Handle errors
      console.log(err);
    });
}

async function signOut() {
  /**
   * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
   */
  store.dispatch("user/setAutehntication", false);
  const logoutRequest = {
    account: myMSALObj.getAccountByUsername(username),
  };

  await myMSALObj.logoutRedirect(logoutRequest);
}

function getTokenPopup(request, usuarioToken) {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */
  request.account = myMSALObj.getAccountByUsername(usuarioToken);

  return myMSALObj.acquireTokenSilent(request).catch((error) => {
    console.warn("silent token acquisition fails. acquiring token using popup");
    if (error instanceof msal.InteractionRequiredAuthError) {
      // fallback to interaction when silent call fails
      return myMSALObj
        .acquireTokenPopup(request)
        .then((tokenResponse) => {
          console.log(tokenResponse);
          return tokenResponse;
        })
        .catch((error) => {
          console.error(error);
        });
    } else {
      console.warn(error);
    }
  });
}

selectAccount();

export default {
  signIn: signIn,
  signOut: signOut,
  getTokenPopup: getTokenPopup,
};
