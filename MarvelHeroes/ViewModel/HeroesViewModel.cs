
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MarvelHeroes.Model;
using Newtonsoft.Json;
using RestSharp;

namespace MarvelHeroes.ViewModel
{
    public class HeroesViewModel : ViewModelBase
    {
        #region Singleton
        /// <summary>
        /// A singleton instance of the factory class
        /// </summary>
        private static HeroesViewModel _instance;
        public static HeroesViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HeroesViewModel();

                return _instance;
            }
        }
        #endregion Singleton

        int _offset = 0;
        const int _LIMIT = 20;
        const string _PUBLIC_KEY = "93586130237477dd2b726ca0a411ff82";
        const string _PRIVATE_KEY = "b91b03bf463f750eff38826f78558bad7e3a642a";
        RestClient _restClient;

        private ObservableCollection<Result> _heroes;
        public ObservableCollection<Result> Heroes
        {
            get { return _heroes; }
            set
            {
                _heroes = value;
                OnPropertyChanged();
            }
        }

        private Result _heroSelected;
        public Result HeroeSelected
        {
            get { return _heroSelected; }
            set
            {
                _heroSelected = value;
                OnPropertyChanged();
            }
        }


        public HeroesViewModel()
        {
            _restClient = new RestClient("https://gateway.marvel.com/");
            _heroes = new ObservableCollection<Result>();
            GetHeroes();
        }

        private string GetHashApi(string timestamp)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(timestamp + _PRIVATE_KEY + _PUBLIC_KEY);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2").ToLower());
                }
                return sb.ToString();
            }
        }

        public void GetHeroes()
        {
            try
            {
                var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
                var request = new RestRequest("v1/public/characters", Method.GET);
                request.AddHeader("Accept", "*/*");

                request.AddParameter("apikey", _PUBLIC_KEY);
                request.AddParameter("ts", timestamp);
                request.AddParameter("hash", GetHashApi(timestamp));
                request.AddParameter("offset", _offset);
                request.AddParameter("limit", _LIMIT);

                _restClient.ExecuteAsync(request, async (response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var objResponse = await Task.Run(() => JsonConvert.DeserializeObject<Response>(response.Content));

                        if(objResponse.Data.Count > 0)
                        {
                            foreach(var result in objResponse.Data.Results)
                            {
                                Heroes.Add(result);
                            }
                            _offset = Heroes.Count;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("ERRO - " + response.ErrorMessage);
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO - " + ex.ToString());
            }
        }
    }
}
