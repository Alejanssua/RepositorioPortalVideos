using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUPortalVideos
{
    public class PeliculaBLL
    {

        public static void Create(Pelicula a)
        {
            using (DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Peliculas.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Pelicula Get(int? id)
        {
            DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities();
            return db.Peliculas.Find(id);
        }

        public static void Update(Pelicula pelicula)
        {
            using (DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Peliculas.Attach(pelicula);
                        db.Entry(pelicula).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pelicula pelicula = db.Peliculas.Find(id);
                        db.Entry(pelicula).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Pelicula> List()
        {
            DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities();
            return db.Peliculas.ToList();
        }


        private static List<Pelicula> GetAlumnos(string criterio)
        {
            DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities();
            return db.Peliculas.Where(x => x.categoria.ToLower().Contains(criterio)).ToList();
        }

        private static Pelicula GetAlumno(string cedula)
        {
            DBPORTALVIDEOSEntities db = new DBPORTALVIDEOSEntities();
            return db.Peliculas.FirstOrDefault(x => x.nombre == cedula);
        }


    }
}
