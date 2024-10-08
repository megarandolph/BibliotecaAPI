using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public interface IUsuarioServices
    {
        Response<Usuario> Get(int type = 0, int UsuarioId = 0);
        Response<Usuario> GetUsuario(string email);
        Response Post(UsuarioDTO UsuarioDTO);
        Response Put(UsuarioDTO UsuarioDTO);
        Response Delete(int UsuarioID);
    }
    public class UsuarioServices : IUsuarioServices
    {
        private readonly BibliotecaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsuarioServices(BibliotecaDbContext bibliotecaDbContext, IMapper mapper)
        {
            _dbContext = bibliotecaDbContext;
            _mapper = mapper;
        }

        public Response<Usuario> Get(int type = 0, int UsuarioId = 0)
        {
            var response = new Response<Usuario>();

            try
            {
                var Data = _dbContext.Usuarios.ToList();

                if (type == 1)
                {
                    Data = Data.Where(x => x.UsuarioId == UsuarioId).ToList();
                }

                response.DataList = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener los Usuarios.");
            }


            return response;
        }
        public Response<Usuario> GetUsuario(string email)
        {
            var response = new Response<Usuario>();

            try
            {
                var Data = _dbContext.Usuarios.Where(x => x.Email == email).FirstOrDefault();
     
                response.SingleData = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener los Usuarios.");
            }


            return response;
        }
        public Response Post(UsuarioDTO UsuarioDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Usuarios.Where(x => x.Email == UsuarioDTO.Email).ToList();

                if (data.Count == 0)
                {
                    var Usuario = _mapper.Map<Usuario>(UsuarioDTO);
                    _dbContext.Usuarios.Add(Usuario);
                    _dbContext.SaveChanges();
                }
                else
                {
                    response.Errors.Add("Ya existe un usuario igual, por favor volver a intentarlo.");
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar un usuario.");
            }
            return response;
        }

        public Response Put(UsuarioDTO UsuarioDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Usuarios.Find(UsuarioDTO.UsuarioId);
                _mapper.Map(UsuarioDTO, data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de actualizar el usuario.");
            }
            return response;
        }

        public Response Delete(int UsuarioID)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Usuarios.Find(UsuarioID);
                data.Status = false;

                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de eliminar el usuario.");
            }
            return response;
        }
    }
}

