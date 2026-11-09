namespace Almacen.Dominio
{
    public class Cliente
    {
        private int aId;
        private string aNombre;
        private string aApellido;
        private string aDireccion;
        private string aTelefono;
        
        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Apellido { get { return aApellido; } set { aApellido = value; } }
        public string Direccion { get { return aDireccion; } set {aDireccion = value; } }
        public string Telefono { get { return aTelefono; } set { aTelefono = value; } }

        public Cliente(int pId, string pNombre, string pApellido, string pDireccion, string pTelefono)
        {
            aId = pId;
            aNombre = pNombre;
            aApellido = pApellido;
            aDireccion = pDireccion;
            aTelefono= pTelefono;
        }
        public Cliente()
        {
            aId = 0;
            aNombre = "";
            aApellido = "";
            aDireccion = "";
            aTelefono = "";
        }
    }
}
