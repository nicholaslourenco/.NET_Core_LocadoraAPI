using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using LocadoraAPI.Models;

namespace LocadoraAPI.Models
{
    public class FilmesService
    {

        public List<Filme> Listar(FiltroFilme filtro = null)
        {
            using (BdContext context = new BdContext())
            {
                IQueryable<Filme> query;

                if (filtro != null)
                {
                    switch (filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = context.Filmes.Where(f => f.Nome.Contains(filtro.Filtro));
                            break;
                        case "Genero":
                            query = context.Filmes.Where(f => f.Genero.Contains(filtro.Filtro));
                            break;
                        case "Classificacao":
                            query = context.Filmes.Where(f => f.Classificacao.Contains(filtro.Filtro));
                            break;
                        default:
                            query = context.Filmes;
                            break;
                    }
                }
                else
                {
                    query = context.Filmes;
                }

                return query.OrderBy(f => f.Nome).ToList();
            }
        }

        public void Inserir(Filme filme)
        {
            using (BdContext context = new BdContext())
            {
                context.Filmes.Add(filme);
                context.SaveChanges();
            }
        }

        public Filme BuscaId(int id)
        {
            using (BdContext context = new BdContext())
            {
                return context.Filmes.Find(id);
            }
        }

        public void Editar(int id, Filme filmeEditado)
        {
            using (BdContext context = new BdContext())
            {
                Filme filmeAntigo = context.Filmes.Find(id);

                filmeAntigo.Nome = filmeEditado.Nome;
                filmeAntigo.Genero = filmeEditado.Genero;
                filmeAntigo.Classificacao = filmeEditado.Classificacao;
                filmeAntigo.CaminhoImagem = filmeEditado.CaminhoImagem;

                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (BdContext context = new BdContext())
            {
                context.Filmes.Remove(context.Filmes.Find(id));
                context.SaveChanges();
            }
        }
    }
}