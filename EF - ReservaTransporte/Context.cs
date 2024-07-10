namespace EF___ReservaTransporte {
    internal class Context {
        private IStrategyReserva strategyReserva;

        public Context(IStrategyReserva sr) {
            strategyReserva = sr;
        }
        public void SetTransport(IStrategyReserva sr) {
            strategyReserva = sr;
        }
        public void Reserva() {
            strategyReserva.Transport();
        }
    }
}
