﻿using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioCondicionIngreso
    {
        public List<CondicionIngresoCat> Obtener();
        public List<CondicionIngresoCat> ObtenerActivas();
        public Respuesta Crear(CondicionIngresoCat iten);
        public Respuesta Modificar(CondicionIngresoCat item);

        public bool Desactivar(int id);
        public CondicionIngresoCat RegistrobyId(int id);
        public CondicionIngresoCat ObtenerCondicionPorDescripcion(string descCondicion);

    }
}
