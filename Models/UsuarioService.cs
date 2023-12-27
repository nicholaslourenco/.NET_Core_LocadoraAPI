using System.Collections.Generic;
using System.Linq;
using LocadoraAPI.Models;

namespace LocadoraAPI.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using (BdContext context = new BdContext())
            {
                return context.Usuarios.ToList();
            }
        }

        public void Inserir(Usuario usuario)
        {
            using (BdContext context = new BdContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public Usuario BuscaId(int id)
        {
            using (BdContext context = new BdContext())
            {
                return context.Usuarios.Find(id);
            }
        }

        public void Editar(int id, Usuario usuarioEditado)
        {
            using (BdContext context = new BdContext())
            {
                Usuario usuarioAntigo = context.Usuarios.Find(id);

                usuarioAntigo.Nome = usuarioEditado.Nome;
                usuarioAntigo.Login = usuarioEditado.Login;
                usuarioAntigo.Senha = usuarioEditado.Senha;
                usuarioAntigo.Tipo = usuarioEditado.Tipo;

                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (BdContext context = new BdContext())
            {
                context.Usuarios.Remove(context.Usuarios.Find(id));
                context.SaveChanges();
            }
        }
    }
}