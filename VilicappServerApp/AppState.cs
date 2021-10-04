using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VilicappAPI;

namespace VilicappServerApp
{
    public class AppState
    {
        private readonly IJSRuntime _js;
        private DejanskiState State { get; set; }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public AppState(IJSRuntime js)
        {
            Console.WriteLine("nov app state");
            _js = js;
            State = new DejanskiState();
        }

        public async Task PersistToLS()
        {
            await _js.InvokeVoidAsync("setAppStateToLs", JsonSerializer.Serialize(State));
        }

        public async Task GetFromLS()
        {
            try
            {
                var jsonString = await _js.InvokeAsync<LoggedInUserModel>("getAppStateFromLs");
                //State = JsonSerializer.Deserialize<DejanskiState>(jsonString, new JsonSerializerOptions
                //{
                //    IgnoreReadOnlyFields = true
                //});
            }
            catch(Exception e)
            {
                var a = e;
            }
        }

        public async Task Set(Action<DejanskiState> a)
        {
            a.Invoke(State);
            NotifyStateChanged();
            await PersistToLS();
        }

        public T Get<T>(Func<DejanskiState, T> a)
        {
            return a.Invoke(this.State);
        }

        public async Task Reset()
        {
            State = new DejanskiState();
            await PersistToLS();
        }
    }

    public class DejanskiState
    {

        public DejanskiState()
        {
            Console.WriteLine("nov app state DEJANSKI");
        }
        public bool MobileMenuOpened { get; set; } = false;
        public bool SendVerificationEmail { get; set; } = false;
        public string Language { get; set; } = "en";
        public LoggedInUserModel User { get; set; }
        //public Dictionary<string, Measurements> Permissions { get; set; } = new Dictionary<string, Measurements>();
    }
}
