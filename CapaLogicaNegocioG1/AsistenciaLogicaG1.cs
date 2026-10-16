using System;
using CapaAccesoDatosG1;

namespace CapaLogicaNegocioG1
{
    public class AsistenciaLogicaG1
    {
        private AsistenciaDatosG1 gObjDatosG1 = new AsistenciaDatosG1();

        // Fórmula oficial del enunciado
        public decimal SubCalcularPagoHorasExtrasG1(decimal salarioBaseMensual, decimal cantidadHorasExtras)
        {
            // Fórmula: (Salario Base Mensual / 30 / Horas Jornada Diaria) x 1.5 x Cantidad de Horas Extras
            // Asumimos que la jornada diaria son 8 horas
            if (salarioBaseMensual <= 0 || cantidadHorasExtras <= 0) return 0;

            decimal valorHoraNormal = salarioBaseMensual / 30 / 8;
            decimal valorHoraExtra = valorHoraNormal * 1.5m;
            return valorHoraExtra * cantidadHorasExtras;
        }

        // Aquí irán los demás métodos: SubRegistrarIngresoG1, SubRegistrarSalidaG1, etc.
    }
}