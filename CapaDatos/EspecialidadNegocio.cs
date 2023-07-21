using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_ESP");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();

                    aux.IdEspecialidad = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);
                    aux.Estado = true;

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Especialidad> ListarPorMedico(int id)
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_ESP_X_MEDICO");
               
                datos.setearParametro("@IDUSER", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();

                    aux.IdEspecialidad = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);
                    aux.Estado = true;

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Agregar_Cobertura(Especialidad NewCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_AGREGAR_ESP");

                datos.setearParametro("@DESCRIP", NewCobertura.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Modificar_Cobertura(Especialidad UpdateCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_MODIFICAR_ESP");

                datos.setearParametro("@ID", UpdateCobertura.IdEspecialidad);
                datos.setearParametro("@DESCRIP", UpdateCobertura.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Eliminar_Cobertura(Especialidad DeleteCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_ELIMINAR_ESP");

                datos.setearParametro("@ID", DeleteCobertura.IdEspecialidad);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
