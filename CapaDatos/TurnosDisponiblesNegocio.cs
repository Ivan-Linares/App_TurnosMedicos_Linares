using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class TurnosDisponiblesNegocio
    {
        public List<TurnoDisponible> ListarEspecialidadMedico(int idmedico, int idespecialidad)
        {
            List<TurnoDisponible> lista = new List<TurnoDisponible>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_TURNOSDISPONIBLES_MEDICOESPECIALIDAD");
                
                datos.setearParametro("@IDMED", idmedico);
                datos.setearParametro("@IDESPEC", idespecialidad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoDisponible turno = new TurnoDisponible();

                    turno.IDTurno = datos.Lector.GetInt32(0);
                    turno.FechaTurno = datos.Lector.GetDateTime(1).ToShortDateString();
                    turno.HoraTurno = datos.Lector.GetTimeSpan(2);
                    turno.IdMedico = datos.Lector.GetInt32(3);
                    turno.IdEspecialidad = datos.Lector.GetInt32(4);
                    turno.EspecialidadDescrip = datos.Lector.GetString(5);
                    turno.Disponible = true;

                    lista.Add(turno);
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
        public List<TurnoDisponible> ListarMedico(int idmedico)
        {
            List<TurnoDisponible> lista = new List<TurnoDisponible>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_TURNOSDISPONIBLES_MEDICO");

                datos.setearParametro("@IDMED", idmedico);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoDisponible turno = new TurnoDisponible();

                    turno.IDTurno = datos.Lector.GetInt32(0);
                    turno.FechaTurno = datos.Lector.GetDateTime(1).ToShortDateString();
                    turno.HoraTurno = datos.Lector.GetTimeSpan(2);
                    turno.IdMedico = datos.Lector.GetInt32(3);
                    turno.IdEspecialidad = datos.Lector.GetInt32(4);
                    turno.EspecialidadDescrip = datos.Lector.GetString(5);
                    turno.Disponible = true;

                    lista.Add(turno);
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
        public bool AgregarTurnoDisponible(int idusu, DateTime fecha, TimeSpan hora, int idespec)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_CREAR_TURNO_DISPONIBLE");

                datos.setearParametro("@IDUSUARIO", idusu);
                datos.setearParametro("@FECHATURNO", fecha);
                datos.setearParametro("@HORATURNO", hora);
                datos.setearParametro("@IDESPEC", idespec);

                datos.ejecutarAccion();

                return true;
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
        public bool AgregarTurnoDisponibleIDMED(int idusu, DateTime fecha, TimeSpan hora, int idespec)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_CREAR_TURNO_DISPONIBLE_IDMED");

                datos.setearParametro("@IDMEDICO", idusu);
                datos.setearParametro("@FECHATURNO", fecha);
                datos.setearParametro("@HORATURNO", hora);
                datos.setearParametro("@IDESPEC", idespec);

                datos.ejecutarAccion();

                return true;
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
