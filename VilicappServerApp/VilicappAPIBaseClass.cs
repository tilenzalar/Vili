using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VilicappAPI;
using VilicappServerApp.Services;

namespace VilicappServerApp
{
    public class VilicappAPIBaseClass
    {
        private ISessionStorageService _sessionStorageService = null;

        //public VilicappAPIBaseClass(ISessionStorageService sessionStorageService)
        //{
        //    _sessionStorageService = sessionStorageService;
        //}

        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();

            await _appState.GetFromLS();
            var user = _appState.Get(x => x.User);
            

            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRaYWxhciIsIm5iZiI6MTYyMzA5NDY3NSwiZXhwIjoxNjI1Njg2Njc1LCJpYXQiOjE2MjMwOTQ2NzV9.b6tjBdkTYh76FDYcDtWsaIZdmtzf3ht8i42pGGVkbms";
            //if (!string.IsNullOrEmpty(token))
            //{
            //    // SET THE BEARER AUTH TOKEN
            //    msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("JWT", token);
                
            //}
            return await Task.FromResult(msg);
        }

        private AppState _appState = null;
        public void SetAppStateService(AppState appState)
        {
            _appState = appState;
        }
    }
}
