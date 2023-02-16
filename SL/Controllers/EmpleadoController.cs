﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [Route("api/empleado/GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [Route("api/empleado/GetById/{IdEmpleado}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound,result);
            }
        }

        [Route("api/estado/GetEstado")]
        [HttpGet]
        public IHttpActionResult GetEstado()
        {
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [Route("api/empleado/Add")]
        [HttpPost]
        public IHttpActionResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [Route("api/empleado/Update")]
        [HttpPut]
        public IHttpActionResult Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [Route("api/empleado/Delete/{IdEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
