﻿using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using Fiap_Aula7_PersistenciaBD.Interfaces;
using Fiap_Aula7_PersistenciaBD.Models;

namespace Fiap_Aula7_PersistenciaBD.Repository
{
    // Códigos trabalhando com registro em memória - Utilizar somente para compreensão da utilização do JWT
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Usuario CadastrarUsuario(Usuario usuario)
        {
            // Código antigo
            //var ultimoIdMemoria = 0;
            //
            //if (ListaUsuario.Usuarios.Any())
            //    ultimoIdMemoria = ListaUsuario.Usuarios.Select(x => x.Id).Max() + 1;
            //
            //usuario.Id = ultimoIdMemoria;
            //ListaUsuario.Usuarios.Add(usuario);
            //
            //return usuario;

            //var comandoSql = @"INSERT INTO Usuarios (Username, Password, PermissaoSistema) 
            //                   VALUES (@Username, @Password, @PermissaoSistema)";

            //var novoId = _dbConnection.Execute(comandoSql, usuario);
            //usuario.Id = novoId;

            //return usuario;

            usuario.Id = (int)_dbConnection.Insert<Usuario>(usuario);// Query utilizando o Dapper.Contrib
            return usuario;
        }

        public void DeletarUsuario(int id)
        {
            // Código antigo
            //ListaUsuario.Usuarios.Remove(usuarioExclusao);

            var usuarioExclusao = RetornaUsuarioPorId(id);
            
            if (usuarioExclusao is null || usuarioExclusao.Id.Equals(0))
                return;

            //var comandoSql = @"DELETE FROM Usuario WHERE Id = @ID";
            //_dbConnection.Execute(comandoSql, new { ID = usuarioExclusao.Id });

            _dbConnection.Delete<Usuario>(usuarioExclusao);// Query utilizando o Dapper.Contrib

        }

        public Usuario? RetornaUsuarioPorId(int id)
        {
            // Código antigo
            //var usuario = ListaUsuario.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
            //return usuario?.Id > 0 ? usuario : null;

            //var comandoSql = @"SELECT * FROM Usuarios WHERE Id = @ID";
            //return _dbConnection.Query<Usuario>(comandoSql, new { ID = id }).SingleOrDefault();// new { ID = id }: Estou criando um objeto anônimo. O "ID" é o que está em @ID na linha de cima.

            return _dbConnection.Get<Usuario>(id);// Query utilizando o Dapper.Contrib
        }

        public IList<Usuario> RetornaUsuario()
        {
            // Código antigo
            //return ListaUsuario.Usuarios;

            //var comandoSql = @"SELECT * FROM Usuarios";
            //return _dbConnection.Query<Usuario>(comandoSql).ToList();// Query<Usuario>: Significa que os dados da base de dados serão uma lista desse objeto Usuario.

            return _dbConnection.GetAll<Usuario>().ToList();// Query utilizando o Dapper.Contrib
        }
    }
}
