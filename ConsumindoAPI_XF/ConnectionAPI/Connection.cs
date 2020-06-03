using ConsumindoAPI_XF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoAPI_XF.ConnectionAPI
{
    public class Connection
    {
        //Windows + R
        //cmd
        //ipconfig
        //Endereço IPv4 . . . . . . . . ->
        private static string INITIAL_URL = "http://";
        private static string IP_PC = "192.168.1.6";
        private static string END_URL = ":3000/";

        public static async Task<bool> InserirAluno(Aluno a)
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using(HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);
                    var json = JsonConvert.SerializeObject(a);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await http.PostAsync("alunos/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("InserirAluno: " + response.StatusCode.ToString());
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("InserirAluno: " + ex.Message);
                    return false;
                }
            }
        }
        public static async Task<bool> AtualizarAluno(Aluno a)
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);
                    var json = JsonConvert.SerializeObject(a);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await http.PutAsync("alunos/"+a.Id, content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("AtualizarAluno: " + response.StatusCode.ToString());
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("AtualizarAluno: " + ex.Message);
                    return false;
                }
            }
        }
        public static async Task<bool> DeletarAluno(int id)
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = await http.DeleteAsync("alunos/"+id);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("DeletarAluno: " + response.StatusCode.ToString());
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("DeletarAluno: " + ex.Message);
                    return false;
                }
            }
        }
        public static async Task<List<Aluno>> PegarTodosAlunos()
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = await http.GetAsync("alunos/");
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        List<Aluno> lista = JsonConvert.DeserializeObject<List<Aluno>>(mensagem);
                        return lista;
                    }
                    else
                    {
                        Debug.WriteLine("PegarTodosAlunos: " + response.StatusCode.ToString());
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("PegarTodosAlunos: " + ex.Message);
                    return null;
                }
            }
        }
        public static async Task<Aluno> PegarAlunoPeloId(int id)
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = await http.GetAsync("alunos/"+id);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Aluno a = JsonConvert.DeserializeObject<Aluno>(mensagem);
                        return a;
                    }
                    else
                    {
                        Debug.WriteLine("PegarAlunoPeloId: " + response.StatusCode.ToString());
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("PegarAlunoPeloId: " + ex.Message);
                    return null;
                }
            }
        }
        public static async Task<Aluno> PegarAlunoPeloNome(string Nome)
        {
            Uri url = new Uri(string.Concat(INITIAL_URL, IP_PC, END_URL));

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    http.BaseAddress = url;
                    http.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = await http.GetAsync("alunos?Nome=" + Nome);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Aluno a = JsonConvert.DeserializeObject<Aluno>(mensagem);
                        return a;
                    }
                    else
                    {
                        Debug.WriteLine("PegarAlunoPeloNome: " + response.StatusCode.ToString());
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("PegarAlunoPeloNome: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
