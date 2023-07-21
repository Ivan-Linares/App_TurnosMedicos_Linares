using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = datos.Lector.GetInt32(0);
                    aux.Tipo = datos.Lector.GetInt32(1);
                    aux.DNI = datos.Lector.GetInt32(2);
                    aux.Password = datos.Lector.GetString(3);
                    aux.Email = datos.Lector.GetString(4);
                    aux.Nombre = datos.Lector.GetString(5);
                    aux.Apellido = datos.Lector.GetString(6);
                    aux.Domicilio = datos.Lector.GetString(7);
                    aux.Telefono = datos.Lector.GetString(8);
                    aux.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Estado = datos.Lector.GetBoolean(10);

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
        public void Agregar_Usuario(Usuario NewUsuario)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_AGREGAR_USUARIO");

                datos.setearParametro("@TipoUsuario", NewUsuario.Tipo);
                datos.setearParametro("@DNI", NewUsuario.DNI);
                datos.setearParametro("@Contraseña", NewUsuario.Password);
                datos.setearParametro("@Email", NewUsuario.Email);
                datos.setearParametro("@Nombre", NewUsuario.Nombre);
                datos.setearParametro("@Apellido", NewUsuario.Apellido);
                datos.setearParametro("@FechaNac", NewUsuario.FechaNacimiento);
                datos.setearParametro("@Direccion", NewUsuario.Domicilio);
                datos.setearParametro("@Telefono", NewUsuario.Telefono);
                datos.setearParametro("@Activo", 1);

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
        public void Agregar_Usuario_Registracion(Usuario NewUsuario)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_AGREGAR_USUARIO_REGISTRACION");

                datos.setearParametro("@NOMBRE", NewUsuario.Nombre);
                datos.setearParametro("@APELLIDO", NewUsuario.Apellido);
                datos.setearParametro("@EMAIL", NewUsuario.Email);
                datos.setearParametro("@FECHA_NAC", NewUsuario.FechaNacimiento);
                datos.setearParametro("@PASS", NewUsuario.Password);
                datos.setearParametro("@ESTADO", 1);

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
        public void Modificar_Usuario(Usuario UpdatedUsuario)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_MODIFICAR_USUARIO");

                datos.setearParametro("@IDUsuario", UpdatedUsuario.IdUsuario);
                datos.setearParametro("@TipoUsuario", UpdatedUsuario.Tipo);
                datos.setearParametro("@DNI", UpdatedUsuario.DNI);
                datos.setearParametro("@Contraseña", UpdatedUsuario.Password);
                datos.setearParametro("@Email", UpdatedUsuario.Email);
                datos.setearParametro("@Nombre", UpdatedUsuario.Nombre);
                datos.setearParametro("@Apellido", UpdatedUsuario.Apellido);
                datos.setearParametro("@FechaNac", UpdatedUsuario.FechaNacimiento);
                datos.setearParametro("@Direccion", UpdatedUsuario.Domicilio);
                datos.setearParametro("@Telefono", UpdatedUsuario.Telefono);
                datos.setearParametro("@Activo", 1);

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
        public void Eliminar_Usuario(int Id)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_ELIMINAR_USUARIO");

                datos.setearParametro("@@IDUsuario", Id);

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
        public Usuario Loguear(Usuario ingreso)
        {

            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_BUSCAR_USUARIO");

                datos.setearParametro("@DNI", ingreso.DNI);
                datos.setearParametro("@PASSWORD", ingreso.Password);
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ingreso.IdUsuario = datos.Lector.GetInt32(0);
                    ingreso.Tipo = datos.Lector.GetInt32(1);
                    ingreso.DNI = datos.Lector.GetInt32(2);
                    ingreso.Password = datos.Lector.GetString(3);
                    ingreso.Email = datos.Lector.GetString(4);
                    ingreso.Nombre = datos.Lector.GetString(5);
                    ingreso.Apellido = datos.Lector.GetString(6);
                    ingreso.Domicilio = datos.Lector.GetString(7);
                    ingreso.Telefono = datos.Lector.GetString(8);
                    ingreso.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    ingreso.FechaNacimiento = ingreso.FechaNacimiento.Date; //DateTime sin Time
                    ingreso.Estado = datos.Lector.GetBoolean(10);
                }

                return ingreso;
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
        public string Cobertura_Usuario(int id)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_LISTAR_COBERTURAS_PACIENTE");

                datos.setearParametro("@id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return datos.Lector.GetString(0);
                else
                    return "N/A";
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
