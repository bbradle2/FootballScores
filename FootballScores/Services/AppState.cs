using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FootballScores.Data;
using Microsoft.AspNetCore.Components;

namespace FootballScores.Client.Services
{
    public class AppState
    {
        // Actual state
        public List<Game> SearchResults { get; private set; }
        public bool SearchInProgress { get; private set; }

        private List<Game> gamelist = new List<Game>();
        public List<Game> GameList => gamelist;

        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;

        // Receive 'http' instance from DI
        private readonly HttpClient http;
        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task Search(Game game)
        {
            SearchInProgress = true;
            NotifyStateChanged();

            gamelist = await http.GetJsonAsync<List<Game>>("https://api.collegefootballdata.com/games?year=2020");
            SearchInProgress = false;
            NotifyStateChanged();
        }

       
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
