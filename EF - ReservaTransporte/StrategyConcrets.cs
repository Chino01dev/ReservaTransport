using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF___ReservaTransporte {
    internal class StrategyConcrets {
        public class CarTransport : IStrategyReserva {
            public void Transport() {
                Console.WriteLine("este es un auto");
            }
        }
        public class BusTransport : IStrategyReserva {
            public void Transport() {
                Console.WriteLine("este es un bus");
            }       
        }
        public class VanTransport : IStrategyReserva {
            public void Transport() {
                    Console.WriteLine("este es una van");
            }
        }
    }
}
