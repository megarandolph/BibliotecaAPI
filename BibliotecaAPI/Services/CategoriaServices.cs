using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public interface ICategoriaServices
    {
        Response<Categorium> Get(int type = 0, int CategoriaId = 0);
        Response Post(CategoriaDTO CategoriaDTO);
        Response Put(CategoriaDTO CategoriaDTO);
        Response Delete(int CategoriaID);
    }
    public class CategoriaServices : ICategoriaServices
    {
        private readonly BibliotecaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoriaServices(BibliotecaDbContext bibliotecaDbContext, IMapper mapper)
        {
            _dbContext = bibliotecaDbContext;
            _mapper = mapper;
        }

        public Response<Categorium> Get(int type = 0, int CategoriaId = 0)
        {
            var response = new Response<Categorium>();

            try
            {
                var Data = _dbContext.Categoria.ToList();

                if (type == 1)
                {
                    Data = Data.Where(x => x.CategoriaId == CategoriaId).ToList();
                }

                response.DataList = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener las categorias.");
            }


            return response;
        }
        public Response Post(CategoriaDTO CategoriaDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Categoria.Where(x => x.Nombre == CategoriaDTO.Nombre).ToList();

                if (data.Count == 0)
                {
                    var Categoria = _mapper.Map<Categorium>(CategoriaDTO);
                    _dbContext.Categoria.Add(Categoria);
                    _dbContext.SaveChanges();
                }
                else
                {
                    response.Errors.Add("Ya existe una categoria igual, por favor volver a intentarlo.");
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar una categoria.");
            }
            return response;
        }

        public Response Put(CategoriaDTO CategoriaDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Categoria.Find(CategoriaDTO.CategoriaId);
                _mapper.Map(CategoriaDTO, data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de actualizar la categoria.");
            }
            return response;
        }

        public Response Delete(int CategoriaID)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Categoria.Find(CategoriaID);
                data.Status = false;

                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de eliminar la categoria.");
            }
            return response;
        }
    }
}

