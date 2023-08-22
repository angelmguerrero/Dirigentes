//LOCAL
const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
const clientId = "4fe0318b-3a33-4333-bc60-bdf165a17a69";
const clienteApiId = "05cbfccc-0e70-4c04-940d-fa112ab25105";
const redirectUri = "http://localhost:8080/";
const server_url_api = "http://localhost:1717/";

//DEV
// const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
// const clientId = "4fe0318b-3a33-4333-bc60-bdf165a17a69";
// const clienteApiId = "05cbfccc-0e70-4c04-940d-fa112ab25105";
// const redirectUri = "https://10.99.9.25/CPMPlataformadirigentes/login";
// const server_url_api = "https://10.99.9.25/CPMPDirigentesWebApi/";

////QA
// const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
// const clientId = "5cb43e2c-474b-4de0-be31-c377365543d2";
// const clienteApiId = "7e6bf3ee-e6fc-45b9-860f-55c56b4b7ed7";
// const redirectUri = "https://10.99.9.25/CPMPlataformadirigentesqa/login";
// const server_url_api = "https://10.99.9.25/CPMPlataformadirigentesqa/";
////const redirectUri = "http://localhost:8080/";
//const server_url_api = "http://localhost:8080/";

//PRD
//const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
//const clientId = "c5ed2d48-0b73-4e53-ab49-559f268006ab";
//const clienteApiId = "94df8a2a-5d2f-4375-88ad-31d413da67a1";
//const redirectUri = "https://10.99.9.25/CPMPlataformadirigentesQA/login";
//const server_url_api = "https://10.99.9.25/CPMPlataformadirigentesQA/";

//DMZ
// const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
// const clientId = "4fe0318b-3a33-4333-bc60-bdf165a17a69";
// const clienteApiId = "05cbfccc-0e70-4c04-940d-fa112ab25105";
// const redirectUri = "https://10.90.0.46/CPMPlataformadirigentes";
// const server_url_api = "https://10.99.9.25/CPMPDirigentesWebApi/";

export const config = {
  auth: {
    clientId,
    tenantId,
    redirectUri,
    postLogoutRedirectUri: redirectUri,
    server_url_api,
    clienteApiId,
  },
};
