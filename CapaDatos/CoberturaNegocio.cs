using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class CoberturaNegocio
    {
        public List<Cobertura> Listar()
        {
            List<Cobertura> lista = new List<Cobertura>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_COBERTURAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cobertura aux = new Cobertura();

                    aux.IdCobertura = datos.Lector.GetInt32(0);
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
        public void Agregar_Cobertura(Cobertura NewCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_AGREGAR_COBERTURA");

                datos.setearParametro("@DESCR", NewCobertura.Descripcion);

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
        public void Modificar_Cobertura(Cobertura UpdateCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_MODIFICAR_COBERTURA");

                datos.setearParametro("@ID", UpdateCobertura.IdCobertura);
                datos.setearParametro("@DESCR", UpdateCobertura.Descripcion);

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
        public void Eliminar_Cobertura(Cobertura DeleteCobertura)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_ELIMINAR_COBERTURA");

                datos.setearParametro("@ID", DeleteCobertura.IdCobertura);

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
