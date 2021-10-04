using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VilicappAPI;

namespace VilicappClient
{
    public class AppState
    {
        private readonly IJSRuntime _js;

        public AppState(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<string> GetUserToken()
        {
            var jsonString = await _js.InvokeAsync<string>("sessionStorage.getItem", "User");
            if(jsonString != null)
            {
                var loggedInUserModel = JsonSerializer.Deserialize<LoggedInUserModel>(jsonString, new JsonSerializerOptions
                {
                    IgnoreReadOnlyFields = true
                });
                return loggedInUserModel.Token;
            }
           
            return null;
        }
    }
}
