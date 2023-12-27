using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using LocadoraAPI.Models;

namespace LocadoraAPI.Models
{
    public class LocacaoService
    {
        public ICollection<Locacao> Listar(FiltroLocacao filtro = null)
        {
            using (BdContext context = new BdContext())
            {
                IQueryable<Locacao> locacaos;

                if (filtro != null)
                {
                    switch (filtro.TipoFiltro)
                    {
                        case "NomeUsuario":
                            locacaos = context.Locacaos.Where(l => l.NomeUsuario.Contains(filtro.Filtro)).Include(l => l.Filme);
                        break;
                        case "Filme":
                            locacaos = context.Locacaos.Include(l => l.Filme).Where(l => l.Filme.Nome.Contains(filtro.Filtro));
                        break;
                        default:
                            locacaos = context.Locacaos.Include(l => l.Filme);
                        break;
                    }
                }
                else
                {
                    locacaos = context.Locacaos.Include(l => l.Filme);
                }

                return locacaos.OrderBy(l => l.NomeUsuario).ToList();
            }
        }
        public void Inserir(Locacao locacao)
        {
            using (BdContext context = new BdContext())
            {
                context.Locacaos.Add(locacao);
                context.SaveChanges();
            }
        }
        public Locacao BuscaId(int id)
        {
            using (BdContext context = new BdContext())
            {
                return context.Locacaos.Find(id);
            }
        }
        public void Editar(int id, Locacao locacaoEditada)
        {
            using (BdContext context = new BdContext())
            {
                Locacao locacaoAntiga = context.Locacaos.Find(id);

                locacaoAntiga.NomeUsuario = locacaoEditada.NomeUsuario;
                locacaoAntiga.Telefone = locacaoEditada.Telefone;

                context.SaveChanges();
            }
        }
        public void Excluir(int id)
        {
            using (BdContext context = new BdContext())
            {
                context.Locacaos.Remove(context.Locacaos.Find(id));
                context.SaveChanges();
            }
        }
    }
}