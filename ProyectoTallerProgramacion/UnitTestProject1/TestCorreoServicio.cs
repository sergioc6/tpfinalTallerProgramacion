using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CorreoServicio;
using DataTransferObject;
using System.Collections.Generic;

namespace TestMoq
{
    /// <summary>
    /// Pruebas sobre el servicio de correo
    /// </summary>
    [TestClass]
    public class TestCorreoServicio
    {
        private CorreoDTO ioMailDTO;
        private CuentaDTO ioCuentaDTO;
        private IList<CorreoDTO> ioListaDeMailsUno;
        private IList<CorreoDTO> ioListaDeMailsDos;

        [TestInitialize]
        public void Inicialize()
        {
            //se instancian las listas de correos
            ioListaDeMailsUno = new List<CorreoDTO>();
            ioListaDeMailsDos = new List<CorreoDTO>();

            //Creamos una cuenta de prueba
            ioCuentaDTO = new CuentaDTO()
            {
                Id = 1111,
                Direccion = "SergioCabral@gmail.com",
                Contraseña = "Cabral1990",
                Nombre = "Seryi",
                Servicio = "Gmail"
            };

            //Creamos un correo de prueba
            ioMailDTO = new CorreoDTO()
            {
                Asunto = "Usando MOQ",
                CuentaDestino = "leoh4410@gmail.com",
                CuentaOrigen = "SergioCabral@gmail.com",
                Texto = "Haciendo prueba Mocking"
            };

            //Armamos una primer lista de correos
            ioListaDeMailsUno.Add(new CorreoDTO
            {
                Id = 1111,
                Asunto = "Nuestro Primer Correo",
                CuentaDestino = "karatekid@gmail.com",
                CuentaOrigen = "danielsan@gmail.com",
                Texto = "Primer correo de la primer lista"
            });

            ioListaDeMailsUno.Add(new CorreoDTO
            {
                Id = 2222,
                Asunto = "Nuestro Segundo Correo",
                CuentaDestino = "motorola@gmail.com",
                CuentaOrigen = "nokia@gmail.com",
                Texto = "Segundo correo de la primer lista"
            });

            ioListaDeMailsUno.Add(new CorreoDTO
             {
                 Id = 3333,
                 Asunto = "Nuestro Tercer Correo",
                 CuentaDestino = "afaplus@gmail.com",
                 CuentaOrigen = "grondona@gmail.com",
                 Texto = "Tercer correo de la primer lista"
             });

            //Armamos la segunda lista de correos
            ioListaDeMailsDos.Add(new CorreoDTO
            {
                Id = 4444,
                Asunto = "Nuestro Cuarto Correo",
                CuentaDestino = "pokemon@gmail.com",
                CuentaOrigen = "digimon@gmail.com",
                Texto = "Primer Correo de la segunda lista"
            });

            ioListaDeMailsDos.Add(new CorreoDTO
            {
                Id = 5555,
                Asunto = "Nuestro quinto Correo",
                CuentaDestino = "salamin@gmail.com",
                CuentaOrigen = "queso@gmail.com",
                Texto = "Segundo Correo de la segunda lista"
            });

            ioListaDeMailsDos.Add(new CorreoDTO
            {
                Id = 6666,
                Asunto = "Nuestro sexto Correo",
                CuentaDestino = "riachuelo@gmail.com",
                CuentaOrigen = "puertoMadero@gmail.com",
                Texto = "Tercer Correo de la segunda lista"
            });
        }


        /// <summary>
        /// Punto 1)a) Si se llama el metodo "EnviarCorreo" se lanza una excepcion genérica
        /// </summary>
        [TestMethod]
        //Se indica que se espera una excepcion en el test del tipo "excepcion" 
        [ExpectedException(typeof(Exception))]

        public void ExcepcionAlEnviarCorreo()
        {
            //Se crea un Mock sobre la interfaz de servicioCorreo
            Mock<IServicioCorreo> servicioMock = new Mock<IServicioCorreo>();
            //Cargamos el Mock con una instancia de envío de correo, con mail y cuenta hardcodeada
            //Luego se le incorpora la excepcion en caso de que la instancia venga con dichos datos hardcodeados
            servicioMock.Setup(var => var.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO)).Throws<Exception>();
            //Se pasa el Mock en un objeto a la interfaz de servicio 
            IServicioCorreo servicio = servicioMock.Object;
            //Como la instancia del servicio se le pasan los mismos datos que se hardcodeaorn en el Mock
            //entonces se lanzara la excepcion generica.  
            servicio.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO);
        }

        /// <summary>
        /// Punto 1) b) Lanzar excepción solo si el correo está destinado a un destinatario específico
        /// </summary>
        [TestMethod]
        //Se indica que se espera una excepcion en el test del tipo "excepcion" 
        [ExpectedException(typeof(Exception))]
        public void ExcepcionParaDestinatario()
        {
            //Se crea un Mock sobre la interfaz de servicioCorreo 
            Mock<IServicioCorreo> servicioMock = new Mock<IServicioCorreo>();
            //Cargamos el Mock con una instancia de envío de correo, con mail y cuenta hardcodeada
            //Se corrobora si el mail hardcodeada posee un destinatario igual a un correo específico
            //Luego se le incorpora la excepcion en caso de que la instancia verifique dicha igualdad 
            servicioMock.When(() => this.ioMailDTO.CuentaDestino.Equals("leoh4410@gmail.com")).Setup(var => var.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO)).Throws<Exception>();
            //Se pasa el Mock en un objeto a la interfaz de servicio 
            IServicioCorreo servicio = servicioMock.Object;
            //Como la instancia del servicio  posee un mail con destinatario identico al correo que se filtra
            //entonces se lanzara la excepcion generica.  
            servicio.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO);
        }

        /// <summary>
        /// Punto 1) c) Determinar si el método enviar correo fue invocado
        /// </summary>
        [TestMethod]
        public void InvocacionDeMetodoEnvioCorreo()
        {
            bool seLlamoMetodo = false;
            //Se crea un Mock sobre la interfaz de servicioCorreo 
            Mock<IServicioCorreo> servicioMock = new Mock<IServicioCorreo>();
            //Cargamos el Mock con una instancia de envío de correo, con mail y cuenta hardcodeada
            //Si ocurre el callback quiere decir que el metodo llego a ejecutarse por lo que pone la variable booleana en true
            servicioMock.Setup(var => var.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO)).Callback(() => { seLlamoMetodo = true; });
            //Se pasa el Mock en un objeto a la interfaz de servicio             
            IServicioCorreo servicio = servicioMock.Object;
            //Se ejecuta la instancia con el Mock (o no, despues de todo es eso lo que vamos a corroborar) 
            servicio.EnviarCorreo(this.ioMailDTO, this.ioCuentaDTO);
            //Como ya dijimos, si se ejecutaba, corria el callback y seLlamoMetodo es true, sino quedaba falso
            //El valor booleano de esta linea nos determina si el metodo se invocó o no. 
            Assert.IsTrue(seLlamoMetodo);
        }

        /// <summary>
        /// Punto 2)a) Devolver una lista de correos arbitraria 
        /// </summary>
        [TestMethod]
        public void RetornaListaDeCorreos()
        {
            //Se crea un Mock sobre la interfaz de servicioCorreo 
            Mock<IServicioCorreo> servicioMock = new Mock<IServicioCorreo>();
            //Se prepara el Mock para que devuelva una lista.
            //Se le indica de cuenta se desea descargar los correos
            servicioMock.Setup(var => var.DescargarCorreos(this.ioCuentaDTO)).Returns(this.ioListaDeMailsUno);
            //Se pasa el Mock en un objeto a la interfaz de servicio             
            IServicioCorreo servicio = servicioMock.Object;
            //Como sabemos que la lista tiene tres correos, porque la creamso previamente con esa cantidad
            //entonces contamos los elementos de la lista y si hay tres es porque se consiguio la lista completa 
            Assert.AreEqual(3, servicio.DescargarCorreos(this.ioCuentaDTO).Count);
        }

        /// <summary>
        /// Punto 2)b) Devolver una lista de correos arbitraria en la primera 
        /// invocación y otra diferente en la segunda invocación
        /// </summary>
        [TestMethod]
        public void DescargarDosListasDeCorreo()
        {
            //Inicializamos un contador de invocaciones 
            var contador = 0;
            //Se crea un Mock sobre la interfaz de servicioCorreo 
            Mock<IServicioCorreo> servicioMock = new Mock<IServicioCorreo>();
            //Se prepara el Mock para que devuelva las dos listas.
            servicioMock.Setup(var => var.DescargarCorreos(this.ioCuentaDTO)).Returns(() =>
                 {
                     contador++;
                     if (contador == 1) { return this.ioListaDeMailsUno; }
                     else { return this.ioListaDeMailsDos; }
                 });
            //Se pasa el Mock en un objeto a la interfaz de servicio 
            IServicioCorreo servicio = servicioMock.Object;
            //Como se crearon dos listas distintas en el metodo de descarga de correo se valida que estén las dos listas
            Assert.AreNotEqual(servicio.DescargarCorreos(this.ioCuentaDTO), servicio.DescargarCorreos(this.ioCuentaDTO));
        }
    }
}