using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Writers.Log4netWrite.Entities;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.Log4netWrite
{
    [Serializable]
    public class Log4netWriter : ALogWriter
    {
        [XmlElement("Rolling")]
        public RollingTag Rolling { get; set; }

        [XmlElement("Output")]
        public OutputTag Output { get; set; }

        private log4net.ILog Log { get; set; }
        
        protected override void Agregar(RegistroInLineTO registro)
        {
            if (Log == null)
            {
                Log = LogManager.GetLogger(Type.GetType(registro.Clase));
            }

            Log.Debug(Formatear(registro));
        }

        public override void Inicializar()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Obtiene el appender de Log4Net que está definido en su configuración.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <returns></returns>
        public static IAppender ObtenerAppender()
        {
            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
            if (hierarchy != null)
            {
                log4net.Repository.Hierarchy.Logger logger = hierarchy.Root;
                if (logger != null)
                {
                    IAppender[] appenders = logger.Repository.GetAppenders();
                    IList<IAppender> appendersList = appenders.Where(c => c.GetType() == typeof(FileAppender) || c.GetType() == typeof(RollingFileAppender)).ToList();

                    if (appendersList.Count > 0)
                    {
                        return appendersList.Single();
                    }
                }
            }
            return null;
        }

        public override void AgregarParametros()
        {
            Log.Debug(FormatoSalida);
            Log.Debug(SeparadorSalida);
        }
    }
}
