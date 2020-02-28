using System;
using System.Collections.Generic;
using System.Text;
using RegistroConDetalle.Entidades;
using RegistroConDetalle.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroConDetalle.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Personas.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var anterior = db.Personas.Find(personas.PersonaId);
                foreach(var item in anterior.Telefonos)
                {
                    if (!personas.Telefonos.Exists(t => t.Id == item.Id))
                        db.Entry(item).State = EntityState.Deleted;
                }

                db.Entry(personas).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally{
                db.Dispose();
            }

            return paso;
        }

        public static Personas Buscar(int id)
        {
            Personas persona = new Personas();
            Contexto db = new Contexto();

            try
            {
                persona = db.Personas.Find(id);
                persona.Telefonos.Count();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }

        public static List<Personas> GetLista(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Personas.Where(persona).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
