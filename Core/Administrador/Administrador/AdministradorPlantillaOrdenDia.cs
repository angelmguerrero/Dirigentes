using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPlantillaOrdenDia : IAdministradorPlantillaOrdenDia
    {

        private IRepositorioPlantillaOrdenDia repo;
        private IAdministradorDetallePlantillaOrdenDia adminDetalle;

        public AdministradorPlantillaOrdenDia()
        {
            this.repo = new RepositorioPlantillaOrdenDia();
            this.adminDetalle = new AdministradorDetallePlantillaOrdenDia();
        }

        public List<PlantillaOrdenDia> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(PlantillaOrdenDiaDetalles plantilla)
        {
            Respuesta resp = new Respuesta();
            var item = ObtenerPlantillaPorDescripcion(plantilla.encabezado.Descripcion);
            if (item == null)
            {
                int id = repo.Crear(plantilla.encabezado);
                if (id > 0)
                {
                    return adminDetalle.Crear(plantilla.detalles, id);
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje = "Ocurrio un error. No se creo la plantilla";
                    return resp;
                }

            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una plantilla con la misma descripción.";
                return resp;
            }
        }

        public bool Desactivar(int plantilla)
        {
            return repo.Desactivar(plantilla);
        }

        public Respuesta Modificar(PlantillaOrdenDiaDetalles plantilla)
        {
            Respuesta resp = new Respuesta();
            var item = ObtenerPlantillaPorDescripcion(plantilla.encabezado.Descripcion);
            if (item == null || plantilla.encabezado.IdPlantillaOrdenDia == item.IdPlantillaOrdenDia)
            {
                Respuesta respuesta = new Respuesta();
                respuesta = repo.Modificar(plantilla.encabezado);
                if (respuesta.Resultado == true)
                {
                    bool resultadoEliminados;
                    resultadoEliminados = adminDetalle.Desactivar(plantilla.detallesEliminados);
                    if (resultadoEliminados)
                    {
                        resp = adminDetalle.Modificar(plantilla.detalles);
                        return resp;
                    }
                    else
                    {
                        resp.Resultado = false;
                        resp.Mensaje = "Ocurrio un error. No se actualizo la plantilla.";
                        return resp;
                    }
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje = "Ocurrio un error. No se actualizo la plantilla.";
                    return resp;
                }
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una plantilla para el mismo tipo de junta";
                return resp;
            }
        }

        public PlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descPlantilla)
        {
            return repo.ObtenerPlantillaPorDescripcion(descPlantilla);
        }

        public PlantillaOrdenDia RegistrobyId(int idplantilla)
        {
            return repo.RegistrobyId(idplantilla);
        }

        public List<PlantillaOrdenDiaJunta> ObtenerPlantillaOrdenDiaDt()
        {
            return repo.ObtenerPlantillaOrdenDiaDt();
        }
    }
}
