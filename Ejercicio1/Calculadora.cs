public class Calculadora
    {
        private double resultado;

        public Calculadora(double num)
        {
            resultado = num;
        }  
        

        public double Resultado { get => resultado; set => resultado = value; }

        

        public void Sumar(double termino)
        {
            resultado += termino;
        }

        public void Resta(double termino)
        {
            resultado -= termino;
        }

        public void Producto(double termino)
        {
            resultado *= termino;
        }

        public void Cociente(double termino)
        {
            resultado /= termino;
        }

        public void Limpiar(){
            resultado = 0;
        }
}
