using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData
{
    public class SharedData
    {
        private static SharedData oInstance;
        public Int32 currentUserId { get; set; }
        public Int32 currentRolId { get; set; }
        public Int32 currentRutalId { get; set; }

        public Int32 guestRolId { get; set; }

        public Int32 accionAlta { get; set; }
        public Int32 accionModificacion { get; set; }
        public Int32 accionBaja { get; set; }

        public DateTime fechaDelSistema { get; set; }

        protected SharedData()
        {        }

        public static SharedData Instance()
        {
            if (oInstance == null)
            {
                oInstance = new SharedData();
                oInstance.currentUserId = 0;
                oInstance.currentRolId = 0;

                oInstance.guestRolId = 3;

                oInstance.accionAlta = 1;
                oInstance.accionModificacion = 2;
                oInstance.accionBaja = 3;

                //FECHA DEL SISTEMA (Cambiar desde App.config)
                oInstance.fechaDelSistema = DateTime.Today;
            }
            return oInstance;
        }
    }
}
