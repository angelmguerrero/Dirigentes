using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorDetallePlantillaOrdenDia : IAdministradorDetallePlantillaOrdenDia
    {

        private IRepositorioDetallePlantillaOrdenDia repo;
        private IRepositorioPlantillaOrdenDia repoPlan;

        public AdministradorDetallePlantillaOrdenDia()
        {
            this.repo = new RepositorioDetallePlantillaOrdenDia();
            this.repoPlan = new RepositorioPlantillaOrdenDia();
        }
        public Respuesta Crear(List<DetallePlantillaOrdenDiaDom> item, int idPLantilla)
        {
            Respuesta resp = new Respuesta();
            List<DetallePlantillaOrdenDiaDom> lista = new List<DetallePlantillaOrdenDiaDom>();
            List<int> listaId = new List<int>();
            int cont = 0;
            lista = iterarDetallesOrden(item, lista);
            foreach (DetallePlantillaOrdenDiaDom detalle in lista)
            {
                int idDetalle = 0;
                detalle.IdPlantillaOrdenDia = idPLantilla;
                idDetalle = repo.Crear(detalle);
                if (idDetalle > 0)
                {
                    listaId.Add(idDetalle);
                }
                else
                {
                    cont++;
                }
            }
            if (cont > 0)
            {
                foreach (int id in listaId)
                {
                    repo.EliminarNivelPorId(id);
                }
                repoPlan.EliminarPlantilla(idPLantilla);
                resp.Resultado = false;
                resp.Mensaje = "Ocurrio un error, no se creo la plantilla";
                return resp;
            }

            resp.Resultado = true;
            return resp;
        }

        public bool Desactivar(List<DetallePlantillaOrdenDiaDom> item)
        {
            //Respuesta resp = new Respuesta();
            List<DetallePlantillaOrdenDiaDom> lista = new List<DetallePlantillaOrdenDiaDom>();
            lista = iterarDetallesOrden(item, lista);
            foreach (DetallePlantillaOrdenDiaDom detalle in lista)
            {

                if (repo.Desactivar(detalle) == false)
                {
                    return false;
                }

            }
            return true;
        }

        public Respuesta Modificar(List<DetallePlantillaOrdenDiaDom> item)
        {
            Respuesta resp = new Respuesta();
            List<DetallePlantillaOrdenDiaDom> lista = new List<DetallePlantillaOrdenDiaDom>();
            lista = iterarDetallesOrden(item, lista);

            foreach (DetallePlantillaOrdenDiaDom detalle in lista)
            {
                if (detalle.IdDetallePlantillaOrdenDia > 0)
                {
                    repo.Modificar(detalle);
                }
                else
                {
                    repo.Crear(detalle);
                }
            }
            resp.Resultado = true;
            return resp;
        }

        public DetallePlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo)
        {
            throw new NotImplementedException();
        }

        public List<DetallePlantillaOrdenDiaDom> RegistrobyId(int id)
        {
            List<DetallePlantillaOrdenDiaDom> lista = repo.RegistrobyId(id);
            List<DetallePlantillaOrdenDiaDom> listaDetalle = new List<DetallePlantillaOrdenDiaDom>();

            foreach (DetallePlantillaOrdenDiaDom child in lista)
            {
                if (buscarItem(child, listaDetalle) == false)
                {
                    listaDetalle.Add(ChildrenOf(id, child));
                }

            }

            return listaDetalle;
        }

        public DetallePlantillaOrdenDiaDom ChildrenOf(int idPlantilla, DetallePlantillaOrdenDiaDom detalle)
        {

            List<DetallePlantillaOrdenDiaDom> lista = repo.RegistrobyIdPadre(idPlantilla, detalle.IdConsecutivoPadre);

            foreach (DetallePlantillaOrdenDiaDom child in lista.Where(x => x.IdPadre == detalle.IdConsecutivoPadre))
            {
                if (detalle.niveles == null)
                    detalle.niveles = new List<DetallePlantillaOrdenDiaDom>();
                detalle.niveles.Add(ChildrenOf(idPlantilla, child));
            }

            return detalle;
        }

        public bool buscarItem(DetallePlantillaOrdenDiaDom detalle, List<DetallePlantillaOrdenDiaDom> lista)
        {

            foreach (DetallePlantillaOrdenDiaDom child in lista)
            {
                if (child.IdDetallePlantillaOrdenDia == detalle.IdDetallePlantillaOrdenDia)
                {
                    return true;
                }
                else
                {
                    if (child.niveles.Count() > 0)
                    {
                        bool finder = buscarItem(detalle, child.niveles);
                        if (finder)
                        {
                            return true;
                        }

                    }
                }

            }

            return false;
        }

        public List<DetallePlantillaOrdenDiaDom> iterarDetallesOrden(List<DetallePlantillaOrdenDiaDom> item, List<DetallePlantillaOrdenDiaDom> lista)
        {
            foreach (DetallePlantillaOrdenDiaDom child in item)
            {
                lista.Add(child);
                if (child.niveles.Count() > 0)
                {
                    iterarDetallesOrden(child.niveles, lista);
                }

            }

            return lista;
        }

        public int ObtenerUltimoIdPadre(int idPlantilla)
        {
            DetallePlantillaOrdenDiaDom detalle = repo.ObtenerUltimoIdPadre(idPlantilla);

            int idPadre = detalle.IdConsecutivoPadre;

            return idPadre;
        }

        public Respuesta ValidarVacios(List<DetallePlantillaOrdenDiaDom> item)
        {
            Respuesta resp = new Respuesta();
            List<DetallePlantillaOrdenDiaDom> lista = new List<DetallePlantillaOrdenDiaDom>();
            lista = iterarDetallesOrden(item, lista);
            foreach (DetallePlantillaOrdenDiaDom detalle in lista)
            {
                if (detalle.Descripcion == "")
                {
                    resp.Resultado = false;
                    resp.Mensaje = "Debes llenar todos los campos.";
                    return resp;
                }
            }
            resp.Resultado = true;
            return resp;
        }
        public List<DetallePlantillaOrdenDiaDom> PlantillaPorIdTipoJunta(int id)
        {
            List<DetallePlantillaOrdenDiaDom> lista = new List<DetallePlantillaOrdenDiaDom>();
            int idPLantilla = repoPlan.ObtenerIdPlantillaPorTipodeJunta(id);
            if (idPLantilla == 0)
            {
                return lista;
            }
            return RegistrobyId(idPLantilla);
        }

        public int ObtenerIdPadrePorTipoJunta(int id)
        {
            int idPLantilla = repoPlan.ObtenerIdPlantillaPorTipodeJunta(id);
            var detallePlantilla = repo.ObtenerUltimoIdPadre(idPLantilla);
            int idPadre = detallePlantilla.IdConsecutivoPadre;
            return idPadre;
        }


    }
}
