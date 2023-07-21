using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaDatos
{
    public class TurnosAgendadosNegocio
    {
        public List<TurnoAgendado> ListarTurnosReservados(int idmusuario)
        {
            List<TurnoAgendado> lista = new List<TurnoAgendado>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_TURNOS_RESERVADOS_PAC");

                datos.setearParametro("@IDUSU", idmusuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAgendado turno = new TurnoAgendado();

                    turno.IDTurno = datos.Lector.GetInt32(0);
                    turno.NombreMed = datos.Lector.GetString(4);
                    turno.Apemed = datos.Lector.GetString(5);
                    turno.Especialidad = datos.Lector.GetString(7);
                    turno.Estado = true;

                    turno.TurnoDisponible = new TurnoDisponible();
                    turno.TurnoDisponible.FechaTurno = datos.Lector.GetDateTime(1).ToShortDateString();
                    turno.TurnoDisponible.HoraTurno = datos.Lector.GetTimeSpan(2);
                    turno.TurnoDisponible.IdMedico = datos.Lector.GetInt32(3);
                    turno.TurnoDisponible.IdEspecialidad = datos.Lector.GetInt32(6);

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
        public List<TurnoAgendado> ListarTurnosReservadosDNIPac(int Dni)
        {
            List<TurnoAgendado> lista = new List<TurnoAgendado>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_TURNOS_RESERVADOS_DNIPAC");

                datos.setearParametro("@DNIPAC", Dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAgendado turno = new TurnoAgendado();

                    turno.IDTurno = datos.Lector.GetInt32(0);
                    turno.NombreMed = datos.Lector.GetString(4);
                    turno.Apemed = datos.Lector.GetString(5);
                    turno.Especialidad = datos.Lector.GetString(7);
                    turno.Estado = true;

                    turno.TurnoDisponible = new TurnoDisponible();
                    turno.TurnoDisponible.FechaTurno = datos.Lector.GetDateTime(1).ToShortDateString();
                    turno.TurnoDisponible.HoraTurno = datos.Lector.GetTimeSpan(2);
                    turno.TurnoDisponible.IdMedico = datos.Lector.GetInt32(3);
                    turno.TurnoDisponible.IdEspecialidad = datos.Lector.GetInt32(6);

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
        public List<TurnoAgendado> ListarTurnosReservadosMedicos(int idmusuario)
        {
            List<TurnoAgendado> lista = new List<TurnoAgendado>();
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_LISTAR_TURNOS_RESERVADOS_MED");

                datos.setearParametro("@IDUSU", idmusuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAgendado turno = new TurnoAgendado();

                    turno.IDTurno = datos.Lector.GetInt32(0);
                    
                    turno.TurnoDisponible = new TurnoDisponible();
                    turno.TurnoDisponible.IDTurno = datos.Lector.GetInt32(1);
                    turno.TurnoDisponible.FechaTurno = datos.Lector.GetDateTime(2).ToShortDateString();
                    turno.TurnoDisponible.HoraTurno = datos.Lector.GetTimeSpan(3);
                    turno.TurnoDisponible.IdMedico = datos.Lector.GetInt32(4);
                    turno.TurnoDisponible.IdEspecialidad = datos.Lector.GetInt32(5);

                    turno.NombrePac = datos.Lector.GetString(6);
                    turno.ApePac = datos.Lector.GetString(7);
                    turno.Especialidad = datos.Lector.GetString(8);
                    turno.Estado = true;

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
        public bool ReservarTurno(int idturno, int idusuario)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_RESERVAR_TURNO");

                datos.setearParametro("@IDTURNO", idturno);
                datos.setearParametro("@IDUSU", idusuario);
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
        public bool ReservarTurnoSecretaria(int idturno, int DniPac)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_RESERVAR_TURNO_SECRETARIA");

                datos.setearParametro("@IDTURNO", idturno);
                datos.setearParametro("@DNIPAC", DniPac);
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
        public bool DarBajaTurno(int idturno)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_DAR_BAJA_TURNO_AGENDADO");

                datos.setearParametro("@IDAGENDADO", idturno);

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

        public bool TurnoRealizado(int idturno)
        {
            ConnDB datos = new ConnDB();
            try
            {
                datos.Setear_Sp("SP_TURNO_REALIZADO");

                datos.setearParametro("@IDAGENDADO", idturno);

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
