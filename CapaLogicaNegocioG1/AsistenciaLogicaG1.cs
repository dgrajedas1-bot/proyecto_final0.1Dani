using System;
using System.Data;
using CapaAccesoDatosG1;
using CapaEntidadesG1;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Reglas de negocio de la asistencia: marcaje de ingreso y salida, tardanzas,
    /// horas extras, reporte por periodo y datos del panel de inicio.
    /// </summary>
    public class AsistenciaLogicaG1
    {
        private AsistenciaDatosG1 gObjDatosG1 = new AsistenciaDatosG1();
        private readonly TurnoDatosG1 gObjTurnoDatosG1 = new TurnoDatosG1();
        private readonly EmpleadoDatosG1 gObjEmpleadoDatosG1 = new EmpleadoDatosG1();

        /// <summary>Horas antes del inicio del turno en las que ya se permite marcar ingreso.</summary>
        private const int gIntHorasAnticipacionG1 = 2;

        /// <summary>
        /// Fórmula oficial del enunciado:
        /// (Salario Base Mensual / 30 / Horas Jornada Diaria) x 1.5 x Cantidad de Horas Extras.
        /// Se asume una jornada diaria de 8 horas.
        /// </summary>
        /// <param name="salarioBaseMensual">Salario base mensual del empleado.</param>
        /// <param name="cantidadHorasExtras">Horas extras trabajadas.</param>
        /// <returns>Monto a pagar por las horas extras.</returns>
        public decimal SubCalcularPagoHorasExtrasG1(decimal salarioBaseMensual, decimal cantidadHorasExtras)
        {
            // Fórmula: (Salario Base Mensual / 30 / Horas Jornada Diaria) x 1.5 x Cantidad de Horas Extras
            // Asumimos que la jornada diaria son 8 horas
            if (salarioBaseMensual <= 0 || cantidadHorasExtras <= 0) return 0;

            decimal valorHoraNormal = salarioBaseMensual / 30 / 8;
            decimal valorHoraExtra = valorHoraNormal * 1.5m;
            return valorHoraExtra * cantidadHorasExtras;
        }

        /// <summary>
        /// Registra el ingreso de un empleado validando código, estado activo, turno asignado,
        /// horario permitido y que no haya marcado antes. Calcula tardanza con la tolerancia del turno.
        /// </summary>
        /// <param name="strCodigoG1">Código del empleado (001).</param>
        /// <returns>Resultado del marcaje.</returns>
        public ResultadoMarcajeG1 SubRegistrarIngresoG1(string strCodigoG1)
        {
            EmpleadoG1 objEmpleadoG1 = FunObtenerEmpleadoActivoG1(strCodigoG1);
            DateTime dtmAhoraG1 = DateTime.Now;

            RegistroAsistenciaG1 objAbiertoG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunObtenerRegistroAbiertoG1(objEmpleadoG1.IdEmpleado));
            if (objAbiertoG1 != null)
                return FunErrorG1("Ya tiene una entrada registrada el " + objAbiertoG1.FechaHoraEntrada.ToString("dd/MM/yyyy HH:mm") +
                                  " sin salida. Marque primero la salida.");

            // Turno de hoy o turno nocturno que empezó ayer
            TurnoG1 objTurnoHoyG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjTurnoDatosG1.FunObtenerTurnoAsignadoG1(objEmpleadoG1.IdEmpleado, dtmAhoraG1.Date));
            TurnoG1 objTurnoAyerG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjTurnoDatosG1.FunObtenerTurnoAsignadoG1(objEmpleadoG1.IdEmpleado, dtmAhoraG1.Date.AddDays(-1)));

            TurnoG1 objTurnoG1 = null;
            DateTime dtmInicioG1 = DateTime.MinValue;
            if (objTurnoAyerG1 != null && objTurnoAyerG1.EsNocturnoG1)
            {
                DateTime dtmInicioAyerG1 = dtmAhoraG1.Date.AddDays(-1).Add(objTurnoAyerG1.HoraEntrada);
                if (dtmAhoraG1 <= dtmInicioAyerG1.AddHours((double)objTurnoAyerG1.HorasJornadaG1))
                {
                    objTurnoG1 = objTurnoAyerG1;
                    dtmInicioG1 = dtmInicioAyerG1;
                }
            }
            if (objTurnoG1 == null && objTurnoHoyG1 != null)
            {
                objTurnoG1 = objTurnoHoyG1;
                dtmInicioG1 = dtmAhoraG1.Date.Add(objTurnoHoyG1.HoraEntrada);
            }
            if (objTurnoG1 == null)
                return FunErrorG1(objEmpleadoG1.Nombres + " no tiene un turno asignado hoy.");

            DateTime dtmFinG1 = dtmInicioG1.AddHours((double)objTurnoG1.HorasJornadaG1);
            DateTime dtmPermitidoG1 = dtmInicioG1.AddHours(-gIntHorasAnticipacionG1);
            if (dtmAhoraG1 < dtmPermitidoG1)
                return FunErrorG1("Todavía no puede marcar. Su turno (" + objTurnoG1.NombreTurno + ") inicia a las " +
                                  dtmInicioG1.ToString("HH:mm") + "; puede marcar desde las " + dtmPermitidoG1.ToString("HH:mm") + ".");
            if (dtmAhoraG1 > dtmFinG1)
                return FunErrorG1("Su turno (" + objTurnoG1.NombreTurno + ") ya terminó a las " + dtmFinG1.ToString("HH:mm") + ".");

            int intIngresosG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarIngresosEnRangoG1(objEmpleadoG1.IdEmpleado, dtmPermitidoG1, dtmFinG1));
            if (intIngresosG1 > 0)
                return FunErrorG1("Ya registró su ingreso para el turno de hoy.");

            int intRetardoG1 = FunCalcularMinutosRetardoG1(dtmInicioG1, dtmAhoraG1);
            string strEstadoG1 = intRetardoG1 > objTurnoG1.ToleranciaMinutos ? "Tarde" : "Presente";

            RegistroAsistenciaG1 objRegistroG1 = new RegistroAsistenciaG1
            {
                IdEmpleado = objEmpleadoG1.IdEmpleado,
                FechaHoraEntrada = dtmAhoraG1,
                Estado = strEstadoG1,
                MinutosRetardoG1 = intRetardoG1
            };
            ErroresLogicaG1.SubEjecutarG1(() => gObjDatosG1.SubInsertarIngresoG1(objRegistroG1));

            string strMensajeG1 = strEstadoG1 == "Tarde"
                ? "Ingreso registrado CON TARDANZA de " + intRetardoG1 + " minuto(s)."
                : "Ingreso registrado a tiempo.";
            return new ResultadoMarcajeG1
            {
                ExitosoG1 = true,
                EstadoG1 = strEstadoG1,
                MinutosRetardoG1 = intRetardoG1,
                MensajeG1 = objEmpleadoG1.Nombres + " " + objEmpleadoG1.Apellidos + " - " + dtmAhoraG1.ToString("HH:mm") + "\n" + strMensajeG1
            };
        }

        /// <summary>
        /// Registra la salida del empleado, calcula horas trabajadas, horas extras sobre la
        /// duración del turno y el pago de las horas extras.
        /// </summary>
        /// <param name="strCodigoG1">Código del empleado (001).</param>
        /// <returns>Resultado del marcaje.</returns>
        public ResultadoMarcajeG1 SubRegistrarSalidaG1(string strCodigoG1)
        {
            EmpleadoG1 objEmpleadoG1 = FunObtenerEmpleadoActivoG1(strCodigoG1);
            DateTime dtmAhoraG1 = DateTime.Now;

            RegistroAsistenciaG1 objAbiertoG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunObtenerRegistroAbiertoG1(objEmpleadoG1.IdEmpleado));
            if (objAbiertoG1 == null)
                return FunErrorG1("No tiene un ingreso registrado. Marque primero el ingreso.");
            if (dtmAhoraG1 <= objAbiertoG1.FechaHoraEntrada)
                return FunErrorG1("La hora de salida debe ser posterior a la de entrada.");

            // Turno del día de entrada; si no hay, turno nocturno del día anterior; si no, jornada de 8 h
            DateTime dtmFechaEntradaG1 = objAbiertoG1.FechaHoraEntrada.Date;
            TurnoG1 objTurnoG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjTurnoDatosG1.FunObtenerTurnoAsignadoG1(objEmpleadoG1.IdEmpleado, dtmFechaEntradaG1));
            if (objTurnoG1 == null)
            {
                TurnoG1 objTurnoAnteriorG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjTurnoDatosG1.FunObtenerTurnoAsignadoG1(objEmpleadoG1.IdEmpleado, dtmFechaEntradaG1.AddDays(-1)));
                if (objTurnoAnteriorG1 != null && objTurnoAnteriorG1.EsNocturnoG1) objTurnoG1 = objTurnoAnteriorG1;
            }
            decimal decJornadaG1 = objTurnoG1 != null ? objTurnoG1.HorasJornadaG1 : 8m;

            decimal decTrabajadasG1 = FunCalcularHorasTrabajadasG1(objAbiertoG1.FechaHoraEntrada, dtmAhoraG1);
            decimal decExtrasG1 = FunCalcularHorasExtrasG1(decTrabajadasG1, decJornadaG1);
            decimal decPagoG1 = Math.Round(SubCalcularPagoHorasExtrasG1(objEmpleadoG1.SalarioBase, decExtrasG1), 2);

            int intFilasG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunRegistrarSalidaG1(objAbiertoG1.IdRegistro, dtmAhoraG1, decExtrasG1));
            if (intFilasG1 == 0) return FunErrorG1("La salida ya había sido registrada.");

            return new ResultadoMarcajeG1
            {
                ExitosoG1 = true,
                EstadoG1 = objAbiertoG1.Estado,
                MinutosRetardoG1 = objAbiertoG1.MinutosRetardoG1,
                HorasExtrasG1 = decExtrasG1,
                PagoHorasExtrasG1 = decPagoG1,
                MensajeG1 = objEmpleadoG1.Nombres + " " + objEmpleadoG1.Apellidos + " - " + dtmAhoraG1.ToString("HH:mm") +
                            "\nSalida registrada. Horas trabajadas: " + decTrabajadasG1.ToString("0.00") +
                            "\nHoras extras: " + decExtrasG1.ToString("0.00") + "  |  Pago extras: Q " + decPagoG1.ToString("0.00")
            };
        }

        /// <summary>Minutos de retardo entre la hora de inicio del turno y la marcación (0 si llegó antes).</summary>
        /// <param name="dtmInicioTurnoG1">Inicio del turno.</param>
        /// <param name="dtmMarcajeG1">Hora de la marcación.</param>
        /// <returns>Minutos de retardo.</returns>
        public int FunCalcularMinutosRetardoG1(DateTime dtmInicioTurnoG1, DateTime dtmMarcajeG1)
        {
            if (dtmMarcajeG1 <= dtmInicioTurnoG1) return 0;
            return (int)Math.Floor((dtmMarcajeG1 - dtmInicioTurnoG1).TotalMinutes);
        }

        /// <summary>Horas trabajadas entre entrada y salida, redondeadas a 2 decimales.</summary>
        /// <param name="dtmEntradaG1">Fecha y hora de entrada.</param>
        /// <param name="dtmSalidaG1">Fecha y hora de salida.</param>
        /// <returns>Horas trabajadas.</returns>
        public decimal FunCalcularHorasTrabajadasG1(DateTime dtmEntradaG1, DateTime dtmSalidaG1)
        {
            if (dtmSalidaG1 <= dtmEntradaG1) return 0;
            return Math.Round((decimal)(dtmSalidaG1 - dtmEntradaG1).TotalHours, 2);
        }

        /// <summary>Horas extras: lo trabajado que supera la duración del turno.</summary>
        /// <param name="decHorasTrabajadasG1">Horas trabajadas.</param>
        /// <param name="decHorasJornadaG1">Duración del turno en horas.</param>
        /// <returns>Horas extras (0 si no hubo).</returns>
        public decimal FunCalcularHorasExtrasG1(decimal decHorasTrabajadasG1, decimal decHorasJornadaG1)
        {
            decimal decExtrasG1 = decHorasTrabajadasG1 - decHorasJornadaG1;
            return decExtrasG1 > 0 ? Math.Round(decExtrasG1, 2) : 0;
        }

        /// <summary>
        /// Reporte de asistencia por periodo con retrasos, horas trabajadas, horas extras y su pago.
        /// </summary>
        /// <param name="dtmDesdeG1">Fecha inicial.</param>
        /// <param name="dtmHastaG1">Fecha final.</param>
        /// <returns>Tabla lista para mostrar en dgvReporteAsistenciaG1.</returns>
        public DataTable FunReporteAsistenciaG1(DateTime dtmDesdeG1, DateTime dtmHastaG1)
        {
            if (dtmHastaG1.Date < dtmDesdeG1.Date) throw new ArgumentException("La fecha final no puede ser menor que la fecha inicial.");
            if ((dtmHastaG1.Date - dtmDesdeG1.Date).TotalDays > 366) throw new ArgumentException("El periodo no puede ser mayor a un año.");

            DataTable dtReporteG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunReporteG1(dtmDesdeG1, dtmHastaG1));
            dtReporteG1.Columns.Add("PagoHorasExtras", typeof(decimal));
            foreach (DataRow drFilaG1 in dtReporteG1.Rows)
            {
                decimal decSalarioG1 = drFilaG1["SalarioBase"] == DBNull.Value ? 0 : Convert.ToDecimal(drFilaG1["SalarioBase"]);
                decimal decExtrasG1 = drFilaG1["HorasExtras"] == DBNull.Value ? 0 : Convert.ToDecimal(drFilaG1["HorasExtras"]);
                drFilaG1["PagoHorasExtras"] = Math.Round(SubCalcularPagoHorasExtrasG1(decSalarioG1, decExtrasG1), 2);
            }
            dtReporteG1.Columns.Remove("SalarioBase");
            return dtReporteG1;
        }

        /// <summary>Total de empleados activos.</summary>
        /// <returns>Cantidad.</returns>
        public int FunTotalEmpleadosG1() { return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarEmpleadosActivosG1()); }

        /// <summary>Empleados que marcaron ingreso hoy.</summary>
        /// <returns>Cantidad.</returns>
        public int FunPresentesHoyG1() { return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarPresentesHoyG1()); }

        /// <summary>Tardanzas registradas hoy.</summary>
        /// <returns>Cantidad.</returns>
        public int FunTardanzasHoyG1() { return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarTardanzasHoyG1()); }

        /// <summary>
        /// Porcentaje de asistencia de hoy: presentes / empleados con turno hoy
        /// (si nadie tiene turno, se usa el total de empleados activos).
        /// </summary>
        /// <returns>Porcentaje entre 0 y 100.</returns>
        public int FunPorcentajeAsistenciaHoyG1()
        {
            int intBaseG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarAsignadosHoyG1());
            if (intBaseG1 == 0) intBaseG1 = FunTotalEmpleadosG1();
            if (intBaseG1 == 0) return 0;
            int intPorcentajeG1 = (int)Math.Round(FunPresentesHoyG1() * 100.0 / intBaseG1);
            return Math.Min(100, intPorcentajeG1);
        }

        /// <summary>Últimas marcaciones de hoy.</summary>
        /// <returns>Tabla.</returns>
        public DataTable FunUltimasAsistenciasG1() { return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunUltimasAsistenciasHoyG1()); }

        /// <summary>Tardanzas de hoy.</summary>
        /// <returns>Tabla.</returns>
        public DataTable FunAlertasTardanzaG1() { return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunAlertasTardanzaHoyG1()); }

        /// <summary>Valida el código y devuelve el empleado si existe y está activo.</summary>
        /// <param name="strCodigoG1">Código ingresado.</param>
        /// <returns>Empleado activo.</returns>
        private EmpleadoG1 FunObtenerEmpleadoActivoG1(string strCodigoG1)
        {
            string strCodigoNormalizadoG1 = EmpleadoLogicaG1.FunNormalizarCodigoG1(strCodigoG1);
            EmpleadoG1 objEmpleadoG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjEmpleadoDatosG1.FunBuscarPorCodigoG1(strCodigoNormalizadoG1));
            if (objEmpleadoG1 == null) throw new ArgumentException("No existe un empleado con el código " + strCodigoNormalizadoG1 + ".");
            if (!objEmpleadoG1.Activo) throw new ArgumentException("El empleado " + strCodigoNormalizadoG1 + " está inactivo y no puede marcar.");
            return objEmpleadoG1;
        }

        /// <summary>Crea un resultado de marcaje fallido.</summary>
        /// <param name="strMensajeG1">Motivo.</param>
        /// <returns>Resultado no exitoso.</returns>
        private ResultadoMarcajeG1 FunErrorG1(string strMensajeG1)
        {
            return new ResultadoMarcajeG1 { ExitosoG1 = false, MensajeG1 = strMensajeG1 };
        }
    }
}
