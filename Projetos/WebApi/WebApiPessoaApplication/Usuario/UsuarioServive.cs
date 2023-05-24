using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiPessoa.Repository;
using WebApiPessoa.Repository.Models;

namespace WebApiPessoaApplication.Usuario
{
    public class UsuarioServive
    {
        private readonly PessoaContext _context;

        public UsuarioServive(PessoaContext context)
        {
            _context = context;
        }
        public bool InserirUsuario(UsuarioRequest request)
        {
            try
            {
                var usuario = new TabUsuario()
                {
                    nome = request.Nome,
                    usuario = request.Usuario,
                    senha = request.Senha
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TabUsuario> ObterUsuarios()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public TabUsuario ObterUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(x => x.id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AtualizarUsuario(int id, UsuarioRequest request)
        {
            try
            {
                var usuarioDb = _context.Usuarios.FirstOrDefault(x => x.id == id);
                if (usuarioDb == null)
                    return false;

                usuarioDb.nome = request.Nome;
                usuarioDb.usuario = request.Usuario;
                usuarioDb.senha = request.Senha;

                _context.Usuarios.Update(usuarioDb);
                _context.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool RemoverUsuario(int id)
        {
            try
            {
                var usuarioDb = _context.Usuarios.FirstOrDefault(x => x.id == id);
                if (usuarioDb == null)
                    return false;

                _context.Usuarios.Remove(usuarioDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
