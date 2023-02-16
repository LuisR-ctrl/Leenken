using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LRomanLeenkenGroupEntities context = new DL.LRomanLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado.Value;
                            empleado.Estado.Nombre = obj.EstadoNombre;

                            result.Objects.Add(empleado);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar Datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        } 
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LRomanLeenkenGroupEntities context = new DL.LRomanLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    if(query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado.Value;
                        empleado.Estado.Nombre = query.EstadoNombre;

                        result.Object = empleado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar Datos";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LRomanLeenkenGroupEntities context = new DL.LRomanLeenkenGroupEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo registrar al Empleado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LRomanLeenkenGroupEntities context = new DL.LRomanLeenkenGroupEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar al Empleado";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LRomanLeenkenGroupEntities context = new DL.LRomanLeenkenGroupEntities())
                {
                    var query = context.EmpleadoDelete(IdEmpleado);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar al Empleado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
