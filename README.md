# Sistema de Control de Asistencia y Planificación de Horarios – Grupo 1

Aplicación de escritorio (C# .NET Framework 4.8, Windows Forms) en 3 capas con SQL Server Express.
Registra entradas y salidas, calcula tardanzas, ausencias, horas extras y su pago, y permite planificar turnos.

## Requisitos
- Windows con **Visual Studio 2019/2022** (carga de trabajo "Desarrollo de escritorio de .NET").
- **SQL Server Express** (instancia `.\SQLEXPRESS`) y SQL Server Management Studio (SSMS).

## 1. Clonar
```
git clone https://github.com/dgrajedas1-bot/proyecto_final0.1Dani.git
```

## 2. Crear la base de datos
1. Abra SSMS y conéctese a `.\SQLEXPRESS`.
2. Abra `BaseDatos/ControlAsistenciaDB.sql` y presione **Ejecutar (F5)**.
   > ⚠️ El script **borra y vuelve a crear** la base `ControlAsistenciaDB` con datos de prueba.

Si su instancia tiene otro nombre, cambie `Data Source` en `CapaPresentacionG1/App.config`
(cadena `ControlAsistenciaDBG1`).

## 3. Abrir y ejecutar
1. Abra **`SistemaControlAsistenciaG1.sln`** (carpeta raíz). También existe
   `SistemaControlAsistencia_G1/SistemaControlAsistencia_G1.slnx` (requiere VS 2022 17.13 o más nuevo).
2. Clic derecho en **CapaPresentacionG1** → *Establecer como proyecto de inicio*.
3. **Compilar → Recompilar solución** y luego **F5**.

**Usuario de prueba:** `admin` / `admin123`

**Códigos de empleado de prueba:** `001` a `006` (el `006` está inactivo). Los códigos son siempre de 3 dígitos.

## Estructura (3 capas)
| Proyecto | Contenido |
|---|---|
| `CapaEntidadesG1` | Clases de datos: `EmpleadoG1`, `TurnoG1`, `AsignacionTurnoG1`, `RegistroAsistenciaG1`, `DepartamentoG1`, `UsuarioG1`, `ResultadoMarcajeG1` |
| `CapaAccesoDatosG1` | `ConexionG1` y clases `*DatosG1` con consultas SQL parametrizadas |
| `CapaLogicaNegocioG1` | Reglas y validaciones (`*LogicaG1`), cálculo de tardanzas y horas extras |
| `CapaPresentacionG1` | Formularios (sin SQL): Login, Principal, Inicio, Marcaje, Empleados, Turnos, Departamentos, Reporte |

## Pantallas
- **Login** → **Principal** (menú lateral; cada módulo se abre dentro de la misma ventana).
- **Inicio:** tarjetas con total de empleados, presentes, tardanzas y % de asistencia de hoy; últimas asistencias y alertas.
- **Marcar Asistencia:** código numérico (`txtCodigoEmpleadoG1`), `btnRegistrarIngresoG1` / `btnRegistrarSalidaG1`.
- **Empleados, Departamentos, Turnos:** Nuevo, Guardar, Actualizar, Eliminar, Buscar, Limpiar.
- **Turnos:** además, asignación de turnos por fecha (planificación de horarios).
- **Asistencia (Reporte):** filtro por fechas, `dgvReporteAsistenciaG1` con retardos, horas trabajadas, horas extras, pago y ausencias.

## Reglas de negocio
- Tardanza: si llega después de la hora de entrada + tolerancia del turno.
- Se puede marcar desde 2 horas antes del inicio del turno hasta su fin; un ingreso por turno; no hay salida sin ingreso.
- Turnos nocturnos (ej. 22:00–06:00) se manejan aunque la salida sea al día siguiente.
- Horas extras = horas trabajadas − duración del turno.
- **Pago horas extras = (Salario Base / 30 / 8) × 1.5 × Horas Extras.**
- Ausente: turno asignado ya terminado sin marcación (se muestra en el reporte).

## Convenciones
Todo nombre nuevo (variables, métodos, controles, clases) termina en **G1** y usa prefijos
(`btn`, `txt`, `dgv`, `cmb`, `dtp`, `lbl`, `Sub…`/`Fun…`). Todas las clases y métodos tienen comentarios XML en español.
