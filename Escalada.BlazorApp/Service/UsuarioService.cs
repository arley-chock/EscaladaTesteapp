﻿using Escalada.API.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class UsuarioService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<UsuarioService> _logger; 

    public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger)
    {
        _httpClient = httpClient;
        _logger = logger; 
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/usuarios");
            response.EnsureSuccessStatusCode(); 

            return await response.Content.ReadFromJsonAsync<List<Usuario>>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar os usuários"); 
            throw new ApplicationException($"Erro ao carregar os usuários: {ex.Message}");
        }
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/usuarios/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Usuario>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao carregar o usuário com ID: {id}");
            throw new ApplicationException($"Erro ao carregar o usuário: {ex.Message}");
        }
    }

    public async Task<bool> AddUsuarioAsync(Usuario usuarioModel)
    {
        var usuario = new Usuario()
        {
            Email = usuarioModel.Email,
            Nome = usuarioModel.Nome,
            Sobrenome = usuarioModel.Sobrenome,
            Telefone = usuarioModel.Telefone,
            Id = usuarioModel.Id
        };

        return await SendUsuarioRequestAsync(HttpMethod.Post, "api/usuarios", usuario);
    }

    public async Task<bool> UpdateUsuarioAsync(Usuario usuarioModel)
    {
        var usuario = new Usuario()
        {
            Email = usuarioModel.Email,
            Nome = usuarioModel.Nome,
            Sobrenome = usuarioModel.Sobrenome,
            Telefone= usuarioModel.Telefone,
            Id = usuarioModel.Id
        };
        return await SendUsuarioRequestAsync(HttpMethod.Put, $"api/usuarios/{usuario.Id}", usuario);
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/usuarios/{id}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao excluir o usuário com ID: {id}"); 
            throw new ApplicationException($"Erro ao excluir o usuário: {ex.Message}");
        }
    }

    private async Task<bool> SendUsuarioRequestAsync(HttpMethod method, string url, Usuario usuario = null)
    {
        try
        {
            var request = new HttpRequestMessage(method, url);

            if (usuario != null)
            {
                request.Content = JsonContent.Create(usuario);
            }

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao processar a requisição de usuário para: {url}"); 
            throw new ApplicationException($"Erro ao processar a requisição de usuário: {ex.Message}");
        }
    }
}
