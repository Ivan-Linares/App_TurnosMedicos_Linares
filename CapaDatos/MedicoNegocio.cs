using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class MedicoNegocio
    {
        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_MEDICOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.IdMedico = datos.Lector.GetInt32(0);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(1);
                    aux.Usuario.Tipo = 1;
                    aux.Usuario.DNI = datos.Lector.GetInt32(2);
                    aux.Usuario.Password = datos.Lector.GetString(3);
                    aux.Usuario.Email = datos.Lector.GetString(4);
                    aux.Usuario.Nombre = datos.Lector.GetString(5);
                    aux.Usuario.Apellido = datos.Lector.GetString(6);
                    aux.Apellido = datos.Lector.GetString(5) + " " + datos.Lector.GetString(6);
                    aux.Usuario.Domicilio = datos.Lector.GetString(7);
                    aux.Usuario.Telefono = datos.Lector.GetString(8);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.Estado = true;

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IdEspecialidad = datos.Lector.GetInt32(10);
                    aux.Especialidad.Descripcion = datos.Lector.GetString(11);
                    aux.Especialidad.Estado = true;

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
        public void ModificarMedico(Medico med)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_MODIFICAR_MEDICO");

                datos.setearParametro("@IDMED", med.IdMedico);
                datos.setearParametro("@IDESP", med.Especialidad.IdEspecialidad);
                datos.setearParametro("@DNI", med.Usuario.DNI);
                datos.setearParametro("@Contraseña", med.Usuario.Password);
                datos.setearParametro("@Email", med.Usuario.Email);
                datos.setearParametro("@Nombre", med.Usuario.Nombre);
                datos.setearParametro("@Apellido", med.Usuario.Apellido);
                datos.setearParametro("@FechaNac", med.Usuario.FechaNacimiento);
                datos.setearParametro("@Direccion", med.Usuario.Domicilio);
                datos.setearParametro("@Telefono", med.Usuario.Telefono);

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
        public List<Medico> ListarDatos()
        {
            List<Medico> lista = new List<Medico>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_MEDICOS_SOLODATOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.IdMedico = datos.Lector.GetInt32(0);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(1);
                    aux.Usuario.Tipo = 1;
                    aux.Usuario.DNI = datos.Lector.GetInt32(2);
                    aux.Usuario.Password = datos.Lector.GetString(3);
                    aux.Usuario.Email = datos.Lector.GetString(4);
                    aux.Usuario.Nombre = datos.Lector.GetString(5);
                    aux.Usuario.Apellido = datos.Lector.GetString(6);
                    aux.Apellido = datos.Lector.GetString(5) + " " + datos.Lector.GetString(6);
                    aux.Usuario.Domicilio = datos.Lector.GetString(7);
                    aux.Usuario.Telefono = datos.Lector.GetString(8);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.Estado = true;

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
        public List<Medico> ListarPorEspecialidad(int id)
        {
            List<Medico> lista = new List<Medico>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_MEDICO_X_ESP");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IdEspecialidad = datos.Lector.GetInt32(0);
                    aux.Especialidad.Descripcion = datos.Lector.GetString(1);

                    aux.IdMedico = datos.Lector.GetInt32(2);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(3);
                    aux.Usuario.Tipo = 1;
                    aux.Usuario.DNI = datos.Lector.GetInt32(4);
                    aux.Usuario.Password = datos.Lector.GetString(5);
                    aux.Usuario.Email = datos.Lector.GetString(6);
                    aux.Usuario.Nombre = datos.Lector.GetString(7);
                    aux.Usuario.Apellido = datos.Lector.GetString(8);
                    aux.Apellido = datos.Lector.GetString(7) + " " + datos.Lector.GetString(8);
                    aux.Usuario.Domicilio = datos.Lector.GetString(9);
                    aux.Usuario.Telefono = datos.Lector.GetString(10);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.Estado = true;

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
        public Medico BuscarMedico(int id)
        {
            Medico aux = new Medico();

            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_BUSCAR_MEDICO_USUARIO");

                datos.setearParametro("@IDUSU", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.IdMedico = datos.Lector.GetInt32(0);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(1);
                    aux.Usuario.Tipo = 1;
                    aux.Usuario.DNI = datos.Lector.GetInt32(2);
                    aux.Usuario.Password = datos.Lector.GetString(3);
                    aux.Usuario.Email = datos.Lector.GetString(4);
                    aux.Usuario.Nombre = datos.Lector.GetString(5);
                    aux.Usuario.Apellido = datos.Lector.GetString(6);
                    aux.Apellido = datos.Lector.GetString(5) + " " + datos.Lector.GetString(6);
                    aux.Usuario.Domicilio = datos.Lector.GetString(7);
                    aux.Usuario.Telefono = datos.Lector.GetString(8);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.Estado = true;

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IdEspecialidad = datos.Lector.GetInt32(10);
                    aux.Especialidad.Descripcion = datos.Lector.GetString(11);
                    aux.Especialidad.Estado = true;

                    aux.Estado = true;
                }

                return aux;
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
