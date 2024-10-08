using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public interface IAutorServices
    {
        Response<Autor> Get(int type = 0, int AutorId = 0);
        Response Post(AutorDTO AutorDTO);
        Response Put(AutorDTO AutorDTO);
        Response Delete(int AutorID);
    }
    public class AutorServices : IAutorServices
    {
        private readonly BibliotecaDbContext _dbContext;
        private readonly IMapper _mapper;

        public AutorServices(BibliotecaDbContext bibliotecaDbContext, IMapper mapper)
        {
            _dbContext = bibliotecaDbContext;
            _mapper = mapper;
        }

        public Response<Autor> Get(int type = 0, int AutorId = 0)
        {
            var response = new Response<Autor>();

            try
            {
                var Data = _dbContext.Autors.ToList();

                if (type == 1)
                {
                    Data = Data.Where(x => x.AutorId == AutorId).ToList();
                }

                response.DataList = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener los autores.");
            }


            return response;
        }
        public Response Post(AutorDTO AutorDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Autors.Where(x => x.Nombre == AutorDTO.Nombre).ToList();

                if (data.Count == 0)
                {
                    var Autor = _mapper.Map<Autor>(AutorDTO);
                    _dbContext.Autors.Add(Autor);
                    _dbContext.SaveChanges();
                }
                else
                {
                    response.Errors.Add("Ya existe un autor igual, por favor volver a intentarlo.");
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar un autor.");
            }
            return response;
        }

        public Response Put(AutorDTO AutorDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Autors.Find(AutorDTO.AutorId);
                _mapper.Map(AutorDTO, data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de actualizar el autor.");
            }
            return response;
        }

        public Response Delete(int AutorID)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Autors.Find(AutorID);
                data.Status = false;

                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de eliminar el autor.");
            }
            return response;
        }
    }
}

