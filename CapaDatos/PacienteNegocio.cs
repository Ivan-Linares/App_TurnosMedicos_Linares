using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class PacienteNegocio
    {
        public List<Paciente> Listar()
        {
            List<Paciente> lista = new List<Paciente>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_PACIENTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.IdPaciente = datos.Lector.GetInt32(0);

                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.IdCobertura = datos.Lector.GetInt32(1);
                    aux.Cobertura.Descripcion = datos.Lector.GetString(2);
                    aux.Cobertura.Estado = datos.Lector.GetBoolean(3);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(4);
                    aux.Usuario.Tipo = datos.Lector.GetInt32(5);
                    aux.Usuario.DNI = datos.Lector.GetInt32(6);
                    aux.Usuario.Password = datos.Lector.GetString(7);
                    aux.Usuario.Email = datos.Lector.GetString(8);
                    aux.Usuario.Nombre = datos.Lector.GetString(9);
                    aux.Usuario.Apellido = datos.Lector.GetString(10);
                    aux.Usuario.Domicilio = datos.Lector.GetString(11);
                    aux.Usuario.Telefono = datos.Lector.GetString(12);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.FechaNacimiento = aux.Usuario.FechaNacimiento.Date; //DateTime sin Time
                    aux.Usuario.Estado = datos.Lector.GetBoolean(14);

                    aux.Estado = datos.Lector.GetBoolean(15);

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
        public void Agregar_Paciente(Paciente NewPaciente)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_AGREGAR_PACIENTE");

                datos.setearParametro("@DNI", NewPaciente.Usuario.DNI);
                datos.setearParametro("@Contraseña", NewPaciente.Usuario.Password);
                datos.setearParametro("@Email", NewPaciente.Usuario.Email);
                datos.setearParametro("@Nombre", NewPaciente.Usuario.Nombre);
                datos.setearParametro("@Apellido", NewPaciente.Usuario.Apellido);
                datos.setearParametro("@FechaNac", NewPaciente.Usuario.FechaNacimiento);
                datos.setearParametro("@Direccion", NewPaciente.Usuario.Domicilio);
                datos.setearParametro("@Telefono", NewPaciente.Usuario.Telefono);
                datos.setearParametro("@IDCOB", NewPaciente.Cobertura.IdCobertura);

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
        public void Modificar_Paciente(Paciente UpdatePaciente)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_MODIFICAR_PACIENTE");

                datos.setearParametro("@IDUSER", UpdatePaciente.Usuario.IdUsuario);
                datos.setearParametro("@IDCOB", UpdatePaciente.Cobertura.IdCobertura);
                datos.setearParametro("@DNI", UpdatePaciente.Usuario.DNI);
                datos.setearParametro("@Contraseña", UpdatePaciente.Usuario.Password);
                datos.setearParametro("@Email", UpdatePaciente.Usuario.Email);
                datos.setearParametro("@Nombre", UpdatePaciente.Usuario.Nombre);
                datos.setearParametro("@Apellido", UpdatePaciente.Usuario.Apellido);
                datos.setearParametro("@FechaNac", UpdatePaciente.Usuario.FechaNacimiento);
                datos.setearParametro("@Direccion", UpdatePaciente.Usuario.Domicilio);
                datos.setearParametro("@Telefono", UpdatePaciente.Usuario.Telefono);

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
        public void Eliminar_Paciente(int Id)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_ELIMINAR_PACIENTE");

                datos.setearParametro("@ID", Id);

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
        public Paciente Paciente_Usuario(int iduser)
        {
            ConnDB datos = new ConnDB();

            try
            {
                datos.Setear_Sp("SP_BUSCAR_PACIENTE_USUARIO");

                datos.setearParametro("@IDUSER", iduser);

                datos.ejecutarLectura();

                Paciente aux = new Paciente();

                if (datos.Lector.Read())
                {
                    aux.IdPaciente = datos.Lector.GetInt32(0);

                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.IdCobertura = datos.Lector.GetInt32(1);
                    aux.Cobertura.Descripcion = datos.Lector.GetString(2);
                    aux.Cobertura.Estado = datos.Lector.GetBoolean(3);

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = datos.Lector.GetInt32(4);
                    aux.Usuario.Tipo = datos.Lector.GetInt32(5);
                    aux.Usuario.DNI = datos.Lector.GetInt32(6);
                    aux.Usuario.Password = datos.Lector.GetString(7);
                    aux.Usuario.Email = datos.Lector.GetString(8);
                    aux.Usuario.Nombre = datos.Lector.GetString(9);
                    aux.Usuario.Apellido = datos.Lector.GetString(10);
                    aux.Usuario.Domicilio = datos.Lector.GetString(11);
                    aux.Usuario.Telefono = datos.Lector.GetString(12);
                    aux.Usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Usuario.Estado = datos.Lector.GetBoolean(14);

                    aux.Estado = datos.Lector.GetBoolean(15);
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
