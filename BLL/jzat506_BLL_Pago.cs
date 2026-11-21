using System;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Pago
    {
        private readonly jzat506_ServicioCifrado jzat506_servicioCifrado = new jzat506_ServicioCifrado();
        private readonly jzat506_ServicioBanco jzat506_servicioBanco = new jzat506_ServicioBanco();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public bool jzat506_CobrarVenta(decimal total, jzat506_DatosPago datosPago)
        {
            if (datosPago.jzat506_MedioPago == "Efectivo")
            {
                jzat506_RegistrarEventoPago("Pago confirmado", 2);
                return true;
            }

            string datosBancarios = $"{datosPago.jzat506_Banco}|{datosPago.jzat506_NumeroCuenta}|{datosPago.jzat506_Titular}";
            string datosCifrados = jzat506_servicioCifrado.jzat506_Cifrar(datosBancarios);

            bool respuesta = jzat506_servicioBanco.jzat506_AutorizarPago(datosCifrados, total);

            if (respuesta)
            {
                jzat506_RegistrarEventoPago("Pago confirmado", 2);
                return true;
            }

            jzat506_RegistrarEventoPago("Pago rechazado", 3);
            throw new Exception("El banco rechazo el pago. Verifique los datos bancarios.");
        }

        private void jzat506_RegistrarEventoPago(string descripcion, int criticidad)
        {
            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Ventas",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }
    }
}
